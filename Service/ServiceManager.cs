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
        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _shareService=new Lazy<IShareService>(()=>new ShareService(repositoryManager,mapper));  
        }

        public IShareService ShareService => _shareService.Value;
    }
}
