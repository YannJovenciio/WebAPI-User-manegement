using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Repositories;
using WebApplication1.Domain.ValueObjects;

namespace WebApplication1.Infrastructure.Repositories;

public class InMemoryWeatherForecastRepository : IWeatherForecastRepository
{
    private readonly List<WeatherForecast> _forecasts;

    public InMemoryWeatherForecastRepository()
    {
        _forecasts = new List<WeatherForecast>();
    }

    public Task<IEnumerable<WeatherForecast>> GetForecastsAsync(int days = 5)
    {
        // Gera previsões se não existirem
        if (_forecasts.Count == 0)
        {
            GenerateForecasts(days);
        }

        var result = _forecasts
            .Where(f => f.Date >= DateOnly.FromDateTime(DateTime.Now))
            .Take(days)
            .OrderBy(f => f.Date)
            .AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<WeatherForecast?> GetForecastByDateAsync(DateOnly date)
    {
        var forecast = _forecasts.FirstOrDefault(f => f.Date == date);
        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast> CreateForecastAsync(WeatherForecast forecast)
    {
        if (forecast == null)
            throw new ArgumentNullException(nameof(forecast));

        _forecasts.Add(forecast);
        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast> UpdateForecastAsync(WeatherForecast forecast)
    {
        if (forecast == null)
            throw new ArgumentNullException(nameof(forecast));

        var existingForecast = _forecasts.FirstOrDefault(f => f.Date == forecast.Date);
        if (existingForecast != null)
        {
            _forecasts.Remove(existingForecast);
        }

        _forecasts.Add(forecast);
        return Task.FromResult(forecast);
    }

    public Task<bool> DeleteForecastAsync(DateOnly date)
    {
        var forecast = _forecasts.FirstOrDefault(f => f.Date == date);
        if (forecast != null)
        {
            _forecasts.Remove(forecast);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    private void GenerateForecasts(int days)
    {
        for (int i = 1; i <= days; i++)
        {
            var forecast = new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                new Temperature(Random.Shared.Next(-20, 55)),
                WeatherSummary.GetRandomSummary()
            );

            _forecasts.Add(forecast);
        }
    }
}
