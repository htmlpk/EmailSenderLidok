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
    public class EmailController : ControllerBase
    {
        IEmailService _service;

        public EmailController(IEmailService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public async Task<IEnumerable<EmailDTO>> Get()
        //{
        //    return await _service.GetAll();
        //}

        [HttpPost("createSingle")]
        public async Task Create([FromBody]AddEmailToRecipientViewModel model)
        {
            await _service.CreateForRecipient(model);
        }

        [HttpPost("createGroup")]
        public async Task Create([FromBody]AddEmailToGroupViewModel model)
        {
            await _service.CreateForGroup(model);
        }

        //[HttpDelete]
        //public async Task Delete(Guid id)
        //{
        //    await _service.Delete(id);
        //}
    }
}
