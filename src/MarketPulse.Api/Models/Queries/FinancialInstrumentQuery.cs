using MarketPulse.Api.Models.Pagination;

namespace MarketPulse.Api.Models.Queries;

public class FinancialInstrumentQuery : PaginationQuery
{
    public string? Exchange { get; init; }

    public string? Search { get; init; }
}