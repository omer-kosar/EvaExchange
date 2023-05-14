using Contracts.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EvaUserRepository : BaseRepository<EvaUser>, IEvaUserRepository
    {
        public EvaUserRepository(EvaExchangeContext evaExchangeContext) : base(evaExchangeContext)
        {

        }
    }
}
