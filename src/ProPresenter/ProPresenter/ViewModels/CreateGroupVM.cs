using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.UI.Settings.PageTemplates.Network;

namespace ProPresenter.ViewModels;

public class CreateGroupVM : NotifyPropertyChangedBase
{
	private string _name = string.Empty;

	private readonly CreateGroup _dialog;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value);
		}
	}

	public ICommand CreateCommand => new RelayCommand(OnCreateCommand, CanCreate);

	public CreateGroupVM()
	{
		_dialog = new CreateGroup().WithDataContext(this);
	}

	internal bool ShowDialog(out string name)
	{
		bool? flag = _dialog.ShowDialog();
		name = Name;
		if (flag.HasValue)
		{
			return flag.Value;
		}
		return false;
	}

	private void OnCreateCommand()
	{
		if (_dialog != null)
		{
			_dialog.DialogResult = true;
			_dialog.Close();
		}
	}

	private bool CanCreate()
	{
		return !string.IsNullOrEmpty(Name);
	}
}
