using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ShareExistWithTheSameSymbolBadRequestException : BadRequestException
    {
        public ShareExistWithTheSameSymbolBadRequestException() : base($"Share exists with the same symbol. Share was not able to save!")
        {

        }
    }
}
