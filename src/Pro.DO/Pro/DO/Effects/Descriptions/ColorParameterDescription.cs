using System;
using System.Windows.Media;

namespace Pro.DO.Effects.Descriptions;

public class ColorParameterDescription : ParameterDescriptionBase
{
	public override ParameterType ParameterType => ParameterType.Color;

	public override Type BackingType { get; } = typeof(Color);

	public Color DefaultColor { get; }

	public ColorParameterDescription(string name, string description, Color defaultColor)
		: base(name, description)
	{
		DefaultColor = defaultColor;
	}

	internal override object GetDefaultValue()
	{
		return DefaultColor;
	}

	internal override bool IsValueValid<T>(T value)
	{
		return true;
	}
}
