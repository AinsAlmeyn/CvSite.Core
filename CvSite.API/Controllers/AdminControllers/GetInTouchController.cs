using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetInTouchController : ControllerBase
    {
        private readonly IGetInTouchService _service;
        private readonly ILogger _logger;
        public GetInTouchController(IGetInTouchService service, ILogger<GetInTouch> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id.ToString() == null)
                {
                    _logger.LogWarning($"GetInTouch/GetById icin id nesnesi null geldi.");
                    return BadRequest();
                }
                else
                {
                    var article = await _service.GetObjectByIdAsync(id);
                    _logger.LogInformation($"GetInTouch/GetById icin islem basarili. Response = {article.Id}");
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
        public IActionResult GetInTouchUpdate(GetInTouch getInTouch)
        {
            try
            {
                if (getInTouch == null) { _logger.LogWarning($"GetInTouch/GetInTouchUpdate icin nesne null dondu") ; return BadRequest(); }
                else
                {
                    _service.UpdateObject(getInTouch);
                    _logger.LogInformation($"GetInTouch/GetInTouchUpdate icin guncelleme basarili. Response {getInTouch.Id}");
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
