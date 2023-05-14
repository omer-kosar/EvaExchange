using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Share
{
    public class ShareSummaryForTradeDto
    {
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public decimal Balance { get; set; }
    }
}
