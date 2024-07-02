namespace Domain.ValueObjects;

public sealed class Price
{
}

public sealed class Percentage
{

}

public sealed class Markup
{

}

public sealed class Timeframe
{

}

public enum ScheduleStatus
{
	Active,
	Inactive
}

public sealed class Schedule
{

}

public record ComputedPrice(Price CostPrice, Price SellingPrice, Price? ListPrice);

public sealed class Range;
