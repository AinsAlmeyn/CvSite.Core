using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewAboutController : ControllerBase
    {
        private readonly INewAboutService service;
        public NewAboutController(INewAboutService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await service.GetObjectByIdAsync(id);
            return Ok(article);
        }

        [HttpPut]
        public IActionResult NewAboutUpdate(NewAbout newAbout)
        {
            if (newAbout== null) return BadRequest();
            else
            {
                service.UpdateObject(newAbout);
                return Ok();
            }
        }
    }
}
