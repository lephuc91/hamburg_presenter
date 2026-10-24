using System;
using System.Windows.Markup;

namespace Pro.UI.DependencyInjection;

public class DIMarkupExtension : MarkupExtension
{
	private readonly Type _type;

	public DIMarkupExtension(Type type)
	{
		_type = type;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return UIServiceProvider.GetService(_type);
	}
}
