using Contracts.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SharePriceRepository : BaseRepository<SharePrice>, ISharePriceRepository
    {
        public SharePriceRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }

        public void CreateSharePriceAsync(SharePrice sharePrice) => Create(sharePrice);

        public async Task<List<SharePrice>> GetAllSharePricesByShareIdAsync(int shareId, bool trackChanges)
        {
            var sharePrices=await FindByCondition(sharePrice=>sharePrice.ShareId==shareId,trackChanges).OrderBy(sharePrice=>sharePrice.PriceDate).ToListAsync();
            return sharePrices;
        }

        public async Task<SharePrice> GetLatestSharePriceByShareIdAsync(int shareId, bool trackChanges)
        {
            var sharePrices = await GetAllSharePricesByShareIdAsync(shareId, trackChanges);
            return sharePrices.Last();
        }
    }
}
