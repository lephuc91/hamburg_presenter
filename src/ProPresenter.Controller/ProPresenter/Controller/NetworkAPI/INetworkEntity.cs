namespace ProPresenter.Controller.NetworkAPI;

public interface INetworkEntity
{
	string Name { get; }

	(string?, int) GetConnectionInfo();
}
