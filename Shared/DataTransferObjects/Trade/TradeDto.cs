using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Trade
{
    public class TradeDto
    {
        public int PortfolioId { get; set; }
        public int UserId { get; set; }
        public int ShareId { get; set; }
        public int Quantity { get; set; }
    }
}
