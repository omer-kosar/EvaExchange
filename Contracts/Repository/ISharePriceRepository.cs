using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface ISharePriceRepository
    {
        Task<List<SharePrice>> GetAllSharePricesByShareIdAsync(int shareId, bool trackChanges);
        Task<SharePrice> GetLatestSharePriceByShareIdAsync(int shareId, bool trackChanges);
        void CreateSharePriceAsync(SharePrice sharePrice);
    }
}
