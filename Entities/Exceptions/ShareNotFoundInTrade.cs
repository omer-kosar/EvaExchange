using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ShareNotFoundInTradeException : NotFoundException
    {
        public ShareNotFoundInTradeException(int shareId) : base($"Share does not exist in trade with id:{shareId}")
        {

        }
    }
}
