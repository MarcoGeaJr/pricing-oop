using Domain.ValueObjects;

namespace Domain.Rounding;

public interface IRoundingMethod
{
	Price Apply(Price price);
}

public sealed class RuleOfNineMethod : IRoundingMethod
{
	public Price Apply(Price price)
	{
		throw new NotImplementedException();
	}
}

public sealed class RuleOfNinesMethod : IRoundingMethod
{
	public Price Apply(Price price)
	{
		throw new NotImplementedException();
	}
}

public sealed class RuleOfZerosMethod : IRoundingMethod
{
	public Price Apply(Price price)
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

	public bool CanApply(Price price) { return false; }

	public Price Apply(Price price) { throw new NotImplementedException(); }
}
