using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Portfolio;
using Shared.DataTransferObjects.Share;
using Shared.DataTransferObjects.Trade;

namespace EvaExchange.API.Controllers
{
    [Route("api/portfolios")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PortfoliosController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id:int}", Name = "PortfolioById")]
        public async Task<IActionResult> GetPortfolio(int id)
        {
            var portfolioDto = _serviceManager.PortfolioService.GetPortfolioAsync(id, false);
            return Ok(portfolioDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio([FromBody] PortfolioForCreationDto portfolio)
        {
            var createdPortfolio = await _serviceManager.PortfolioService.CreatePortfolioAsync(portfolio);
            return CreatedAtRoute("PortfolioById", new { id = createdPortfolio.Id }, createdPortfolio);
        }

        [HttpPost("BuyShare")]
        public async Task<IActionResult> BuyShare(TradeDto trade)
        {
            await _serviceManager.PortfolioService.BuyShare(trade, true);
            return NoContent();
        }
        [HttpPost("SellShare")]
        public async Task<IActionResult> SellShare(TradeDto trade)
        {
            await _serviceManager.PortfolioService.SellShare(trade, true);
            return NoContent();
        }
    }
}
