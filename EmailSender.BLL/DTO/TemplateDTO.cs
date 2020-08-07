using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.BLL.DTO
{
    public class TemplateDTO
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
