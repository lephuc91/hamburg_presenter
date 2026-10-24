using System.ComponentModel;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels;

public interface ITimerTypeSelectorVM : INotifyPropertyChanged
{
	TimerType SelectedTimerType { get; set; }
}
