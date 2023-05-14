using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Trade
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ShareId { get; set; }
        public int TradeType { get; set; }
        public int Quantity { get; set; }
        public decimal TradePrice { get; set; }
        public DateTime TradeDate { get; set; } = DateTime.Now;

        public virtual Share? Share { get; set; }
        public virtual EvaUser? User { get; set; }
    }
}
