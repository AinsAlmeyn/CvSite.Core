using CvSite.Core.Entities;
using CvSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewHomeController : ControllerBase
    {
        private readonly IHomeService homeService;
        public NewHomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await homeService.GetObjectByIdAsync(id);
            return Ok(article);
        }

        [HttpPut]
        public IActionResult NewHomeUpdate(Home home)
        {
            if (home == null) return BadRequest();
            else
            {
                homeService.UpdateObject(home);
                return Ok();
            }
        }
    }
}
