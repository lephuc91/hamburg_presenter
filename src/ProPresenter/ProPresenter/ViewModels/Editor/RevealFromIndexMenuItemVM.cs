using System;
using System.Windows.Input;
using Pro.Common.Components;

namespace ProPresenter.ViewModels.Editor;

public class RevealFromIndexMenuItemVM : NotifyPropertyChangedBase
{
	private bool _isChecked;

	private string _header = string.Empty;

	private ICommand? _command;

	private int _index;

	public bool IsChecked
	{
		get
		{
			return _isChecked;
		}
		set
		{
			SetValue("IsChecked", ref _isChecked, value);
		}
	}

	public string Header
	{
		get
		{
			return _header;
		}
		set
		{
			SetValue("Header", ref _header, value);
		}
	}

	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			SetValue("Index", ref _index, value, (Action<int, int>?)delegate
			{
				OnPropertyChanged("Header");
			}, (Predicate<int>?)null, referenceComparison: false);
		}
	}

	public string FormattedHeader => $"{Index + 1}: {Header}";

	public ICommand? Command
	{
		get
		{
			return _command;
		}
		set
		{
			SetValue("Command", ref _command, value);
		}
	}
}
