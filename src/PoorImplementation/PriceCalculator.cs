namespace PoorImplementation;

public class SKU(string id, decimal price, decimal cost)
{
	public string Id { get; set; } = id;
	public decimal Price { get; set; } = price;
	public decimal Cost { get; set; } = cost;
}

public class PriceTable
{
	public PriceTableCalculationRule CalculationRule { get; set; }
	public PriceRoundingMethods RoundingMethod { get; set; }
	public decimal Percentage { get; set; }

	public List<PriceTableSKUException> SKUExceptions { get; set; } = [];

	public decimal CalculatePrice(SKU sku)
	{
		throw new NotImplementedException();
	}
}

public class PriceTableSKUException(string skuId, decimal fixedPrice)
{
	public string SkuId { get; set; } = skuId;
	public decimal FixedPrice { get; set; } = fixedPrice;
}

public enum PriceTableCalculationRule
{
	ADDTION,
	DISCOUNT,
	MARKUP
}

public enum PriceRoundingMethods
{
	RULE_OF_NINE,
	RULE_OF_NINES,
	RULE_OF_ZEROS,
}
