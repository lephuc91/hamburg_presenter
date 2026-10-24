using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class AvailableDevice : INetworkEntity
{
	private readonly ProLink.Types.MemberStatus _device;

	public string Name => _device.Name;

	public AvailableDevice(ProLink.Types.MemberStatus device)
	{
		_device = device;
	}

	public (string, int) GetConnectionInfo()
	{
		return (_device.Ip, (int)_device.Port);
	}
}
