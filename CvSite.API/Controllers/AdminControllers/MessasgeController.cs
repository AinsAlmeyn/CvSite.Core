using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessasgeController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessasgeController(IMessageService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> MessageAdd(Message message)
        {
            if (message == null) return BadRequest();
            else
            {
                await _service.AddObjectAsync(message);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            if (id == null) return BadRequest();

            var article = await _service.GetObjectByIdAsync(id);
            _service.RemoveObject(article);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListMessage()
        {
            var value = await _service.GetAllObject();
            return Ok(value);
        }
    }
}
