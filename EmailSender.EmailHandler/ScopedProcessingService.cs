using AutoMapper.Internal;
using EmailSender.BLL.Services.Interface;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Enums;
using EmailSender.DAL.Interfaces;
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

        public ScopedProcessingService(IEmailService service, IEmailRepository repository)
        {
            _service = service;
            _repo = repository;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (true)
            {
                var emails = await _repo.GetNewWithTemplates();
                if (emails.Count() > 0)
                {
                    emails.ForAll(x => x.Status = EmailStatus.New);
                    _repo.UpdateBatch(emails);
                    _ = Task.Run(
                       delegate
                       {
                           emails.ToList().ForEach(async (email) =>
                           {
                               try
                               {
                                   _service.Send(email.Recipient.Email, email.Template.Subject, email.Template.Body);
                                   email.Status = EmailStatus.Finished;
                               }
                               catch (Exception)
                               {
                                   email.Status = EmailStatus.New;
                               }
                           });
                           _repo.UpdateBatch(emails);
                       });
                    await Task.Delay(1000, new CancellationToken());
                }
            }
        }
    }
}
