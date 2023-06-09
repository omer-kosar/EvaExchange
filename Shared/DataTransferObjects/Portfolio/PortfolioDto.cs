﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Portfolio
{
    public record PortfolioDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string PortfolioName { get; set; } = null!;
    }
}
