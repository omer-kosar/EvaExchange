using Shared.DataTransferObjects.Portfolio;
using Shared.DataTransferObjects.Share;
using Shared.DataTransferObjects.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPortfolioService
    {
        Task<PortfolioDto> CreatePortfolioAsync(PortfolioForCreationDto portfolio);
        Task<PortfolioDto> GetPortfolioAsync(int id, bool trackChanges);
        Task<ShareSummaryForTradeDto> BuyShare(TradeDto trade, bool trackChanges);
        Task SellShare(TradeDto trade, bool trackChanges);
    }
}
