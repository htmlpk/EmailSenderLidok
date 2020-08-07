using EmailSender.BLL.ViewModels;
using EmailSender.DAL;
using EmailSender.DAL.Entity;
using System.Threading.Tasks;

namespace EmailSender.BLL.Services.Interface
{
    public interface IEmailService
    {
        public void Send(string to, string subject, string body, string from = "ffv438@gmail.com");
        public Task CreateForGroup(AddEmailToGroupViewModel model);
        public Task CreateForRecipient(AddEmailToRecipientViewModel model);
        public  Task ResetFailedEmails();
    }
}
