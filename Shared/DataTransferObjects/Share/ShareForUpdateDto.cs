using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Share
{
    public record ShareForUpdateDto
    {
        [Required(ErrorMessage = "Symbol is a required field.")]
        [MaxLength(3, ErrorMessage = "Maximum length for thse Symbol is 3 chracters.")]
        public string Symbol { get; set; } = null!;
        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for thse Description is 50 chracters.")]
        public string Description { get; set; } = null!;
        public decimal LatestPrice { get; set; }
        public IEnumerable<SharePriceForCreationDto> SharePrices { get; set; }
    }
}
