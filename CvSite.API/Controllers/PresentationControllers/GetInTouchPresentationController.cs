using CvSite.Core.Entities;
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
        private readonly ILogger logger;
        public GetInTouchPresentationController(IGetInTouchService getInTouchService, ILogger<GetInTouch> logger)
        {
            this.getInTouchService = getInTouchService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> OneTouch()
        {
            try
            {
                var value = await getInTouchService.GetOneTouch();
                logger.LogInformation("GetInTouchPresentation/OneTouch datalari basariyla dondurdu.");
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
