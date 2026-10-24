using System.Net.NetworkInformation;

namespace Pro.Common.Network;

public interface INetworkChange
{
	event NetworkAddressChangedEventHandler? NetworkAddressChanged;

	event NetworkAvailabilityChangedEventHandler? NetworkAvailabilityChanged;
}
