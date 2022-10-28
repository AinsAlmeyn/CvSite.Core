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
        public AboutSliderPresentationController(IAboutSliderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListAboutSlider()
        {
            var value = await _service.GetAllObject();
            return Ok(value);
        }
    }
}
