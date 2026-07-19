namespace MarketPulse.Api.Models;

public class MarketPrice
{
    public Guid Id { get; set; }

    public Guid FinancialInstrumentId { get; set; }

    public FinancialInstrument FinancialInstrument { get; set; } = null!;

    public DateTime TimestampUtc { get; set; }

    public decimal ClosePrice { get; set; }
}