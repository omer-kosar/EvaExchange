using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Share
    {
        public Share()
        {
            ShareInPortfolios = new HashSet<ShareInPortfolio>();
            SharePrices = new HashSet<SharePrice>();
            Trades = new HashSet<Trade>();
        }

        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<ShareInPortfolio> ShareInPortfolios { get; set; }
        public virtual ICollection<SharePrice> SharePrices { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
