using Biss.DailyCashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biss.DailyCashFlow.Service.Interface
{
    public interface IBalanceService
    {
        Task<Balance> GetBalanceAsync(DateTime dateTime);
    }
}
