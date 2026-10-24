using Pro.DO.Audio;

namespace ProPresenter.DO.Capture;

public class StreamFactory : IStreamFactory
{
	private readonly ChannelSet<Bus> _buses;

	private readonly IDestinationFactory _destinationFactory;

	public StreamFactory(ChannelSet<Bus> buses, IDestinationFactory? destinationFactory = null)
	{
		_buses = buses;
		_destinationFactory = destinationFactory ?? new DestinationFactory();
	}

	public IStream CreateStream()
	{
		return new Stream(_buses, _destinationFactory);
	}
}
