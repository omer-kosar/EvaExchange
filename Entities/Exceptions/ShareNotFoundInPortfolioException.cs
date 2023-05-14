using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ShareNotFoundInPortfolioException : NotFoundException
    {
        public ShareNotFoundInPortfolioException(int portfolioId, int shareId) : base($"The share with id:{shareId} does not exist in portfolio wiht id{portfolioId}.")
        {

        }
    }
}
