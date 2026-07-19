
using MarketPulse.Api.Data;
using MarketPulse.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MarketPulse.Api.Services;

public class MarketPriceService
{
    private readonly AppDbContext _context;

    public MarketPriceService(AppDbContext context)
    {
        _context = context;
    }

    // Retrieves the latest market price for a given financial instrument ticker.
    public async Task<MarketPriceDto?> GetLatestAsync(string ticker)
    {
        ticker = ticker.Trim().ToUpperInvariant();

        return await _context.MarketPrices
            .AsNoTracking()
            .Where(p => p.FinancialInstrument.Ticker == ticker)
            .OrderByDescending(p => p.TimestampUtc)
            .Select(p => new MarketPriceDto
            {
                TimestampUtc = p.TimestampUtc,
                ClosePrice = p.ClosePrice
            })
            .FirstOrDefaultAsync();
    }
}