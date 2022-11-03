using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.PresentationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutPresentationController : ControllerBase
    {
        private readonly INewAboutService aboutService;
        private readonly ILogger logger;
        public AboutPresentationController(INewAboutService aboutService, ILogger<NewAbout> logger)
        {
            this.aboutService = aboutService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> NewAbout()
        {
            try
            {
                var value = await aboutService.GetOneAbout();
                logger.LogInformation("AboutPresentation/NewAbout basarili sekilde sayfayi dondurdu.");
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
