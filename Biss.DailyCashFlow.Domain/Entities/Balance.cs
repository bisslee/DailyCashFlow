using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biss.DailyCashFlow.Domain.Entities
{
    public class Balance
    {
        public float Value { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
