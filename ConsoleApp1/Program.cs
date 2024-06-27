// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public sealed class Price(decimal value)
{
	public decimal Value { get; } = value;

	public decimal GetPercentage(decimal percentage)
	{
		if (percentage < 0 || percentage > 1)
			throw new ArgumentOutOfRangeException(nameof(percentage));

		return Value * percentage;
	}
}

public interface IPriceCalculationStrategy
{
	decimal Calculate(Price price, decimal percentage);
}

public class AddtionPriceCalculationStrategy : IPriceCalculationStrategy
{
	public decimal Calculate(Price price, decimal percentage)
	{
		return CalculateAddtion(
			price.Value,
			price.GetPercentage(percentage));
	}

	private static decimal CalculateAddtion
		(decimal originalValue, decimal addtionValue) => originalValue + addtionValue;
}

public class DiscountPriceCalculationStrategy
{

}

public class MarkupPriceCalculationStrategy
{

}