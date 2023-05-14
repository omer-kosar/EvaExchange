﻿using Contracts.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ShareRepository : BaseRepository<Share>, IShareRepository
    {
        public ShareRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }

        public void CreateShare(Share share) => Create(share);

        public async Task<Share> GetShareAsync(int shareId, bool trackChanges) => await FindByCondition(share => share.Id == shareId, trackChanges)?.SingleOrDefaultAsync();

        public async Task<List<Share>> GetShareBySymbolAsync(string symbol, bool trackChanges) => await FindByCondition(share => share.Symbol.Equals(symbol), trackChanges).ToListAsync();
    }
}
