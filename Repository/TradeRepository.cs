using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.Share;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TradeRepository : BaseRepository<Trade>, ITradeRepository
    {
        public TradeRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }

        public void CreateTradeAsync(Trade trade) => Create(trade);



        public async Task<List<Trade>> GetAllTradesByUserIdShareId(int userId, int shareId, bool trackChanges) =>
            await FindByCondition(trade => trade.UserId == userId && trade.ShareId == shareId, trackChanges).ToListAsync();
     
        public async Task<ShareSummaryForTradeDto> GetShareSummaryForTradeSelling(int userId, int shareId, bool trackChanges)
        {
            var trades = FindByCondition(trade => trade.UserId == userId && trade.ShareId == shareId, trackChanges);
            var boughtTrades = GetBoughtTrades(trades);
            var soldTrades = GetSoldTrades(trades);
            var allTrades = boughtTrades.Concat(soldTrades);
            var result = await allTrades.GroupBy(t => t.ShareId).Select(t => new ShareSummaryForTradeDto { ShareId = t.Key, BoughtQuantity = t.Sum(i => i.BoughtQuantity), SoldQuantity = t.Sum(i => i.SoldQuantity) }).FirstOrDefaultAsync();
            return result;
        }
        private IQueryable<ShareSummaryForTradeDto> GetBoughtTrades(IQueryable<Trade> trades)
        {
            var boughtTrades = trades.Where(i => i.TradeType == (int)TradeType.BUY).GroupBy(t => t.ShareId).Select(t => new ShareSummaryForTradeDto
            {
                ShareId = t.Key.Value,
                BoughtQuantity = t.Sum(i => i.Quantity),
                SoldQuantity = 0
            });
            return boughtTrades;
        }
        private IQueryable<ShareSummaryForTradeDto> GetSoldTrades(IQueryable<Trade> trades)
        {
            var boughtTrades = trades.Where(i => i.TradeType == (int)TradeType.SELL).GroupBy(t => t.ShareId).Select(t => new ShareSummaryForTradeDto
            {
                ShareId = t.Key.Value,
                SoldQuantity = t.Sum(i => i.Quantity),
                BoughtQuantity = 0
            });
            return boughtTrades;
        }
    }
}
