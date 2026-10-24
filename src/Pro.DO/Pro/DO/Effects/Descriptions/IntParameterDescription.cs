using System;
using Pro.Common.Mathematics;
using Pro.Common.Operations;

namespace Pro.DO.Effects.Descriptions;

public class IntParameterDescription : ParameterDescriptionBase
{
	public override ParameterType ParameterType => ParameterType.Int;

	public override Type BackingType { get; } = typeof(int);

	public int MinValue { get; }

	public int MaxValue { get; }

	public int DefaultValue { get; }

	public IntParameterDescription(string name, string description, int minValue, int maxValue, int defaultValue)
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
		return value.Cast<int, T>().IsInRangeInclusive(MinValue, MaxValue);
	}
}
