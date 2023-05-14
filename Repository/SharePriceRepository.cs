using Contracts.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SharePriceRepository : BaseRepository<SharePrice>, ISharePriceRepository
    {
        public SharePriceRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }

        public void CreateSharePrice(SharePrice sharePrice) => Create(sharePrice);
    }
}
