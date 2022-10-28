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
        public AboutPresentationController(INewAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> NewAbout()
        {
            var value = await aboutService.GetOneAbout();
            return Ok(value);
        }
    }
}
