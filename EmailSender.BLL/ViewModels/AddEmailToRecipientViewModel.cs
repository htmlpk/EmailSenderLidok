
using System;

namespace EmailSender.BLL.ViewModels
{
    public class AddEmailToRecipientViewModel
    {
        public Guid RecipientId { get; set; }
        public Guid TemplateId { get; set; }
    }
}
