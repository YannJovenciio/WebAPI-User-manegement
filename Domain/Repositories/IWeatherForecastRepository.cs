using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync(int days = 5);
    Task<WeatherForecast?> GetForecastByDateAsync(DateOnly date);
    Task<WeatherForecast> CreateForecastAsync(WeatherForecast forecast);
    Task<WeatherForecast> UpdateForecastAsync(WeatherForecast forecast);
    Task<bool> DeleteForecastAsync(DateOnly date);
}
