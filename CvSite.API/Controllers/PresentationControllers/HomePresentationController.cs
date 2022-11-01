using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
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
        private readonly ILogger logger;
        public HomePresentationController(IHomeService homeService, ILogger logger)
        {
            _homeService = homeService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            try
            {
                var value = await _homeService.GetOneHome();
                logger.LogInformation("HomePresentation/Home datalari basariyla dondurdu.");
                return Ok(value);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
