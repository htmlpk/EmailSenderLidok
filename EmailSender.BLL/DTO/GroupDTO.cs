using EmailSender.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.BLL.DTO
{
    public class GroupDTO : BaseEntity
    {
        public string Name { get; set; }
        public List<RecipientDTO> Recipients { get; set; }
    }
}
