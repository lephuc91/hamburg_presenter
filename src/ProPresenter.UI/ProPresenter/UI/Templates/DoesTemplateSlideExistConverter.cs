using System;
using System.Globalization;
using Pro.UI.Converters;
using Pro.UI.DependencyInjection;
using ProPresenter.DO;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

public class DoesTemplateSlideExistConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values != null && values.Length > 1 && values[0] is TemplateSlide { Slide: not null } templateSlide)
		{
			return UIServiceProvider.GetService<IThemeService>()?.Themes?.DoesTemplateSlideExist(templateSlide.Slide.ID) == true;
		}
		return false;
	}
}
