using CvSite.Core.Entities;
using CvSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewHomeController : ControllerBase
    {
        private readonly IHomeService homeService;
        private readonly ILogger logger;
        public NewHomeController(IHomeService homeService, ILogger<Home> logger)
        {
            this.homeService = homeService;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    logger.LogWarning("NewHome/GetById icin id nesnesi null geldi");
                    return BadRequest();
                }
                else
                {
                    var article = await homeService.GetObjectByIdAsync(id);
                    logger.LogInformation($"NewHome/GetById icin islem basarili. Response = {article.Id}");
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
        public IActionResult NewHomeUpdate(Home home)
        {
            try
            {
                if (home == null) {logger.LogWarning("NewHome/NewHomeUpdate icin home nesnesi null geldi.") ; return BadRequest(); }
                else
                {
                    homeService.UpdateObject(home);
                    logger.LogInformation($"NewHome/NewHomeUpdate icin home nesnesi guncellendi. Response = {home.Id}");
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
