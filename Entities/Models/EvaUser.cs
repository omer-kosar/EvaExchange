using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class EvaUser
    {
        public EvaUser()
        {
            Portfolios = new HashSet<Portfolio>();
            Trades = new HashSet<Trade>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
