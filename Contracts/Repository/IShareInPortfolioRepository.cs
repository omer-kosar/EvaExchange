using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IShareInPortfolioRepository
    {
        void CreateShareInPortfolioAsync(ShareInPortfolio shareInPortfolio);
        Task<ShareInPortfolio> GetShareInPortfolioByShareIdAsync(int portfolioId, int shareId, bool trackChanges);
        void DeleteShareInPortfolio(ShareInPortfolio shareInPortfolio);
    }
}
