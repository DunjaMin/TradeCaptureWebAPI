using Microsoft.EntityFrameworkCore;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI.Models
{
    public class TradeCaptureContext: DbContext
    {
        public TradeCaptureContext(DbContextOptions<TradeCaptureContext> options)
                : base(options)
        {
        }

        public DbSet<Security> Security { get; set; } = null!;
        public DbSet<Option> Option { get; set; } = default!;
        public DbSet<SecurityType> SecurityType { get; set; } = null!;
        public DbSet<Exchange> Exchange { get; set; } = null!;
        public DbSet<Currency> Currency { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>()
            .ToTable(tb => tb.HasTrigger("OptionTrigger1"));

            modelBuilder.Entity<Security>()
            .ToTable(tb => tb.HasTrigger("SecurityTrigger1"));

        }
        }
}
