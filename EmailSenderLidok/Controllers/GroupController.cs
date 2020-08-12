using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailSender.BLL.DTO;
using EmailSender.BLL.Services.Interface;
using EmailSender.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderLidok.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<GroupDTO>> Get()
        {
            return await _service.GetWithRecipients();
        }

        [HttpPost]
        public async Task Create([FromBody]AddGroupViewModel model)
        {
            await _service.Create(model);
        }

        [HttpPost("addRecipientToGroup")]
        public async Task AddRecepientToGroup([FromBody]AddRecipientToGroupViewModel model)
        {
            await _service.AddRicipientToGroup(model);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _service.Delete(id);
        }
    }
}
