namespace MarketPulse.Api.Models;

public class FinancialInstrument
{
    public Guid Id { get; set; }

    public string Ticker { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Exchange { get; set; } = string.Empty;

    public string Currency { get; set; } = "USD";

    public bool IsActive { get; set; } = true;

    public ICollection<MarketPrice> Prices { get; set; }
    = new List<MarketPrice>();
}



