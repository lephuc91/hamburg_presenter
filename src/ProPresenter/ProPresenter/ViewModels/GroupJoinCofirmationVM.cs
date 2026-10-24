using System.Windows.Input;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.UI.Settings.PageTemplates.Network;

namespace ProPresenter.ViewModels;

public class GroupJoinCofirmationVM
{
	private readonly GroupJoinConfirmation _dialog;

	public string Title { get; }

	public ICommand JoinCommand => new RelayCommand(OnJoinCommand);

	public GroupJoinCofirmationVM(string name)
	{
		Title = LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_JOIN_GROUP_DIALOG_title", new object[1] { name });
		_dialog = new GroupJoinConfirmation().WithDataContext(this);
	}

	internal bool ShowDialog()
	{
		bool? flag = _dialog.ShowDialog();
		if (flag.HasValue)
		{
			return flag.Value;
		}
		return false;
	}

	private void OnJoinCommand()
	{
		if (_dialog != null)
		{
			_dialog.DialogResult = true;
			_dialog.Close();
		}
	}
}
