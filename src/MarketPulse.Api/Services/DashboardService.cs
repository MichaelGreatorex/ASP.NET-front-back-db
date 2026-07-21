using MarketPulse.Api.Data;
using MarketPulse.Api.DTOs.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace MarketPulse.Api.Services;

public class DashboardService
{
    private readonly AppDbContext _context;

    public DashboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardResponse> GetDashboardAsync(
        CancellationToken cancellationToken = default)
    {
        var trackedInstruments = await _context.FinancialInstruments
            .CountAsync(i => i.IsActive, cancellationToken);

        var marketPrices = await _context.MarketPrices
            .CountAsync(cancellationToken);

        var lastImport = await _context.MarketPrices
            .OrderByDescending(p => p.TimestampUtc)
            .Select(p => (DateTime?)p.TimestampUtc)
            .FirstOrDefaultAsync(cancellationToken);

        var instruments = await _context.FinancialInstruments
            .Where(i => i.IsActive)
            .OrderBy(i => i.Ticker)
            .Select(i => new DashboardInstrument
            {
                Ticker = i.Ticker,
                Name = i.Name,
                Exchange = i.Exchange
            })
            .ToListAsync(cancellationToken);

        return new DashboardResponse
        {
            Status = "Healthy",
            TrackedInstruments = trackedInstruments,
            MarketPrices = marketPrices,
            LastImportUtc = lastImport,
            Instruments = instruments
        };
    }
}