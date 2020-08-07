
using System;

namespace EmailSender.BLL.ViewModels
{
    public class AddEmailToGroupViewModel
    {
        public Guid GroupId { get; set; }
        public Guid TemplateId { get; set; }
    }
}
