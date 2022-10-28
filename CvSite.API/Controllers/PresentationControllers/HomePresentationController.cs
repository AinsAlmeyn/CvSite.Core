using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvSite.Core.Entities;
using CvSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CvSite.API.Controllers.PresentationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomePresentationController : ControllerBase
    {
        private readonly IHomeService _homeService;
        public HomePresentationController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var value = await _homeService.GetOneHome();
            return Ok(value);
        }
    }
}
