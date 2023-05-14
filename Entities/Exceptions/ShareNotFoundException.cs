using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ShareNotFoundException : NotFoundException
    {
        public ShareNotFoundException(int shareId) : base($"The share with id:{shareId} does not exist.")
        {

        }
    }
}
