using Biss.DailyCashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biss.DailyCashFlow.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }

        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entry>()
                .Property(e => e.Description).HasMaxLength(120).IsRequired();

            builder.Entity<Entry>()
                .Property(e => e.EntryDate).IsRequired();

            builder.Entity<Entry>()
                .Property(e => e.Value).IsRequired();

        }
    }
}
