using System;
using System.Globalization;
using Pro.Common.Strings;
using Pro.Localization;
using Pro.UI.Converters;

namespace ProPresenter.UI.Updates;

public class FormatDownloadedBytesConverter : MultiValueConverterBase<string>
{
	protected override string? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length != 2 || !(values[0] is long value) || !(values[1] is long value2))
		{
			return null;
		}
		return LocalizedStrings.Get("UPDATES_DOWNLOAD_PROGRESS_label", new object[2]
		{
			value.BytesToReadableSizeFormat(),
			value2.BytesToReadableSizeFormat()
		});
	}
}
