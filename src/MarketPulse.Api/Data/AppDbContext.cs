using MarketPulse.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPulse.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<FinancialInstrument> FinancialInstruments => Set<FinancialInstrument>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FinancialInstrument>().ToTable("Instruments");

        modelBuilder.Entity<FinancialInstrument>().HasData(
            new FinancialInstrument
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Ticker = "AAPL",
                Name = "Apple Inc.",
                Exchange = "NASDAQ",
                Currency = "USD",
                IsActive = true
            },
            new FinancialInstrument
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Ticker = "MSFT",
                Name = "Microsoft Corporation",
                Exchange = "NASDAQ",
                Currency = "USD",
                IsActive = true
            },
            new FinancialInstrument
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Ticker = "NVDA",
                Name = "NVIDIA Corporation",
                Exchange = "NASDAQ",
                Currency = "USD",
                IsActive = true
            }
        );
    }
}
