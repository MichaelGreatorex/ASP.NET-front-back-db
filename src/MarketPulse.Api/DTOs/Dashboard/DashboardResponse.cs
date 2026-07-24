using MarketPulse.Api.Dtos;

namespace MarketPulse.Api.DTOs.Dashboard;

public class DashboardResponse
{
    public DashboardOverviewDto Overview { get; set; } = new();

    public SystemStatusDto SystemStatus { get; set; } = new();

    public MarketStatusDto MarketStatus { get; set; } = new();
}