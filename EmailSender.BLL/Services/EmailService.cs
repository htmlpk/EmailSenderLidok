using EmailSender.BLL.Services.Interface;
using EmailSender.BLL.ViewModels;
using EmailSender.DAL.Context;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailSender.BLL.Services
{
    public class EmailService : IEmailService
    {
        private IEmailRepository _emailRepo;
        private IRecipientInGroupRepository _repo;

        public EmailService(IEmailRepository emailRepo, IRecipientInGroupRepository repo)
        {
            _emailRepo = emailRepo;
            _repo = repo;
        }
        public async Task ResetFailedEmails()
        {
            var failedEmails = _emailRepo.GetAllFailed();
            await failedEmails.ForEachAsync(e => e.Status = DAL.Enums.EmailStatus.New);
            await _emailRepo.UpdateBatch(failedEmails);
        }
        public async Task CreateForGroup(AddEmailToGroupViewModel model)
        {
            var recipientIds = (await _repo.GetAll()).Where(rig => rig.GroupId == model.GroupId).Select(g => g.RecipientId);
            var emails = recipientIds.Select(rId => new Email(rId, model.TemplateId));
            await _emailRepo.CreateBatch(emails);
        }

        public async Task CreateForRecipient(AddEmailToRecipientViewModel model)
        {
            await _emailRepo.Create(new Email(model.RecipientId, model.TemplateId));
        }

        public void Send(string to, string subject, string body, string from = "ffv438@gmail.com")
        {
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ffv438@gmail.com", "9x7176785aaaAA#");
                smtp.EnableSsl = true;
                smtp.Send(from, to, subject, body);
            }
        }
    }
}
