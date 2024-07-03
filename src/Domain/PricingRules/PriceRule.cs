using Domain.ValueObjects;

namespace Domain.PricingRules;


public sealed class PriceRule
{
	public Percentage Modifier { get; private set; }

	public PriceRule(Percentage percentage)
	{
		Modifier = percentage;
	}

	public static PriceRule FromDecimal(decimal modifier/*, markup range, date range*/)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(modifier);

		Percentage percentageModifier = Percentage.FromFraction(Math.Abs(modifier));

		return new(percentageModifier);
	}

	public bool CanModify(Markup markup, DateTime now) { return false; }

	public Price Modify(Price price)
	{
		throw new NotImplementedException();
	}
}
