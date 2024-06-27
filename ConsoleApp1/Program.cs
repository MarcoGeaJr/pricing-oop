// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");




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