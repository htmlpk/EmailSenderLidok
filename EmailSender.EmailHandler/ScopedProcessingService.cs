using AutoMapper.Internal;
using EmailSender.BLL.Services.Interface;
using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Enums;
using EmailSender.DAL.Interfaces;
using EmailSender.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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
        private IEmailRepository _repo;
        private DbContextOptionsBuilder<ApplicationContext> optionsBuilder;

        public ScopedProcessingService(IEmailService service, IEmailRepository repository)
        {
            _service = service;
            optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=SW-DEV88\\SQLEXPRESS;Database=EmailSender;Trusted_Connection=True;MultipleActiveResultSets=True");
            _repo = new EmailRepository(new ApplicationContext(optionsBuilder.Options));
            //_repo = repository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            var emails = await _repo.GetNewWithTemplates();
            if (emails.Count() > 0)
            {
                emails.ForAll(x => x.Status = EmailStatus.InProgress);
                await _repo.UpdateBatch(emails);
                try
                {
                    // var task = Task.Run(
                    //delegate
                    //{
                    emails.ToList().ForEach(async (email) =>
                    {
                        try
                        {
                            _service.Send(email.Recipient.Email, email.Template.Subject, email.Template.Body);
                            email.Status = EmailStatus.Finished;
                            await _repo.Update(email);
                        }
                        catch (Exception)
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
    }
}
