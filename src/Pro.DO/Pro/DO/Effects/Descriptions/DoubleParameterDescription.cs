using System;
using Pro.Common.Mathematics;
using Pro.Common.Operations;

namespace Pro.DO.Effects.Descriptions;

public class DoubleParameterDescription : ParameterDescriptionBase
{
	public override ParameterType ParameterType => ParameterType.Double;

	public override Type BackingType { get; } = typeof(double);

	public double MinValue { get; }

	public double MaxValue { get; }

	public double DefaultValue { get; }

	public DoubleParameterDescription(string name, string description, double minValue, double maxValue, double defaultValue)
		: base(name, description)
	{
		MinValue = minValue;
		MaxValue = maxValue;
		DefaultValue = defaultValue;
	}

	internal override object GetDefaultValue()
	{
		return DefaultValue;
	}

	internal override bool IsValueValid<T>(T value)
	{
		return value.Cast<double, T>().IsInRangeInclusive(MinValue, MaxValue);
	}
}
