﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IEvaUserRepository
    {
        Task<EvaUser> GetUserAsync(int userId, bool trackChanges);
    }
}
