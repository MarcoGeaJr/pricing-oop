using Domain.ValueObjects;

namespace Domain;

public interface IPriceCalculator
{
	ComputedPrice Calculate(SKU sku);
}

public abstract class PriceCalculator : IPriceCalculator
{
	protected IPriceCalculator? _next;

	protected PriceCalculator(
		IPriceCalculator? next)
	{
		_next = next;
	}

	public abstract ComputedPrice Calculate(SKU sku);
}

public sealed class BasePriceCalculator : PriceCalculator
{
	public BasePriceCalculator()
		: base(null)
	{
	}

	public override ComputedPrice Calculate(SKU sku)
	{
		ComputedPrice? computedPrice = _next?.Calculate(sku);

		return computedPrice ?? new(sku.CostPrice, sku.BasePrice, sku.ListPrice);
	}
}

public sealed class PriceRuleCalculator : PriceCalculator
{
	private readonly IReadOnlyCollection<PriceRule> _priceRules;

	public PriceRuleCalculator(
		IReadOnlyCollection<PriceRule> priceRules,
		IPriceCalculator? next)
		: base(next)
	{
		_priceRules = priceRules;
	}

	public override ComputedPrice Calculate(SKU sku)
	{
		throw new NotImplementedException();
	}
}

public sealed class RoundingPriceCalculator : PriceCalculator
{
	private readonly RoundingRule _roundingRule;

	public RoundingPriceCalculator(
		RoundingRule roundingRule,
		IPriceCalculator? next)
		: base(next)
	{
		_roundingRule = roundingRule;
	}

	public override ComputedPrice Calculate(SKU sku)
	{
		throw new NotImplementedException();
	}
}

public sealed class FixedPriceCalculator : PriceCalculator
{
	private readonly IReadOnlyCollection<FixedPrice> _fixedPrices;

	public FixedPriceCalculator(
		IReadOnlyCollection<FixedPrice> fixedPrices,
		IPriceCalculator? next)
		: base(next)
	{
		_fixedPrices = fixedPrices;
	}

	public override ComputedPrice Calculate(SKU sku)
	{
		FixedPrice? fixedPrice = GetValidFixedPrice(_fixedPrices);

		if (fixedPrice is not null)
			return new(sku.CostPrice, fixedPrice.SellingPrice, fixedPrice.ListPrice);

		return _next?.
	}

	// TODO: temp
	public FixedPrice? GetValidFixedPrice(IReadOnlyCollection<FixedPrice> fixedPrices)
	{
		throw new NotImplementedException();
	}
}

public class PriceCalculatorFactory
{
	public IPriceCalculator Build(PriceTable priceTable)
	{
		PriceCalculator priceCalculator = new BasePriceCalculator();

		if (priceTable.PriceRules.Count != 0)
		{
			priceCalculator = new PriceRuleCalculator(priceTable.PriceRules, priceCalculator);
		}

		if (priceTable.RoundingRule is not null)
		{
			priceCalculator = new RoundingPriceCalculator(priceTable.RoundingRule!, priceCalculator);
		}

		if (priceTable.FixedPrices.Count != 0)
		{
			priceCalculator = new FixedPriceCalculator(priceTable.FixedPrices, priceCalculator);
		}

		return priceCalculator;
	}
}

