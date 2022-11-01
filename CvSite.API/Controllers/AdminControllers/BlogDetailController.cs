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
        private readonly ILogger logger;
        public BlogDetailController(IBlogInfoService blogInfoService, ILogger logger)
        {
            _blogInfoService = blogInfoService;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id.ToString() == null)
                {
                    logger.LogWarning($"BlogDetail/GetById icin id degeri null geldi");
                    return BadRequest();
                }
                else
                {
                    var article = await _blogInfoService.GetObjectByIdAsync(id);
                    logger.LogInformation($"BlogDetail/GetById icin nesne istegi basarili. Response = {article.BlogInfoId},{article.Title}");
                    return Ok(article);
                }
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message}");
                return BadRequest();
            }
        }
    }
}
