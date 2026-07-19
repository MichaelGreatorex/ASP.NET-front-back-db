using System.Text.Json.Serialization;

namespace MarketPulse.Api.DTOs.Finnhub;

public class FinnhubQuoteResponse
{
    [JsonPropertyName("c")]
    public decimal CurrentPrice { get; init; }

    [JsonPropertyName("t")]
    public long UnixTimestamp { get; init; }
}