using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public static class DestinationTypeExtensions
{
	public static DestinationType ToDestinationType(this Recording.Types.Stream.Types.Destination.DestinationOneofCase protoDestinationType)
	{
		return protoDestinationType switch
		{
			Recording.Types.Stream.Types.Destination.DestinationOneofCase.Rtmp => DestinationType.RTMP, 
			Recording.Types.Stream.Types.Destination.DestinationOneofCase.Resi => DestinationType.Resi, 
			_ => DestinationType.Disk, 
		};
	}
}
