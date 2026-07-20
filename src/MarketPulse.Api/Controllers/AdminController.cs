using MarketPulse.Api.Models.Imports;
using MarketPulse.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPulse.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly MarketPriceImportService _importService;

    public AdminController(
        MarketPriceImportService importService)
    {
        _importService = importService;
    }

    /// <summary>
    /// Manually triggers a market price import.
    /// </summary>
    /// <remarks>
    /// Intended for development and testing.
    /// Production imports are handled automatically by the background worker.
    /// </remarks>
    /// 
    [ProducesResponseType(typeof(ImportResult), StatusCodes.Status200OK)]

    [HttpPost("import-prices")]
    public async Task<ActionResult<ImportResult>> ImportPrices(
        CancellationToken cancellationToken)
    {
        var imported = await _importService
            .ImportLatestPricesAsync(cancellationToken);

        return Ok(imported);
    }
}