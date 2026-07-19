using MarketPulse.Api.DTOs.Finnhub;

namespace MarketPulse.Api.Clients;

public interface IMarketDataClient
{
    Task<FinnhubQuoteResponse?> GetQuoteAsync(
        string ticker,
        CancellationToken cancellationToken = default);
}