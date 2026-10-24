using System.Collections.Generic;
using System.Linq;
using Pro.Common.Time;
using Pro.Localization;

namespace ProPresenter.UI;

public static class TimeHelper
{
	public static string GetFormattedTotalLength(this TimeSlice totalTime)
	{
		IEnumerable<string> enumerable = new string[3]
		{
			(totalTime.Days <= 0) ? string.Empty : ((totalTime.Days == 1) ? LocalizedStrings.Get("PLAYLIST_HEADER_DURATION_DAY_title") : LocalizedStrings.Get("PLAYLIST_HEADER_DURATION_DAY_PLURAL_title", new object[1] { totalTime.Days })),
			(totalTime.Hours <= 0) ? string.Empty : ((totalTime.Hours == 1) ? LocalizedStrings.Get("PLAYLIST_HEADER_DURATION_HOUR_title") : LocalizedStrings.Get("PLAYLIST_HEADER_DURATION_HOUR_PLURAL_title", new object[1] { totalTime.Hours })),
			(totalTime.Minutes <= 0) ? string.Empty : ((totalTime.Minutes == 1) ? LocalizedStrings.Get("PLAYLIST_HEADER_DURATION_MINUTE_title") : LocalizedStrings.Get("PLAYLIST_HEADER_DURATION_MINUTE_PLURAL_title", new object[1] { totalTime.Minutes }))
		}.Where((string s) => !string.IsNullOrEmpty(s));
		if (!enumerable.Any())
		{
			return string.Empty;
		}
		return "• " + string.Join(" ", enumerable);
	}
}
