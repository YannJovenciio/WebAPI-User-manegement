namespace WebApplication1.Domain.ValueObjects;

public class WeatherSummary
{
    public string Value { get; private set; }

    private static readonly string[] ValidSummaries = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching",
    };

    public WeatherSummary(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Weather summary cannot be null or empty", nameof(value));

        if (!ValidSummaries.Contains(value))
            throw new ArgumentException($"Invalid weather summary: {value}", nameof(value));

        Value = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WeatherSummary other && Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static implicit operator WeatherSummary(string value)
    {
        return new WeatherSummary(value);
    }

    public static implicit operator string(WeatherSummary summary)
    {
        return summary.Value;
    }

    public static WeatherSummary GetRandomSummary()
    {
        var randomIndex = Random.Shared.Next(ValidSummaries.Length);
        return new WeatherSummary(ValidSummaries[randomIndex]);
    }
}
