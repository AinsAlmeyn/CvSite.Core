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
        public GetInTouchController(IGetInTouchService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _service.GetObjectByIdAsync(id);
            return Ok(article);
        }

        [HttpPut]
        public IActionResult GetInTouchUpdate(GetInTouch getInTouch)
        {
            if (getInTouch == null) return BadRequest();
            else
            {
                _service.UpdateObject(getInTouch);
                return Ok();
            }
        }
    }
}
