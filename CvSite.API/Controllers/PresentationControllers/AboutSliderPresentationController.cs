using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.PresentationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutSliderPresentationController : ControllerBase
    {
        private readonly IAboutSliderService _service;
        private readonly ILogger logger;
        public AboutSliderPresentationController(IAboutSliderService service, ILogger logger)
        {
            _service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListAboutSlider()
        {
            try
            {
                var value = await _service.GetAllObject();
                logger.LogInformation("AboutSliderPresentation/ListAboutSlider datalari basariyla dondurdu.");
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
