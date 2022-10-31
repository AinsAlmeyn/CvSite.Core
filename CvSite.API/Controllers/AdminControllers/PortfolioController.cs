using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await portfolioService.GetObjectByIdAsync(id);
            return Ok(article);
        }

        [HttpPut]
        public IActionResult PortfolioUpdate(Portfolio portfolio)
        {
            if (portfolio == null) return BadRequest();
            else
            {
                portfolioService.UpdateObject(portfolio);
                return Ok();
            }
        }


        [HttpPost]
        public async Task<IActionResult> PortfolioAdd(Portfolio portfolio)
        {
            if (portfolio == null) return BadRequest();
            else
            {
                await portfolioService.AddObjectAsync(portfolio);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            if (String.IsNullOrEmpty(id.ToString())) return BadRequest();

            var article = await portfolioService.GetObjectByIdAsync(id);
            portfolioService.RemoveObject(article);
            return Ok();
        }
    }
}
