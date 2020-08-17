using AutoMapper.Internal;
using EmailSender.BLL.Services.Interface;
using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Enums;
using EmailSender.DAL.Interfaces;
using EmailSender.DAL.Repository;
using Microsoft.EntityFrameworkCore;
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
        //private DbContextOptionsBuilder<ApplicationContext> optionsBuilder;

        public ScopedProcessingService(IEmailService service, IEmailHandlerRepository repository)
        {
            _service = service;
            _repo = repository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            IEnumerable<Email> emails;
            //var _repo = GetContext();
            emails = await _repo.GetNewWithTemplates();
            //_repo.Dispose();
            if (emails.Count() > 0)
            {
                emails.ForAll(x => x.Status = EmailStatus.InProgress);
                //_repo = GetContext();
                //_repo.Dispose();
                try
                {
                    // var task = Task.Run(
                    //delegate
                    //{
                    emails.ToList().ForEach(async (email) =>
                    {
                        try
                        {
                            await _repo.Update(email);
                            _service.Send(email.Recipient.Email, email.Template.Subject, email.Template.Body);
                            email.Status = EmailStatus.Finished;
                            await _repo.Update(email);
                        }
                        catch (Exception ex)
                        {
                            email.Status = EmailStatus.New;
                        }
                    });
                    //});
                }
                catch (Exception ex)
                {
                }

            }
        }
        //private EmailRepository GetContext()
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        //    optionsBuilder.UseSqlServer("Server=SW-DEV88\\SQLEXPRESS;Database=EmailSender;Trusted_Connection=True;MultipleActiveResultSets=True");
        //    return new EmailRepository(new ApplicationContext(optionsBuilder.Options));
        //}
    }
}
