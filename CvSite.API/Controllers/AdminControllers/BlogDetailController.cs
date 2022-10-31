using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogDetailController : ControllerBase
    {
        private readonly IBlogInfoService _blogInfoService;
        public BlogDetailController(IBlogInfoService blogInfoService)
        {
            _blogInfoService = blogInfoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _blogInfoService.GetObjectByIdAsync(id);
            return Ok(article);
        }
    }
}
