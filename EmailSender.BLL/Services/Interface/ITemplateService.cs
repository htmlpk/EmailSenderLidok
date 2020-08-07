using EmailSender.BLL.ViewModels;
using EmailSender.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.BLL.Services.Interface
{
    public interface ITemplateService
    {
        public Task<IEnumerable<TemplateDTO>> GetAll();
        public Task Create(AddTemplateViewModel model);
        public Task Delete(Guid id);
    }
}
