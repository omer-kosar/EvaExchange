using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using System;
using System.Collections.Generic;
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
        public async Task<List<Trade>> GetAllBoughtTradesByUserIdShareId(int userId, int shareId, bool trackChanges)
        {
            var trades = await GetAllTradesByUserIdShareId(userId, shareId, trackChanges);
            trades.Where(i => i.TradeType == (int)TradeType.BUY);
            return trades.ToList();
        }
        public Task<List<Trade>> GetAllSoldTradesByUserIdShareId(int userId, int shareId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
