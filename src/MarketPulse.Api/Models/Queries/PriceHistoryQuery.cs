using MarketPulse.Api.Models.Pagination;

namespace MarketPulse.Api.Models.Queries;

public class PriceHistoryQuery : PaginationQuery
{
    public DateTime? From { get; init; }

    public DateTime? To { get; init; }
}