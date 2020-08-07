using EmailSender.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.BLL.DTO
{
    public class RecipientDTO : BaseEntity
    {
        public string Email { get; set; }
    }
}
