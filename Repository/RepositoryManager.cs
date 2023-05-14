using Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly EvaExchangeContext _evaExchangeContext;
        private readonly Lazy<IEvaUserRepository> _userRepository;
        private readonly Lazy<IPortfolioRepository> _portfolioRepository;
        private readonly Lazy<IShareInPortfolioRepository> _shareInPortfolioRepository;
        private readonly Lazy<ISharePriceRepository> _sharePriceRepository;
        private readonly Lazy<IShareRepository> _shareRepository;
        private readonly Lazy<ITradeRepository> _tradeRepository;

        public RepositoryManager(EvaExchangeContext evaExchangeContext)
        {
            _evaExchangeContext = evaExchangeContext;
            _userRepository = new Lazy<IEvaUserRepository>(() => new EvaUserRepository(evaExchangeContext));
            _portfolioRepository = new Lazy<IPortfolioRepository>(() => new PortfolioRepository(evaExchangeContext));
            _shareInPortfolioRepository = new Lazy<IShareInPortfolioRepository>(() => new ShareInPortfolioRepository(evaExchangeContext));
            _sharePriceRepository = new Lazy<ISharePriceRepository>(() => new SharePriceRepository(evaExchangeContext));
            _tradeRepository = new Lazy<ITradeRepository>(() => new TradeRepository(evaExchangeContext));
        }

        public IEvaUserRepository Users => _userRepository.Value;

        public IPortfolioRepository Portfolio => _portfolioRepository.Value;

        public IShareInPortfolioRepository ShareInPortfolioRepository => _shareInPortfolioRepository.Value;

        public ISharePriceRepository SharePrice => _sharePriceRepository.Value;

        public IShareRepository Share => _shareRepository.Value;

        public ITradeRepository Trade => _tradeRepository.Value;

        public void Save()=>_evaExchangeContext.SaveChanges();

        public Task SaveAsync() => _evaExchangeContext.SaveChangesAsync();
    }
}
