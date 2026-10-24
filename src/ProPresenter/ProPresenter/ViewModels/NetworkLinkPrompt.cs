using System;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.UI.DialogService;
using ProPresenter.UI.Settings.PageTemplates.Network;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

internal class NetworkLinkPrompt : INetworkLinkPrompt
{
	private readonly Lazy<PendingConnectionView> _pendingConnectionView;

	private readonly ILocalization _localization;

	public NetworkLinkPrompt(ILocalization localization)
	{
		_localization = localization;
		_pendingConnectionView = new Lazy<PendingConnectionView>(() => new PendingConnectionView());
	}

	public (bool, string ipAddress, int port) AddConnection()
	{
		return new AddConnectionVM(_localization, null, null).ShowDialog();
	}

	public (bool, string ipAddress, int port) AddConnection(string? ipAddress, int port)
	{
		return new AddConnectionVM(_localization, ipAddress, port).ShowDialog();
	}

	public void ShowPending(string message, INetworkLinkVM vm)
	{
		_pendingConnectionView.Value.DataContext = vm;
		_pendingConnectionView.Value.Message = message;
		_pendingConnectionView.Value.Show();
	}

	public void HidePending()
	{
		if (_pendingConnectionView.Value.IsVisible)
		{
			_pendingConnectionView.Value.Close();
		}
	}

	public bool CreateGroup(out string name)
	{
		return new CreateGroupVM().ShowDialog(out name);
	}

	public bool GroupJoinConfirm(string name)
	{
		return new GroupJoinCofirmationVM(name).ShowDialog();
	}

	public void ShowUnexpectedError(string? ip, int port)
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_UNEXPECTED_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_UNEXPECTED_ERROR_info", ip ?? string.Empty, port), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowTimeoutError(string? ip, int port)
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_INVALID_IP_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_TIMEOUT_ERROR_info", ip ?? string.Empty, port), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowLinkDisabledError(string? memberName)
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_COULD_NOT_ADD_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_COULD_NOT_ADD_ERROR_info", new object[1] { memberName ?? string.Empty }), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowInOtherGroupError(string memberName, string groupName)
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_ADD_MEMBER_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_ADD_MEMBER_ERROR_info", new object[2] { memberName, groupName }), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowInvalidIpError()
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_INVALID_IP_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_INVALID_IP_ERROR_info"), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowAlreadyInGroupError(string memberName, string groupName)
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_ADD_MEMBER_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_ADD_MEMBER_ERROR_info", new object[2] { memberName, groupName }), DefaultButtons.OK, DefaultButtons.OK);
	}

	public void ShowCouldNotAddMemberError(string memberName)
	{
		MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_COULD_NOT_ADD_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_COULD_NOT_ADD_ERROR_info", new object[1] { memberName }), DefaultButtons.OK, DefaultButtons.OK);
	}

	public bool ShowCouldNotJoinGroupError(string groupName)
	{
		DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_JOIN_GROUP_ERROR_message"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_JOIN_GROUP_ERROR_info", new object[1] { groupName }), DefaultButtons.RETRY | DefaultButtons.CANCEL, DefaultButtons.RETRY, new DefaultButtons[2]
		{
			DefaultButtons.CANCEL,
			DefaultButtons.RETRY
		});
		if (defaultButtons.HasValue)
		{
			return defaultButtons.Value == DefaultButtons.RETRY;
		}
		return false;
	}

	public bool RemoveConnection(string memberName, string groupName)
	{
		DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_REMOVE_MEMBER_ALERT_title"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_REMOVE_MEMBER_ALERT_info", new object[2] { memberName, groupName }), DefaultButtons.CONTINUE | DefaultButtons.CANCEL, DefaultButtons.CONTINUE, new DefaultButtons[2]
		{
			DefaultButtons.CANCEL,
			DefaultButtons.CONTINUE
		});
		if (defaultButtons.HasValue)
		{
			return defaultButtons.Value == DefaultButtons.CONTINUE;
		}
		return false;
	}

	public bool LeaveGroup(string name)
	{
		DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_LEAVE_GROUP_ALERT_title"), LocalizedStrings.Get("SETTINGS_PAGE_NETWORK_LINK_LEAVE_GROUP_ALERT_info", new object[1] { name }), DefaultButtons.CONTINUE | DefaultButtons.CANCEL, DefaultButtons.CONTINUE, new DefaultButtons[2]
		{
			DefaultButtons.CANCEL,
			DefaultButtons.CONTINUE
		});
		if (defaultButtons.HasValue)
		{
			return defaultButtons.Value == DefaultButtons.CONTINUE;
		}
		return false;
	}
}
