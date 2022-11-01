using CvSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.PresentationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogInfoPresentationController : ControllerBase
    {
        private readonly IBlogInfoService blogInfoService;
        private readonly ILogger logger;
        public BlogInfoPresentationController(IBlogInfoService blogInfoService, ILogger logger)
        {
            this.logger = logger;
            this.blogInfoService = blogInfoService;
        }
        
        [HttpGet]
        public async Task<IActionResult> BlogInfo()
        {
            try
            {
                var values = await blogInfoService.GetAllObject();
                logger.LogInformation("BlogInfoPresentation/BlogInfo datalari basariyla dondurdu.");
                return Ok(values);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
