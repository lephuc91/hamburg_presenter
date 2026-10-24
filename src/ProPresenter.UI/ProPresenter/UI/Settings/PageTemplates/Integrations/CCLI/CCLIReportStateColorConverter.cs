using System;
using System.Globalization;
using System.Windows.Media;
using Pro.UI.Converters;
using Pro.UI.Themes;
using ProPresenter.DO.Settings.GeneralSettings;

namespace ProPresenter.UI.Settings.PageTemplates.Integrations.CCLI;

public class CCLIReportStateColorConverter : MultiValueConverterBase<SolidColorBrush>
{
	protected override SolidColorBrush ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 2 && values[0] is ReportState reportState && values[1] is bool flag)
		{
			Color? color = reportState switch
			{
				ReportState.Pending => Pro.UI.Themes.Colors.GetColor(Pro.UI.Themes.Colors.StateCaution), 
				ReportState.Reported => Pro.UI.Themes.Colors.GetColor(Pro.UI.Themes.Colors.StateActive), 
				_ => Pro.UI.Themes.Colors.GetColor(Pro.UI.Themes.Colors.LightContent), 
			};
			if (reportState == ReportState.Pending && !flag)
			{
				color = Pro.UI.Themes.Colors.GetColor(Pro.UI.Themes.Colors.StateError);
			}
			return new SolidColorBrush(color.HasValue ? color.Value : default(Color));
		}
		return System.Windows.Media.Brushes.Transparent;
	}
}
