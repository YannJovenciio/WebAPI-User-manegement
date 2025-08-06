using WebApplication1.Domain.ValueObjects;

namespace WebApplication1.Domain.Entities;

public class WeatherForecast
{
    public DateOnly Date { get; private set; }
    public Temperature Temperature { get; private set; }
    public WeatherSummary Summary { get; private set; }

    public WeatherForecast(DateOnly date, Temperature temperature, WeatherSummary summary)
    {
        Date = date;
        Temperature = temperature ?? throw new ArgumentNullException(nameof(temperature));
        Summary = summary ?? throw new ArgumentNullException(nameof(summary));
    }

    // Para compatibilidade com a API atual
    public int TemperatureC => Temperature.Celsius;
    public int TemperatureF => Temperature.Fahrenheit;
}
