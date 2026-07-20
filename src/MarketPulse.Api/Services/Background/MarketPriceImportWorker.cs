using MarketPulse.Api.Services;
using MarketPulse.Api.Configuration;
using Microsoft.Extensions.Options;

namespace MarketPulse.Api.Services.Background;

public class MarketPriceImportWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<MarketPriceImportWorker> _logger;

    private readonly TimeSpan _interval;

    public MarketPriceImportWorker(
        IServiceScopeFactory scopeFactory,
        ILogger<MarketPriceImportWorker> logger,
        IOptions<MarketDataOptions> options)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _interval = TimeSpan.FromMinutes(options.Value.ImportIntervalMinutes);
    }


    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "Market price import worker started");


        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();

                var importer = scope
                    .ServiceProvider
                    .GetRequiredService<MarketPriceImportService>();

                var result = await importer.ImportLatestPricesAsync(
                    stoppingToken);


                _logger.LogInformation(
                    "Market price import completed. Imported: {Imported}, Skipped: {Skipped}, Failed: {Failed}",
                    result.Imported,
                    result.Skipped,
                    result.Failed);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Market price import worker failed");
            }


            await Task.Delay(
                _interval,
                stoppingToken);
        }
    }
}