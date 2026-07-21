namespace MarketPulse.Api.DTOs.Dashboard;

public class DashboardResponse
{
    public string Status { get; init; } = "Healthy";

    public int TrackedInstruments { get; init; }

    public int MarketPrices { get; init; }

    public DateTime? LastImportUtc { get; init; }

    public List<DashboardInstrument> Instruments { get; init; } = [];
}