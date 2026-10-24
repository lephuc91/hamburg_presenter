using System;
using System.ComponentModel;
using ProPresenter.DO.NetworkLink;

namespace ProPresenter.Controller.NetworkAPI;

public interface INetworkLinkService : INotifyPropertyChanged
{
	IGroupDefinition GroupDefinition { get; }

	INetworkEnvironment Environment { get; }

	void AddConnection(string? ip, int port, string groupName);

	void RemoveConnection(string ip, int port);

	void Cancel();

	void AddRequestHandler(Func<ILinkRequest?, ILinkResponse?> handler);
}
