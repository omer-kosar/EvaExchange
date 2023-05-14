using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PortfolioNotFoundException : NotFoundException
    {
        public PortfolioNotFoundException(int portfolioId) : base($"The portfolio wiht {portfolioId} does not exist!")
        {

        }
    }
}
