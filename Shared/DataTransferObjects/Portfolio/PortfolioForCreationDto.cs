using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Portfolio
{
    public record PortfolioForCreationDto
    {
        [Required(ErrorMessage ="UserId is required field.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "PortfolioName is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for thse PortfolioName is 50 chracters.")]
        public string PortfolioName { get; set; } = null!;
    }
}
