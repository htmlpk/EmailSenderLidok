using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailSender.BLL.DTO;
using EmailSender.BLL.Services.Interface;
using EmailSender.BLL.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderLidok.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipientController : ControllerBase
    {
        IRecipientService _service;

        public RecipientController(IRecipientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipientDTO>> Get()
        {
            return await _service.GetAllWithGroup();
        }

        [HttpPost]
        public async Task Create([FromBody]AddRecipientViewModel model)
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
