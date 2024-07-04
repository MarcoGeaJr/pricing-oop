namespace Domain.ValueObjects;

public sealed class Markup
{
	public Percentage ProfitMargin { get; }

	public Markup(decimal margin)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(margin);

		ProfitMargin = Percentage.FromDecimal(margin);
	}

	public Price ApplyToCost(Price cost)
	{
		Price percentageOfCost = cost * ProfitMargin;

		return cost + percentageOfCost;
	}
}
