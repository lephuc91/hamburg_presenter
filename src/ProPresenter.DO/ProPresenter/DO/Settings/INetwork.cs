using System.ComponentModel;
using ProPresenter.DO.NetworkLink;

namespace ProPresenter.DO.Settings;

public interface INetwork : INotifyPropertyChanged
{
	int DefaultPort { get; }

	bool EnableNetwork { get; set; }

	string NetworkName { get; set; }

	int NetworkPort { get; set; }

	string LocalIPAddress { get; set; }

	bool EnableMasterControl { get; set; }

	bool EnableProRemoteV2 { get; set; }

	string ProRemoteV2Password { get; set; }

	bool EnableRemoteStageDisplay { get; set; }

	string RemoteStageDisplayPassword { get; set; }

	bool EnableLink { get; set; }

	Group LinkGroup { get; }

	bool InEnabledLinkGroup { get; }

	bool EnableTcpConnection { get; set; }

	int TcpConnectionPort { get; set; }

	int GetPort(int autoPort);

	void RemoveValue(string key);

	void Reload();

	void UpdateSettingsFile();
}
