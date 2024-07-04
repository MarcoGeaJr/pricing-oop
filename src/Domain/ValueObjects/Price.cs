namespace Domain.ValueObjects;

public sealed class Price
{
	public decimal Value { get; }

	public Price(decimal value)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(value);

		Value = value;
	}

	public static Price operator *(Price price, Percentage percentage)
		=> new(percentage.ApplyTo(price.Value));

	public static Price operator +(Price left, Price right)
		=> new(left.Value + right.Value);
}
