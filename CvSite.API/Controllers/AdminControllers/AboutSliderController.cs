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
        private readonly ILogger _logger;
        private readonly IAboutSliderService aboutSliderService;
        public AboutSliderController(IAboutSliderService aboutSliderService, ILogger<AboutSlider> logger)
        {
            this.aboutSliderService = aboutSliderService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var article = await aboutSliderService.GetObjectByIdAsync(id);
                if (article == null)
                {
                    return BadRequest();
                    _logger.LogError($"AboutSlider/GetById id uzerinden objeyi getiremedi. Response = {article.SliderId}");
                }
                else
                {
                    _logger.LogInformation($"AboutSlider/GetById id uzerinden objeyi basarili sekilde dondurdu. Response = {article.SliderId}");
                    return Ok(article);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return BadRequest();
            }
            
        }

        [HttpPut]
        public IActionResult AboutSliderUpdate(AboutSlider aboutSlider)
        {
            try
            {
                if (aboutSlider == null) { _logger.LogWarning($"AboutSliderUpdate icin data null dondu."); return BadRequest(); }
                else
                {
                    aboutSliderService.UpdateObject(aboutSlider);
                    _logger.LogInformation("About Slider basariyla guncellendi.");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Bir hata olustu hata mesaji = {e.Message}");
                return BadRequest();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AboutSliderAdd(AboutSlider aboutSlider)
        {
            try
            {
                if (aboutSlider == null) { _logger.LogWarning($"AboutSliderAdd icin data null dondu."); return BadRequest(); }
                else
                {
                    await aboutSliderService.AddObjectAsync(aboutSlider);
                    _logger.LogInformation($"AboutSliderAdd icin islem basarili gerceklesti, Nesne = {aboutSlider.SliderTitle}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($" Beklenmeyen hatayla karsilasildi. {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            try
            {
                if (id.ToString() == null) { _logger.LogWarning("GetByIdDelete icin id null geldi"); return BadRequest(); }
                else
                {
                    var article = await aboutSliderService.GetObjectByIdAsync(id);
                    aboutSliderService.RemoveObject(article);
                    _logger.LogInformation($"GetByIdDelete icin nesne basariyla kaldirildi {article.SliderTitle}, {article.SliderId}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
            
        }
    }
}
