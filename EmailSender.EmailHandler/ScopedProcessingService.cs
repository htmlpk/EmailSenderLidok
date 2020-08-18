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

        public ScopedProcessingService(IEmailHandlerRepository repository)
        {
            _repo = repository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            var emails = await _repo.GetNewWithTemplates();
            if (emails.Count() > 0)
            {
                emails.ForAll(x => x.Status = EmailStatus.InProgress);
                emails.ToList().ForEach(async (email) =>
                {
                    try
                    {
                        await _repo.Update(email);
                        _service.Send(email.Recipient.Email, email.Template.Subject, email.Template.Body);
                        email.Status = EmailStatus.Finished;
                        await _repo.Update(email);
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
}
