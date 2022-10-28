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
        public BlogInfoPresentationController(IBlogInfoService blogInfoService)
        {
            this.blogInfoService = blogInfoService;
        }
        
        [HttpGet]
        public async Task<IActionResult> BlogInfo()
        {
            var values = await blogInfoService.GetAllObject();
            return Ok(values);
        }
    }
}
