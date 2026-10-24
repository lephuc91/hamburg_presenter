using System;
using System.Globalization;
using Pro.Localization;
using Pro.UI.Converters;

namespace ProPresenter.UI.Settings.PageTemplates.General;

public class SelectedLanguageConverter : ValueConverterBase<CultureInfo, string>
{
	protected override string ConvertValue(CultureInfo value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return string.Empty;
		}
		return LocalizedStrings.Get(value.Name switch
		{
			"cs" => "LANGUAGE_PREFERENCES_LANGUAGE_CZECH", 
			"de" => "LANGUAGE_PREFERENCES_LANGUAGE_GERMAN", 
			"en" => "LANGUAGE_PREFERENCES_LANGUAGE_ENGLISH", 
			"es-419" => "LANGUAGE_PREFERENCES_LANGUAGE_SPANISH_LATINAMERICA", 
			"fr" => "LANGUAGE_PREFERENCES_LANGUAGE_FRENCH", 
			"ko" => "LANGUAGE_PREFERENCES_LANGUAGE_KOREAN", 
			"no" => "LANGUAGE_PREFERENCES_LANGUAGE_NORWEIGIAN_BOKMAL", 
			"pt-BR" => "LANGUAGE_PREFERENCES_LANGUAGE_PORTUGUESE_BRAZIL", 
			"ru" => "LANGUAGE_PREFERENCES_LANGUAGE_RUSSIAN", 
			"zh-CN" => "LANGUAGE_PREFERENCES_LANGUAGE_CHINESE_SIMPLIFIED", 
			_ => "LANGUAGE_PREFERENCES_LANGUAGE_SYSTEM_DEFAULT", 
		});
	}
}
