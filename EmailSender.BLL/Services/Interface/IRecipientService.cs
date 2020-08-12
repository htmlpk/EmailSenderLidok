using EmailSender.BLL.ViewModels;
using EmailSender.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.BLL.Services.Interface
{
    public interface IRecipientService
    {
        public Task<IEnumerable<RecipientDTO>> GetAll();
        public Task<IEnumerable<RecipientDTO>> GetAllWithGroup();
        public Task Create(AddRecipientViewModel model);
        public Task Delete(Guid id);
    }
}
