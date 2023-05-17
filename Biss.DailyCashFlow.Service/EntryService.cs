using Biss.DailyCashFlow.Data.Interface;
using Biss.DailyCashFlow.Domain.Entities;
using Biss.DailyCashFlow.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biss.DailyCashFlow.Service
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task AddEntryAsync(Entry entity)
        {
            if (string.IsNullOrEmpty(entity.Description))
            {
                throw new ArgumentException("A descrição do lançamento é obrigatória.");
            }

            if (entity.Value == 0)
            {
                throw new ArgumentException("O valor do lançamento deve ser informado.");
            }

            entity.Id = Guid.NewGuid();

            await _entryRepository.AddEntryAsync(entity);
        }

    }

}
