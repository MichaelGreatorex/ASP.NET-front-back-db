using Api.Data;
using Api.DTOs;
using Api.Interfaces;

namespace Api.Services;

public class HealthService : IHealthService
{
    private readonly AppDbContext _context;

    public HealthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HealthResponseDto> GetHealthAsync()
    {
        throw new NotImplementedException();
    }
}