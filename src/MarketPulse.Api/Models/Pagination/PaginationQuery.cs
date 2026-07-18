using System.ComponentModel.DataAnnotations;

namespace MarketPulse.Api.Models.Pagination;

public class PaginationQuery
{
    private const int MaxPageSize = 100;

    [Range(1, int.MaxValue,
        ErrorMessage = "Page must be greater than zero.")]
    public int Page { get; init; } = 1;

    [Range(1, MaxPageSize,
        ErrorMessage = "PageSize must be between 1 and 100.")]
    public int PageSize { get; init; } = 20;

    public int Skip => (Page - 1) * PageSize;

    public int Take => PageSize;
}