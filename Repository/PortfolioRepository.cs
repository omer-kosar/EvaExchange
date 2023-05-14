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
    public class PortfolioRepository : BaseRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }

        public void CreatePortfolio(Portfolio portfolio) => Create(portfolio);
        public async Task<Portfolio> GetPortfolioAsync(int portfolioId, bool trackChanges) => await FindByCondition(portfolio => portfolio.Id == portfolioId, trackChanges)?.SingleOrDefaultAsync();

    }
}
