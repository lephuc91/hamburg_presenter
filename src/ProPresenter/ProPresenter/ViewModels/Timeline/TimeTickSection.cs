using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Time;
using Pro.UI.Converters;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.ViewModels.Timeline;

public class TimeTickSection : ObservableObject, ITimeTickSection, ITimelineItemVM, INotifyPropertyChanged
{
	private readonly FormattedTimeSliceConverter _timeSliceFormatter = new FormattedTimeSliceConverter();

	public Brush? Background { get; set; }

	public TimeSlice Duration { get; set; }

	public bool FillToNextItem { get; set; }

	public string GroupName { get; set; } = string.Empty;

	public TimelineItemInfo? Item { get; set; }

	public TimelineItemType ItemType { get; set; }

	public string Label => _timeSliceFormatter.Convert(StartTime, typeof(string), null, CultureInfo.InvariantCulture)?.ToString() ?? string.Empty;

	public string Name { get; set; } = string.Empty;

	public TimeSlice StartTime { get; set; }
}
