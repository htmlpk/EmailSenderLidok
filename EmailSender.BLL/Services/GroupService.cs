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
        public GroupService(IGroupRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDTO>> GetAll()
        {
            var groups =  await _repo.GetAll();
            var recipientsDTO = groups.Select(rec => _mapper.Map<GroupDTO>(rec));
            return recipientsDTO;
        }

        public async Task Create(AddGroupViewModel model)
        {
            var group = new Group();
            group.Name = model.Name;
            await _repo.Create(group);
        }
        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }
    }
}
