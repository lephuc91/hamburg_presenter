using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels.QuickSearch;

public class SearchCommandVM : NotifyPropertyChangedBase, ISearchCommandVM, INotifyPropertyChanged
{
	private bool _isVisible = true;

	public string Text { get; }

	public ICommand BindCommand { get; }

	public ICommand ExecuteCommand { get; }

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			SetValue("IsVisible", ref _isVisible, value);
		}
	}

	public SearchCommandVM(string text, ICommand bindCommand, ICommand executeCommand)
	{
		Text = text;
		BindCommand = bindCommand;
		ExecuteCommand = executeCommand;
	}
}
