using Domain.ValueObjects;

namespace Domain.Rounding;

public interface IRoundingMethod
{
	ComputedPrice Apply(ComputedPrice computedPrice);
}

public sealed class RuleOfNineMethod : IRoundingMethod
{
	public ComputedPrice Apply(ComputedPrice computedPrice)
	{
		throw new NotImplementedException();
	}
}

public sealed class RuleOfNinesMethod : IRoundingMethod
{
	public ComputedPrice Apply(ComputedPrice computedPrice)
	{
		throw new NotImplementedException();
	}
}

public sealed class RuleOfZerosMethod : IRoundingMethod
{
	public ComputedPrice Apply(ComputedPrice computedPrice)
	{
		throw new NotImplementedException();
	}
}

public class RoundingRule : Enumeration
{
	public static readonly RoundingRule RuleOfNine
		= new(1, "Rule of Nine", new RuleOfNineMethod());

	public static readonly RoundingRule RuleOfNines
		= new(2, "Rule of Nines", new RuleOfNinesMethod());

	public static readonly RoundingRule RuleOfZeros
		= new(3, "Rule of Nines", new RuleOfZerosMethod());

	private readonly IRoundingMethod _roundingMethod;

	public RoundingRule(
		int value,
		string displayName,
		IRoundingMethod roundingMethod)
		: base(value, displayName)
	{
		_roundingMethod = roundingMethod;
	}

	public ComputedPrice Apply(ComputedPrice computedPrice)
		=> _roundingMethod.Apply(computedPrice);
}
