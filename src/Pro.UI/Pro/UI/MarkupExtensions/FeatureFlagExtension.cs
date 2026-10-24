using System;
using System.Windows;
using System.Windows.Markup;
using Pro.Common.FeatureFlag;
using Pro.UI.DependencyInjection;

namespace Pro.UI.MarkupExtensions;

public class FeatureFlagExtension : MarkupExtension
{
	private readonly Flag _flag;

	public bool IsInverted { get; set; }

	public object TrueValue { get; set; } = Visibility.Visible;

	public object FalseValue { get; set; } = Visibility.Collapsed;

	public FeatureFlagExtension(Flag flag)
	{
		_flag = flag;
	}

	public override object? ProvideValue(IServiceProvider serviceProvider)
	{
		if (!(UIServiceProvider.GetService<IFlagService>().IsFlagEnabled(_flag) ^ IsInverted))
		{
			return FalseValue;
		}
		return TrueValue;
	}
}
