using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SharePriceForCreationDto
    {
        public int ShareId { get; set; }
        public decimal Price { get; set; }
        public DateTime PriceDate { get; set; } = DateTime.Now;
    }
}
