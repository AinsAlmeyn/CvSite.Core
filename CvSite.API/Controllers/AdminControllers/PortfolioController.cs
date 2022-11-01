using CvSite.Core.Entities;
using CvSite.Core.Services;
using CvSite.Services.ServiceCon;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvSite.API.Controllers.AdminControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPortfolioService portfolioService;
        public PortfolioController(IPortfolioService portfolioService, ILogger logger)
        {
            this.portfolioService = portfolioService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id.ToString() == null)
                {
                    _logger.LogWarning($"Portfolio/GetById icin id null dondu");
                    return BadRequest();
                }
                else
                {
                    var article = await portfolioService.GetObjectByIdAsync(id);
                    _logger.LogInformation($"Portfolio/GetById icin nesne basarili sekilde donduruldu. Response = {article.Id}");
                    return Ok(article);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult PortfolioUpdate(Portfolio portfolio)
        {
            try
            {

                if (portfolio == null) {_logger.LogWarning($"Portfolio/PortfolioUpdate icin portfolio nesnesi null geldi") ; return BadRequest(); }
                else
                {
                    portfolioService.UpdateObject(portfolio);
                    _logger.LogInformation($"Portfolio/PortfolioUpdate icin portfolio update edildi. Response = {portfolio.Id}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> PortfolioAdd(Portfolio portfolio)
        {
            try
            {

                if (portfolio == null) {_logger.LogWarning($"Portfolio/PortfolioAdd icin portfolio nesnesi null geldi.") ; return BadRequest();}
                else
                {
                    await portfolioService.AddObjectAsync(portfolio);
                    _logger.LogInformation($"Portfolio/PortfolioAdd icin ekleme islemi basarili. Response = {portfolio.Id},{portfolio.Title}");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetByIdDelete(int id)
        {
            try
            {

                if (String.IsNullOrEmpty(id.ToString())) {_logger.LogWarning($"Portfolio/GetByIdDelete icin id null geldi.") ; return BadRequest(); }
                else
                {
                    var article = await portfolioService.GetObjectByIdAsync(id);
                    portfolioService.RemoveObject(article);
                    _logger.LogInformation($"Portfolio/GetByIdDelete icin islem basarili. Response = {article.Title}, {article.Id}");
                    return Ok();
                }
            }
            catch (Exception E)
            {
                _logger.LogError(E.Message);
                return BadRequest();
            }
        }
    }
}
