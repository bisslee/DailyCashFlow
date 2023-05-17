using Biss.DailyCashFlow.Data.Interface;
using Biss.DailyCashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biss.DailyCashFlow.Data.Repository
{
    public class EntryRepository : IEntryRepository
    {
        private readonly DataContext _dataContext;

        public EntryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddEntryAsync(Entry entry)
        {
            await _dataContext.Entries.AddAsync(entry);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Entry>> ListEntryAsync(DateTime dateTime)
        {
            var entities = await _dataContext.Entries
                            .Where(e => e.EntryDate.Year == dateTime.Year 
                                     && e.EntryDate.Month == dateTime.Month
                                     && e.EntryDate.Day == dateTime.Day)
                            .ToListAsync();

            return entities;
        }
    }

}
