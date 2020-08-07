
using System.Collections.Generic;

namespace EmailSender.DAL.Entity
{
    public class Recipient : BaseEntity
    {
        public string Email { get; set; }
        public virtual List<RecipientInGroup> RecipientInGroups { get; set; }
    }
}
