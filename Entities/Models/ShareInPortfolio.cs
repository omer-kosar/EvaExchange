using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ShareInPortfolio
    {
        public int Id { get; set; }
        public int? PortfolioId { get; set; }
        public int? ShareId { get; set; }
        public int Quantity { get; set; }

        public virtual Portfolio? Portfolio { get; set; }
        public virtual Share? Share { get; set; }
    }
}
