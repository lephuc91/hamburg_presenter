using System;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.UI.Settings.PageTemplates.Network;

namespace ProPresenter.ViewModels;

internal class AddConnectionVM : NotifyPropertyChangedBase
{
	private string? _ip;

	private int? _port;

	private AddConnectionView? _dialog;

	private readonly RelayCommand _continueCommand;

	private readonly ILocalization _localization;

	public string? Ip
	{
		get
		{
			return _ip;
		}
		set
		{
			SetValue("Ip", ref _ip, value, (Action)delegate
			{
				_continueCommand.NotifyCanExecuteChanged();
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public int? Port
	{
		get
		{
			return _port;
		}
		set
		{
			SetValue("Port", ref _port, value, (Action)delegate
			{
				_continueCommand.NotifyCanExecuteChanged();
			}, (Predicate<int?>?)null, referenceComparison: false);
		}
	}

	public ICommand ContinueCommand => _continueCommand;

	public AddConnectionVM(ILocalization localization, string? ipAddress = null, int? port = null)
	{
		_localization = localization;
		_continueCommand = new RelayCommand(OnContinueCommand, CanContinue);
		Ip = ipAddress;
		Port = port;
	}

	internal (bool, string ipAddress, int port) ShowDialog()
	{
		_dialog = new AddConnectionView().WithDataContext(this);
		bool? flag = _dialog.ShowDialog();
		return (flag.HasValue && flag.Value, ipAddress: Ip ?? string.Empty, port: Port.GetValueOrDefault());
	}

	private void OnContinueCommand()
	{
		if (_dialog != null)
		{
			if (!NetworkHelper.ValidateIpAddress(Ip))
			{
				MessageDialogService.ShowSimpleContent(_localization.Get("GLOBAL_INVALID_IP_ADDRESS_ERROR_message"), _localization.Get("GLOBAL_INVALID_IP_ADDRESS_ERROR_info", new object[1] { Ip ?? string.Empty }), canCancel: false);
			}
			else
			{
				_dialog.DialogResult = true;
				_dialog.Close();
			}
		}
	}

	private bool CanContinue()
	{
		if (Port.HasValue)
		{
			return !string.IsNullOrEmpty(Ip);
		}
		return false;
	}
}
