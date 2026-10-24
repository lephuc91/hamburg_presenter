using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public interface INetworkLinkPrompt
{
	(bool, string ipAddress, int port) AddConnection();

	(bool, string ipAddress, int port) AddConnection(string? ipAddress, int port);

	void ShowPending(string message, INetworkLinkVM vm);

	void HidePending();

	bool CreateGroup(out string name);

	bool GroupJoinConfirm(string name);

	bool RemoveConnection(string memberName, string groupName);

	bool LeaveGroup(string name);

	void ShowUnexpectedError(string? ip, int port);

	void ShowTimeoutError(string? ip, int port);

	void ShowLinkDisabledError(string? memberName);

	void ShowInOtherGroupError(string memberName, string groupName);

	void ShowInvalidIpError();

	void ShowAlreadyInGroupError(string memberName, string groupName);

	void ShowCouldNotAddMemberError(string memberName);

	bool ShowCouldNotJoinGroupError(string groupName);
}
