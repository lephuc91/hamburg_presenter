using System.ComponentModel;
using System.Windows.Media;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Presentation;

public interface ITimelineSlideItem : ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	string GroupName { get; }

	Color? GroupColor { get; }
}
