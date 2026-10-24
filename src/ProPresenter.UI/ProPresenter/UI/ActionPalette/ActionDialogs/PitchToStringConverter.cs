using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Utility;
using Pro.MIDI;

namespace ProPresenter.UI.ActionPalette.ActionDialogs;

public class PitchToStringConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is int)
		{
			Pitch pitch = new Pitch((int)value);
			string enumDescription = ((Enum)pitch.Note).GetEnumDescription();
			return $"{enumDescription}{pitch.Octave} ({(int)value})";
		}
		return string.Empty;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
