using System;
using System.Globalization;
using System.Windows;
using Pro.Common.Time;
using Pro.UI.Components;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.CueInspector;

public class PlaybackMarkerTimestampToStringConverter : DataConverterBase<MediaBase>
{
	public static readonly DependencyProperty MarkerOffsetProperty = DependencyProperty.Register("MarkerOffset", typeof(TimeSlice), typeof(PlaybackMarkerTimestampToStringConverter), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero));

	public TimeSlice MarkerOffset
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(MarkerOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerOffsetProperty, (object)value);
		}
	}

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is TimeSlice timestamp))
		{
			return value;
		}
		return TimeToStringFormatter.PlaybackMarkerTimestampToString(timestamp, base.Data, MarkerOffset);
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
