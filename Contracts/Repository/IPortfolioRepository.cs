using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IPortfolioRepository
    {
        void CreatePortfolioAsync(Portfolio portfolio);
        Task<Portfolio> GetPortfolioAsync(int portfolioId, bool trackChanges);

    }
}
