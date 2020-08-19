using AutoMapper.Internal;
using EmailSender.BLL.Services.Interface;
using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Enums;
using EmailSender.DAL.Interfaces;
using EmailSender.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSender.EmailHandler
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    public class ScopedProcessingService : IScopedProcessingService
    {
        private IEmailService _service;
        private IEmailHandlerRepository _repo;
        DbContextOptions<HostedContext> _options;
        IServiceProvider _resolver;
        public ScopedProcessingService(IEmailService emailService, IEmailHandlerRepository repository, DbContextOptions<HostedContext> options, IServiceProvider resolver)
        {
            _repo = repository;
            _options = options;
            _resolver = resolver;
            _service = emailService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            IEnumerable<Email> emails = null;
            using (var repo = _resolver.GetService<IEmailHandlerRepository>())
            {
                emails = await repo.GetNewWithTemplates();
                if (emails.Count() > 0)
                {
                    emails.ForAll(x => x.Status = EmailStatus.InProgress);
                    await repo.UpdateBatch(emails);
                }
            }

            emails?.ToList().ForEach(async (email) =>
            {
                try
                {
                    using (var repo = new EmailHandlerRepository(new HostedContext(_options)))
                    {
                        _service.Send(email.Recipient.Email, email.Template.Subject, email.Template.Body);
                        email.Status = EmailStatus.Finished;
                        await repo.Update(email);
                    }
                    Thread.Sleep(new Random().Next(1000, 40000));
                }
                catch (Exception ex)
                {
                    email.Status = EmailStatus.New;
                }
            });

        }
    }
}

