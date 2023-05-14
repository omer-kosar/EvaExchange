using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface ITradeRepository
    {
        void CreateTradeAsync(Trade trade);
        Task<List<Trade>> GetAllTradesByUserIdShareId(int userId, int shareId, bool trackChanges);
        Task<List<Trade>> GetAllSoldTradesByUserIdShareId(int userId, int shareId, bool trackChanges);
        Task<List<Trade>> GetAllBoughtTradesByUserIdShareId(int userId, int shareId, bool trackChanges);
    }
}
