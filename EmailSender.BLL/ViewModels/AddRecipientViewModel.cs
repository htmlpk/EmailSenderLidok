using System.ComponentModel.DataAnnotations;

namespace EmailSender.BLL.ViewModels
{
    public class AddRecipientViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
