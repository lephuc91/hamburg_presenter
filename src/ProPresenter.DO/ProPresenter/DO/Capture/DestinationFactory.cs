using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class DestinationFactory : IDestinationFactory
{
	public IDestination Create(DestinationType destinationType)
	{
		return destinationType switch
		{
			DestinationType.Disk => new DiskDestination(), 
			DestinationType.RTMP => new RtmpDestination(), 
			DestinationType.Resi => new ResiDestination(), 
			_ => throw new NotSupportedException(), 
		};
	}

	public IDestination? Create(Recording.Types.Stream.Types.Destination.DestinationOneofCase? protoDestination)
	{
		return protoDestination switch
		{
			Recording.Types.Stream.Types.Destination.DestinationOneofCase.None => null, 
			Recording.Types.Stream.Types.Destination.DestinationOneofCase.Disk => new DiskDestination(), 
			Recording.Types.Stream.Types.Destination.DestinationOneofCase.Rtmp => new RtmpDestination(), 
			Recording.Types.Stream.Types.Destination.DestinationOneofCase.Resi => new ResiDestination(), 
			_ => throw new NotSupportedException(), 
		};
	}
}
