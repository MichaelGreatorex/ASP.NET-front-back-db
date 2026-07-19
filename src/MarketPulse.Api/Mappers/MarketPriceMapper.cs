using MarketPulse.Api.DTOs.Finnhub;
using MarketPulse.Api.Models;

namespace MarketPulse.Api.Mappers;

public static class MarketPriceMapper
{
    public static MarketPrice ToMarketPrice(
        FinnhubQuoteResponse quote,
        Guid instrumentId)
    {
        return new MarketPrice
        {
            Id = Guid.NewGuid(),
            FinancialInstrumentId = instrumentId,
            TimestampUtc = DateTimeOffset
                .FromUnixTimeSeconds(quote.UnixTimestamp)
                .UtcDateTime,
            ClosePrice = quote.CurrentPrice
        };
    }
}
