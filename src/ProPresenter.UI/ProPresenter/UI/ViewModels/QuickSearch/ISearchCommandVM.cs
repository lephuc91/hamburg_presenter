using System.ComponentModel;
using System.Windows.Input;

namespace ProPresenter.UI.ViewModels.QuickSearch;

public interface ISearchCommandVM : INotifyPropertyChanged
{
	string Text { get; }

	ICommand BindCommand { get; }

	ICommand ExecuteCommand { get; }

	bool IsVisible { get; }
}
