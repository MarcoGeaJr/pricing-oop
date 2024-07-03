namespace Domain.ValueObjects;

public sealed class Percentage
{
	public decimal Value { get; private set; }

	public Percentage(decimal value)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(value);

		Value = value;
	}

	public bool GreaterThan(Percentage other)
		=> Value > other.Value;

	public static Percentage FromDecimal(decimal percentage)
		=> new(Math.Round(percentage, 2));

	public static Percentage FromFraction(decimal fraction)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(fraction);

		return FromDecimal(fraction * 100);
	}

	public decimal ToFraction()
	{
		return Math.Round(Value / 100m, 2);
	}

	public decimal ApplyTo(decimal amount)
	{
		return amount * ToFraction();
	}

	public override string ToString()
	{
		return $"{Value}%";
	}
}
