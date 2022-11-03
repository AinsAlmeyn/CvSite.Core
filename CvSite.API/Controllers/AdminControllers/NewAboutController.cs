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
    public class NewAboutController : ControllerBase
    {
        private readonly INewAboutService service;
        private readonly ILogger logger;

        public NewAboutController(INewAboutService service, ILogger<NewAbout> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id.ToString() == null)
                {
                    logger.LogWarning($"NewAbout/GetById icin id degeri null dondu");
                    return BadRequest();
                }
                else
                {
                    var article = await service.GetObjectByIdAsync(id);
                    logger.LogInformation($"NewAbout/GetById icin nesne basarili sekilde donduruldu. Response = {article.NewId}, {article.Title}");
                    return Ok(article);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult NewAboutUpdate(NewAbout newAbout)
        {
            try
             {
                if (newAbout == null) { logger.LogWarning($"NewAbout/NewAboutUpdate icin newAbout nesnesi null geldi"); return BadRequest(); }
                else
                {
                    service.UpdateObject(newAbout);
                    logger.LogInformation($"NewAbout/NewAboutUpdate icin update islemi gerceklesti. Response = {newAbout.NewId}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
