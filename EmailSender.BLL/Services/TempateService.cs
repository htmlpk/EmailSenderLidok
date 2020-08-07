using AutoMapper;
using EmailSender.BLL.DTO;
using EmailSender.BLL.Services.Interface;
using EmailSender.BLL.ViewModels;
using EmailSender.DAL.Entity;
using EmailSender.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.BLL.Services
{
    public class TemplateService: ITemplateService
    {
        ITemplateRepository _repo;
        IMapper _mapper;
        public TemplateService(ITemplateRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateDTO>> GetAll()
        {
            var templates =  await _repo.GetAll();
            var templatesDTO = templates.Select(rec => _mapper.Map<TemplateDTO>(rec));
            return templatesDTO;
        }

        public async Task Create(AddTemplateViewModel model)
        {
            var template = new Template();
            template.Body = model.Body;
            template.Subject = model.Subject;
            await _repo.Create(template);
        }
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }
    }
}
