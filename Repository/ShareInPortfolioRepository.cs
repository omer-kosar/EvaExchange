using Contracts.Repository;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShareInPortfolioRepository : BaseRepository<ShareInPortfolio>, IShareInPortfolioRepository
    {
        public ShareInPortfolioRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }

        public void CreateShareInPortfolioAsync(ShareInPortfolio shareInPortfolio) => Create(shareInPortfolio);

        public void DeleteShareInPortfolio(ShareInPortfolio shareInPortfolio) => Delete(shareInPortfolio);

        public async Task<ShareInPortfolio> GetShareInPortfolioByShareIdAsync(int portfolioId, int shareId, bool trackChanges) =>
            await FindByCondition(shareInPortfolio => shareInPortfolio.PortfolioId == portfolioId && shareInPortfolio.ShareId == shareId, trackChanges).SingleOrDefaultAsync();
    }
}
