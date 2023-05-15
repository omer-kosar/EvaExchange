using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class SharePrice
    {
        public int Id { get; set; }
        public int? ShareId { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset PriceDate { get; set; } = DateTimeOffset.Now;

        public virtual Share? Share { get; set; }
    }
}
