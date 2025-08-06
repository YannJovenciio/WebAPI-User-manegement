namespace WebApplication1.Domain.ValueObjects;

public class Temperature
{
    public int Celsius { get; private set; }
    public int Fahrenheit => 32 + (int)(Celsius / 0.5556);

    public Temperature(int celsius)
    {
        if (celsius < -273) // Temperatura absoluta mínima
            throw new ArgumentException(
                "Temperature cannot be below absolute zero",
                nameof(celsius)
            );

        Celsius = celsius;
    }

    public override bool Equals(object? obj)
    {
        return obj is Temperature other && Celsius == other.Celsius;
    }

    public override int GetHashCode()
    {
        return Celsius.GetHashCode();
    }

    public static implicit operator Temperature(int celsius)
    {
        return new Temperature(celsius);
    }
}
