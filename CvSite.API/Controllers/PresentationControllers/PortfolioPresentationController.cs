using CvSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.PresentationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioPresentationController : ControllerBase
    {

        private readonly IPortfolioService _portfolioService;
        private readonly ILogger logger;
        public PortfolioPresentationController(IPortfolioService portfolioService, ILogger logger)
        {
            _portfolioService = portfolioService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> PortfolioList()
        {
            try
            {
                var value = await _portfolioService.GetAllObject();
                logger.LogInformation("PortfolioPresentation/PortfolioList datalari basariyla dondurdu.");
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
