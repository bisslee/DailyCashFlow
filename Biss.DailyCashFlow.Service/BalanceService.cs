using Biss.DailyCashFlow.Data.Interface;
using Biss.DailyCashFlow.Domain.Entities;
using Biss.DailyCashFlow.Service.Interface;

namespace Biss.DailyCashFlow.Service
{
    public class BalanceService : IBalanceService
    {
        private readonly IEntryRepository _entryRepository;

        public BalanceService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<Balance> GetBalanceAsync(DateTime dateTime)
        {
            var entries = await _entryRepository.ListEntryAsync(dateTime);
            var balance = new Balance()
            {
                EntryDate = dateTime,
                Value = entries.Sum(e => e.Value)
            };

            return balance;
        }
    }

}
