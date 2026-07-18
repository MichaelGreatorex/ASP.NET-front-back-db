using MarketPulse.Api.DTOs;
using MarketPulse.Api.Models.Pagination;
using MarketPulse.Api.Models.Queries;
using MarketPulse.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialInstrumentsController : ControllerBase
{
    private readonly FinancialInstrumentService _financialInstrumentService;

    public FinancialInstrumentsController(
        FinancialInstrumentService financialInstrumentService)
    {
        _financialInstrumentService = financialInstrumentService;
    }


    [HttpGet]
    public async Task<ActionResult<PagedResult<FinancialInstrumentDto>>> Get(
        [FromQuery] FinancialInstrumentQuery query)
    {
        var result = await _financialInstrumentService.GetAllAsync(query);

        return Ok(result);
    }

    [HttpGet("{ticker}")]
    public async Task<ActionResult<FinancialInstrumentDto>> GetByTicker(string ticker)
    {
        var instrument = await _financialInstrumentService.GetByTickerAsync(ticker);

        if (instrument is null)
        {
            return NotFound();
        }

        return Ok(instrument);
    }

}