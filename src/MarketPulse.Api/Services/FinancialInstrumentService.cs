using MarketPulse.Api.Data;
using MarketPulse.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPulse.Api.Services
{
    public class FinancialInstrumentService
    {
        private readonly AppDbContext _context;

        public FinancialInstrumentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FinancialInstrument>> GetAllAsync()
        {
            return await _context.FinancialInstruments
                .OrderBy(i => i.Ticker)
                .ToListAsync();
        }
    }
}
