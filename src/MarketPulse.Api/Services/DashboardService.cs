using MarketPulse.Api.DTOs.Dashboard;
using MarketPulse.Api.Services.Monitoring;


namespace MarketPulse.Api.Services;

public class DashboardService
{
    private readonly DashboardOverviewService _overview;
    private readonly SystemStatusService _systemStatus;
    private readonly MarketSessionService _marketStatus;

    public DashboardService(DashboardOverviewService overview, SystemStatusService systemStatus, MarketSessionService marketStatus)
    {
        _overview = overview;
        _systemStatus = systemStatus;
        _marketStatus = marketStatus;
    }

    public async Task<DashboardResponse> GetDashboardAsync(
        CancellationToken cancellationToken = default)
    {
        var overview = await _overview.GetOverviewAsync(cancellationToken);

        return new DashboardResponse
        {
            SystemStatus = _systemStatus.GetStatus(),
            MarketStatus = _marketStatus.GetStatus(),
            Overview = overview
        };
    }           
}