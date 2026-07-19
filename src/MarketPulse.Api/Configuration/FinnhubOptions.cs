namespace MarketPulse.Api.Configuration;

public class FinnhubOptions
{
    public const string SectionName = "Finnhub";

    public string BaseUrl { get; init; } = "";

    public string ApiKey { get; init; } = "";
}
