using System.ComponentModel;
using Pro.DO.Triggering;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels;

public interface ICountdownToTimeTimerVM : ITimerVM, ITriggerable, INotifyPropertyChanged
{
	TimeFormat TimeFormat { get; set; }
}
