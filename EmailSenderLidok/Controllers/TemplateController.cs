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
    public class TemplateController : ControllerBase
    {
        ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TemplateDTO>> Get()
        {
            return await _service.GetAll();
        }

        [HttpPost("/create")]
        public async Task Create([FromBody]AddTemplateViewModel model)
        {
            await _service.Create(model);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _service.Delete(id);
        }
    }
}
