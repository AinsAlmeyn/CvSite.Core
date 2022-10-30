using CvSite.Core.Entities;
using CvSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutSliderController : ControllerBase
    {
        private readonly IAboutSliderService aboutSliderService;
        public AboutSliderController(IAboutSliderService aboutSliderService)
        {
            this.aboutSliderService = aboutSliderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await aboutSliderService.GetObjectByIdAsync(id);
            return Ok(article);
        }

        [HttpPut]
        public IActionResult AboutSliderUpdate(AboutSlider aboutSlider)
        {
            if (aboutSlider == null) return BadRequest();
            else
            {
                aboutSliderService.UpdateObject(aboutSlider);
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AboutSliderAdd(AboutSlider aboutSlider)
        {
            if (aboutSlider == null) return BadRequest();
            else
            {
                await aboutSliderService.AddObjectAsync(aboutSlider);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            if (id == null) return BadRequest();

            var article = await aboutSliderService.GetObjectByIdAsync(id);
            aboutSliderService.RemoveObject(article);
            return Ok();
        }
    }
}
