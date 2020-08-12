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
    public class RecipientService: IRecipientService
    {
        IRecipientRepository _repo;
        IMapper _mapper;
        public RecipientService(IRecipientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<RecipientDTO>> GetAll()
        {
            var recipients =  await _repo.GetAll();
            var recipientsDTO = recipients.Select(rec => _mapper.Map<RecipientDTO>(rec));
            return recipientsDTO;
        }

        public async Task<IEnumerable<RecipientDTO>> GetAllWithGroup()
        {
            var recipients = await _repo.GetAllWithGroup();
            var recipientsDTO = recipients.Select(rec => RecipientToDTO(rec));
            return recipientsDTO;
        }

        public async Task Create(AddRecipientViewModel model)
        {
            var recipient = new Recipient();
            recipient.Email = model.Email;
            await _repo.Create(recipient);
        }
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        private RecipientDTO RecipientToDTO(Recipient entity)
        {
            var model = new RecipientDTO();
            model.Id = entity.Id;
            model.CreationDate = entity.CreationDate;
            model.Email = entity.Email;
            model.GroupNames = entity.RecipientInGroups.Select(rig => rig.Group.Name).ToList();
            return model;
        }
    }
}
