using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Share
{
    public class ShareSummaryForTradeDto
    {
        public int ShareId { get; set; }
        public int BoughtQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public int AvailableQuantityForSell => BoughtQuantity - SoldQuantity;
    }
}
