﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AvailabeShareDoesNotExistForSellingBadRequest : BadRequestException
    {
        public AvailabeShareDoesNotExistForSellingBadRequest() : base("The number of shares is not sufficient!")
        {

        }
    }
}
