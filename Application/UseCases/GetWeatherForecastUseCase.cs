using WebApplication1.Application.DTOs;
using WebApplication1.Domain.Repositories;

namespace WebApplication1.Application.UseCases;

public class GetWeatherForecastUseCase : IGetWeatherForecastUseCase
{
    private readonly IWeatherForecastRepository _repository;

    public GetWeatherForecastUseCase(IWeatherForecastRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<WeatherForecastDto>> ExecuteAsync(int days = 5)
    {
        var forecasts = await _repository.GetForecastsAsync(days);

        return forecasts.Select(forecast => new WeatherForecastDto
        {
            Date = forecast.Date,
            TemperatureC = forecast.TemperatureC,
            TemperatureF = forecast.TemperatureF,
            Summary = forecast.Summary,
        });
    }
}
