using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessasgeController : ControllerBase
    {
        private readonly IMessageService _service;
        private readonly ILogger logger;
        public MessasgeController(IMessageService service, ILogger<Message> logger)
        {
            this.logger = logger;
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> MessageAdd(Message message)
        {
            try
            {

                if (message == null) { logger.LogWarning($"Message/MessageAdd icin message nesnesi null dondu."); return BadRequest(); }
                else
                {
                    await _service.AddObjectAsync(message);
                    logger.LogInformation($"Message/MessageAdd icin islem basarili.{message.Id}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            try
            {

                if (id == null) { logger.LogWarning("Message/GetByIdDelete icin id null geldi"); return BadRequest(); }
                else
                {
                    var article = await _service.GetObjectByIdAsync(id);
                    _service.RemoveObject(article);
                    logger.LogInformation($"Message/GetByIdDelete icin islem basarili. Response = {article.Name}, {article.Id}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListMessage()
        {
            try
            {
                var value = await _service.GetAllObject();
                logger.LogInformation($"Message/ListMessage icin liste basarilir sekilde dondu. Response = {value}");
                return Ok(value);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
