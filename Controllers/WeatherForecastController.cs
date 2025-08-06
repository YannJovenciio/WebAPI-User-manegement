using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.UseCases;
using WebApplication1.WebApi.DTOs;

namespace WebApplication1.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IGetWeatherForecastUseCase _getWeatherForecastUseCase;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IGetWeatherForecastUseCase getWeatherForecastUseCase
    )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _getWeatherForecastUseCase =
            getWeatherForecastUseCase
            ?? throw new ArgumentNullException(nameof(getWeatherForecastUseCase));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<WeatherForecastResponse>>> Get(
        [FromQuery] int days = 5
    )
    {
        try
        {
            _logger.LogInformation("Getting weather forecast for {Days} days", days);

            var forecasts = await _getWeatherForecastUseCase.ExecuteAsync(days);

            var response = forecasts.Select(f => new WeatherForecastResponse
            {
                Date = f.Date,
                TemperatureC = f.TemperatureC,
                TemperatureF = f.TemperatureF,
                Summary = f.Summary,
            });

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting weather forecast");
            return StatusCode(500, "Internal server error");
        }
    }
}
