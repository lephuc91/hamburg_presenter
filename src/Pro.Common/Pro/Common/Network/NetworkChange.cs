using System.Net.NetworkInformation;

namespace Pro.Common.Network;

public class NetworkChange : INetworkChange
{
	public event NetworkAvailabilityChangedEventHandler? NetworkAvailabilityChanged
	{
		add
		{
			System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += value;
		}
		remove
		{
			System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged -= value;
		}
	}

	public event NetworkAddressChangedEventHandler? NetworkAddressChanged
	{
		add
		{
			System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged += value;
		}
		remove
		{
			System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged -= value;
		}
	}
}
