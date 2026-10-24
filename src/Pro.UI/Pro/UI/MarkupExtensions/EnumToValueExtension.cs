using System;
using System.Windows.Markup;

namespace Pro.UI.MarkupExtensions;

public class EnumToValueExtension : MarkupExtension
{
	private readonly Enum _value;

	public EnumToValueExtension(Enum value)
	{
		_value = value;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return (int)Enum.Parse(_value.GetType(), _value.ToString());
	}
}
