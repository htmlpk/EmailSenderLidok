using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.DAL.Entity
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
