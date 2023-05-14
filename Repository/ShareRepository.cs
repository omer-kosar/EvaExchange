using Contracts.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShareRepository:BaseRepository<Share>,IShareRepository
    {
        public ShareRepository(EvaExchangeContext evaExchangeContext):base(evaExchangeContext)
        {

        }

        public void CreateShare(Share share) => Create(share);
    }
}
