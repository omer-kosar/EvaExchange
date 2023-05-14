using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Share
{
    public record ShareDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal LatestPrice { get; set; }
    }
}
