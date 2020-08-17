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
    public class GroupService: IGroupService
    {
        IGroupRepository _repo;
        IMapper _mapper;
        IRecipientInGroupRepository _rigRepo;
        public GroupService(IGroupRepository repo, IRecipientInGroupRepository rigRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _rigRepo = rigRepo;
        }

        public async Task<IEnumerable<GroupDTO>> GetAll()
        {
            var groups =  await _repo.GetAll();
            var recipientsDTO = groups.Select(rec => _mapper.Map<GroupDTO>(rec));
            return recipientsDTO;
        }

        public async Task<IEnumerable<GroupDTO>> GetWithRecipients()
        {
            var groups =  await _repo.GetWithRecipients();
            var groupsDTO = groups.Select(group => GroupToGroupDTO(group));
            return groupsDTO;
        }

        public async Task Create(AddGroupViewModel model)
        {
            var group = new Group();
            group.Name = model.Name;
            await _repo.Create(group);
        }

        public async Task AddRicipientToGroup(AddRecipientToGroupViewModel model)
        {
            var recipientInGroup = new RecipientInGroup();
            recipientInGroup.RecipientId = model.UserId;
            recipientInGroup.GroupId = model.GroupId;
            await _rigRepo.Create(recipientInGroup);
        }
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        private GroupDTO GroupToGroupDTO(Group entity)
        {
            var model = new GroupDTO();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Recipients = entity.RecipientInGroups.Select(r => RecipientToDTO(r.Recipient)).ToList();
            return model;
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
