using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Time;
using ProPresenter.DO.Presentation;

namespace ProPresenter.UI.ViewModels.Timeline;

public interface ITimelineItemVM : INotifyPropertyChanged
{
	Brush? Background { get; }

	TimeSlice Duration { get; }

	bool FillToNextItem { get; set; }

	string GroupName { get; }

	TimelineItemInfo? Item { get; }

	TimelineItemType ItemType { get; }

	string Name { get; }

	TimeSlice StartTime { get; set; }
}
