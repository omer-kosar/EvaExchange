using AutoMapper;
using Contracts.Repository;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IShareService> _shareService;
        private readonly Lazy<IPortfolioService> _portfolioService;
        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _shareService=new Lazy<IShareService>(()=>new ShareService(repositoryManager,mapper));
            _portfolioService = new Lazy<IPortfolioService>(()=>new PortfolioService(repositoryManager,mapper));  
        }

        public IShareService ShareService => _shareService.Value;
        public IPortfolioService PortfolioService => _portfolioService.Value;
    }
}
