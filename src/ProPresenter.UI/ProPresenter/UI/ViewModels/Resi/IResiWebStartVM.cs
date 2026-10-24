using System.ComponentModel;
using System.Windows.Input;

namespace ProPresenter.UI.ViewModels.Resi;

public interface IResiWebStartVM : INotifyPropertyChanged
{
	string Message { get; }

	string AbortButtonText { get; }

	string BeginButtonText { get; }

	ICommand AbortCommand { get; }

	ICommand BeginCommand { get; }
}
