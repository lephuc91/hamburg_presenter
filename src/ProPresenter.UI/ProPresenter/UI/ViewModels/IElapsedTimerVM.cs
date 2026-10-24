using System.ComponentModel;
using Pro.DO.Triggering;

namespace ProPresenter.UI.ViewModels;

public interface IElapsedTimerVM : ITimerVM, ITriggerable, INotifyPropertyChanged
{
	bool HasEndTime { get; }
}
