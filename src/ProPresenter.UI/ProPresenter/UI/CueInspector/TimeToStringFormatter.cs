using Pro.Common.Time;
using ProPresenter.DO.Media;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.CueInspector;

public static class TimeToStringFormatter
{
	private static TimerFormatData? VideoFormatData;

	private static TimerFormatData? AudioFormatData;

	public static string PlaybackMarkerTimestampToString(TimeSlice timestamp, MediaBase media, TimeSlice markerOffset, bool showSubSeconds = true)
	{
		if (VideoFormatData == null)
		{
			VideoFormatData = new TimerFormatData
			{
				HourFormat = TimerFormatStyle.LongTruncated,
				MinuteFormat = TimerFormatStyle.Long,
				SecondFormat = TimerFormatStyle.Long,
				MillisecondFormat = TimerFormatStyle.None
			};
		}
		if (AudioFormatData == null)
		{
			AudioFormatData = new TimerFormatData
			{
				HourFormat = TimerFormatStyle.ShortTruncated,
				MinuteFormat = TimerFormatStyle.Short,
				SecondFormat = TimerFormatStyle.Long,
				MillisecondFormat = TimerFormatStyle.Long
			};
		}
		if (media is FileMediaBase fileMediaBase)
		{
			double frameRate = fileMediaBase.Metadata?.FPS ?? 0.0;
			if (media is VideoMedia)
			{
				return (timestamp - markerOffset).FormatTime(frameRate, showSubSeconds, VideoFormatData);
			}
			if (media is AudioMedia)
			{
				return AudioFormatData.FormatTime(timestamp - markerOffset);
			}
		}
		return string.Empty;
	}
}
