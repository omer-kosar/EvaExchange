using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Share
{
    public record ShareForUpdateDto
    {
        public string Symbol { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal LatestPrice { get; set; }
        public IEnumerable<SharePriceForCreationDto> SharePrices { get; set; }
    }
}
