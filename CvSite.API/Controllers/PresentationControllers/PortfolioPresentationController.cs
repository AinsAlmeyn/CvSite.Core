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
        public PortfolioPresentationController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<IActionResult> PortfolioList()
        {
            var value = await _portfolioService.GetAllObject();
            return Ok(value);
        }

    }
}
