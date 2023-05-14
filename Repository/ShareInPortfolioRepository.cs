using Contracts.Repository;
using Entities.Models;
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
    }
}
