using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            ShareInPortfolios = new HashSet<ShareInPortfolio>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string PortfolioName { get; set; } = null!;

        public virtual EvaUser User { get; set; } = null!;
        public virtual ICollection<ShareInPortfolio> ShareInPortfolios { get; set; }
    }
}
