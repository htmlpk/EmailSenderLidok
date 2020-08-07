using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.DAL.Entity
{
    public class RecipientInGroup : BaseEntity
    {
        public Guid RecepientId { get; set; }
        public Guid GroupId { get; set; }
        public virtual Recipient Recipient { get; set; }
        public virtual Group Group { get; set; }
    }
}
