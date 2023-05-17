using Biss.DailyCashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biss.DailyCashFlow.Data.Interface
{
    public interface IEntryRepository
    {
        Task AddEntryAsync(Entry entry);
        Task<List<Entry>> ListEntryAsync(DateTime dateTime);
    }

}
