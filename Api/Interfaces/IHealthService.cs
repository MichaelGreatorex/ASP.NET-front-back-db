using Api.DTOs;

namespace Api.Interfaces;

public interface IHealthService
{
    Task<HealthResponseDto> GetHealthAsync();
}