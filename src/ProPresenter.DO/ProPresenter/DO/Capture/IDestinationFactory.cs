using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public interface IDestinationFactory
{
	IDestination? Create(Recording.Types.Stream.Types.Destination.DestinationOneofCase? protoDestination);

	IDestination Create(DestinationType destinationType);
}
