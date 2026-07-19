namespace MarketPulse.Api.DTOs;

public class MarketPriceDto
{
    public DateTime TimestampUtc { get; init; }

    public decimal ClosePrice { get; init; }
}
