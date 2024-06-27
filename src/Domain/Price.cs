namespace Domain;

public sealed class SKU(string skuId, Price basePrice, decimal? fixedPrice = null)
{
	public string Id { get; } = skuId;
	public Price BasePrice { get; } = basePrice;
	public decimal? FixedPrice { get; } = fixedPrice;
}

public sealed class Percentage
{
	public decimal Value { get; }

	public Percentage(decimal percentage)
	{
		if (percentage < 0 || percentage > 1)
			throw new ArgumentOutOfRangeException(nameof(percentage));

		Value = percentage;
	}

	public static decimal operator *(Percentage p, decimal other) => p.Value * other;
	public static decimal operator *(decimal other, Percentage p) => p.Value * other;
}

public sealed class Price(decimal value)
{
	public decimal Value { get; } = value;

	public static decimal operator *(Price p, Percentage other) => p.Value * other;
	public static decimal operator *(Percentage other, Price p) => p.Value * other;
}

public record ComputedPrice(decimal Value);

public interface IPriceCalculationRule
{
	ComputedPrice Calculate(Price price, Percentage percentage);
}
