using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Timeline;

public interface ITimeTickSection : ITimelineItemVM, INotifyPropertyChanged
{
	string Label { get; }
}
