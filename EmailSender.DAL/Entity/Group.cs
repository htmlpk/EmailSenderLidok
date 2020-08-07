
using System.Collections.Generic;

namespace EmailSender.DAL.Entity
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<RecipientInGroup> RecipientInGroups { get; set; }
    }
}
