using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepositoryManager
    {
        IEvaUserRepository Users { get; }
        IPortfolioRepository Portfolio { get; }
        IShareInPortfolioRepository ShareInPortfolioRepository { get; }
        ISharePriceRepository SharePrice { get; }
        IShareRepository Share { get; }
        ITradeRepository Trade { get; }
        void Save();
        Task SaveAsync();
    }
}
