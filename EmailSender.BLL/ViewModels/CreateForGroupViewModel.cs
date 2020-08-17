using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.BLL.ViewModels
{
    public class AddRecipientToGroupViewModel
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }

    }
}
