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
    public DbSet<MarketPrice> MarketPrices => Set<MarketPrice>();

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

        modelBuilder.Entity<MarketPrice>().ToTable("MarketPrices");

        modelBuilder.Entity<MarketPrice>()
            .HasOne(mp => mp.FinancialInstrument)
            .WithMany(fi => fi.Prices)
            .HasForeignKey(mp => mp.FinancialInstrumentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MarketPrice>().HasData(

        // Apple
        new MarketPrice
        {
            Id = Guid.Parse("568d3499-2337-4dfa-9edc-cdf202d3f901"),
            FinancialInstrumentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            TimestampUtc = new DateTime(2026, 7, 16, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 212.43m
        },
        new MarketPrice
        {
            Id = Guid.Parse("568d3499-2337-4dfa-9edc-cdf202d3f902"),
            FinancialInstrumentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            TimestampUtc = new DateTime(2026, 7, 17, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 214.10m
        },
        new MarketPrice
        {
            Id = Guid.Parse("568d3499-2337-4dfa-9edc-cdf202d3f903"),
            FinancialInstrumentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            TimestampUtc = new DateTime(2026, 7, 18, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 215.87m
        },

        // Microsoft
        new MarketPrice
        {
            Id = Guid.Parse("ebfcf39f-b825-46cf-bb43-3bb687a52341"),
            FinancialInstrumentId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            TimestampUtc = new DateTime(2026, 7, 16, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 501.22m
        },
        new MarketPrice
        {
            Id = Guid.Parse("ebfcf39f-b825-46cf-bb43-3bb687a52342"),
            FinancialInstrumentId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            TimestampUtc = new DateTime(2026, 7, 17, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 503.15m
        },
        new MarketPrice
        {
            Id = Guid.Parse("ebfcf39f-b825-46cf-bb43-3bb687a52343"),
            FinancialInstrumentId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            TimestampUtc = new DateTime(2026, 7, 18, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 505.61m
        },

        // NVIDIA
        new MarketPrice
        {
            Id = Guid.Parse("3039f58b-557f-4a25-a3df-c2eebdb554a1"),
            FinancialInstrumentId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            TimestampUtc = new DateTime(2026, 7, 16, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 173.45m
        },
        new MarketPrice
        {
            Id = Guid.Parse("3039f58b-557f-4a25-a3df-c2eebdb554a2"),
            FinancialInstrumentId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            TimestampUtc = new DateTime(2026, 7, 17, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 176.92m
        },
        new MarketPrice
        {
            Id = Guid.Parse("3039f58b-557f-4a25-a3df-c2eebdb554a3"),
            FinancialInstrumentId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            TimestampUtc = new DateTime(2026, 7, 18, 21, 0, 0, DateTimeKind.Utc),
            ClosePrice = 179.84m
        }
    );
    }

}

               