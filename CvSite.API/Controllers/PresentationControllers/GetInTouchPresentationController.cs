using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.PresentationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetInTouchPresentationController : ControllerBase
    {
        private readonly IGetInTouchService getInTouchService;
        public GetInTouchPresentationController(IGetInTouchService getInTouchService)
        {
            this.getInTouchService = getInTouchService;
        }

        [HttpGet]
        public async Task<IActionResult> OneTouch()
        {
            var value = await getInTouchService.GetOneTouch();
            return Ok(value);
        }
    }
}
