using System;
using System.Globalization;
using System.Windows;
using Pro.UI.Converters;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.MediaLibrary;

public class MediaCueValidToVisibilityConverter : ValueConverterBase<IMediaCue, Visibility>
{
	public bool IsInverted { get; set; }

	protected override Visibility ConvertValue(IMediaCue value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value != null)
		{
			if (value.MediaAction == null)
			{
				if (!IsInverted)
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			}
			if (value.MediaAction.IsValid)
			{
				if (!IsInverted)
				{
					return Visibility.Visible;
				}
				return Visibility.Collapsed;
			}
		}
		if (!IsInverted)
		{
			return Visibility.Collapsed;
		}
		return Visibility.Visible;
	}
}
