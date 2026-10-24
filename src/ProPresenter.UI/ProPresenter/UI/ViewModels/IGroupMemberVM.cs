namespace ProPresenter.UI.ViewModels;

public interface IGroupMemberVM
{
	string Name { get; }

	string Version { get; }

	string Ip { get; }

	string Port { get; }

	bool ShowConnectionStatus { get; }
}
