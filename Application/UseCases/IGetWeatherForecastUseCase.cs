using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.UseCases;

public interface IGetWeatherForecastUseCase
{
    Task<IEnumerable<WeatherForecastDto>> ExecuteAsync(int days = 5);
}
