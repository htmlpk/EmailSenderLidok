using System;

namespace EmailSender.DAL.Entity
{
    public class BaseEntity: IEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
