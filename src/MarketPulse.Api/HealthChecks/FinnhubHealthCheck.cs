using MarketPulse.Api.Clients;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MarketPulse.Api.HealthChecks;

public class FinnhubHealthCheck : IHealthCheck
{
    private readonly IMarketDataClient _client;

    public FinnhubHealthCheck(IMarketDataClient client)
    {
        _client = client;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var quote = await _client.GetQuoteAsync(
                "AAPL",
                cancellationToken);

            if (quote is null)
            {
                return HealthCheckResult.Unhealthy(
                    "Finnhub returned no data.");
            }

            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(
                "Unable to contact Finnhub.",
                ex);
        }
    }
}