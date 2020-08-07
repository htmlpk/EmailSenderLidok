using EmailSender.DAL.Enums;
using System;

namespace EmailSender.DAL.Entity
{
    public class Email : BaseEntity
    {
        public Email(Guid recipientId, Guid templateId)
        {
            RecipientId = recipientId;
            TemplateId = templateId;
            Status = EmailStatus.New;
        }
        public Guid RecipientId { get; set; }
        public Guid TemplateId { get; set; }
        public EmailStatus Status { get; set; }
        public virtual Recipient Recipient { get; set; }
        public virtual Template Template { get; set; }
    }
}
