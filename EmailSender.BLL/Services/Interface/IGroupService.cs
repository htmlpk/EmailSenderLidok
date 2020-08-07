using EmailSender.BLL.DTO;
using EmailSender.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.BLL.Services.Interface
{
    public interface IGroupService
    {
        public Task<IEnumerable<GroupDTO>> GetAll();
        public Task Create(AddGroupViewModel model);
        public Task Delete(Guid id);
    }
}
