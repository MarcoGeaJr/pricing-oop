using Domain.ValueObjects;

namespace Domain;

public sealed class SKU
{
	public string Id { get; }
	public Price CostPrice { get; }
	public Price BasePrice { get; }
	public Price? ListPrice { get; }
}

public sealed class FixedPrice
{
	public Price SellingPrice { get; }
	public Price? ListPrice { get; }
}

public sealed class PriceRule;

public sealed class RoundingRule;

public sealed class PriceTable
{
	public string Name { get; set; }
	public List<PriceRule> PriceRules { get; set; } = [];
	public RoundingRule? RoundingRule { get; set; }
	public List<FixedPrice> FixedPrices { get; set; } = [];
}