using System;
using System.Windows.Markup;

namespace Pro.UI.MarkupExtensions;

[MarkupExtensionReturnType(typeof(int))]
public class IntExtension : MarkupExtension
{
	[ConstructorArgument("value")]
	public int Value { get; set; }

	public IntExtension(int value)
	{
		Value = value;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return Value;
	}
}
