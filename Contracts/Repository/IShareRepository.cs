using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IShareRepository
    {
        void CreateShareAsync(Share share);
        Task<Share> GetShareAsync(int shareId, bool trackChanges);
        Task<List<Share>> GetShareBySymbolAsync(string symbol, bool trackChanges);
        Task<List<Share>> GetAllSharesAsync(bool trackChanges);
    }
}
