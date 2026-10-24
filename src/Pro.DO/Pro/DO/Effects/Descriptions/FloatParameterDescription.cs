using System;
using Pro.Common.Mathematics;
using Pro.Common.Operations;

namespace Pro.DO.Effects.Descriptions;

public class FloatParameterDescription : ParameterDescriptionBase
{
	public override ParameterType ParameterType => ParameterType.Float;

	public override Type BackingType { get; } = typeof(float);

	public float MinValue { get; }

	public float MaxValue { get; }

	public float DefaultValue { get; }

	public FloatParameterDescription(string name, string description, float minValue, float maxValue, float defaultValue)
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
		return value.Cast<float, T>().IsInRangeInclusive(MinValue, MaxValue);
	}
}
