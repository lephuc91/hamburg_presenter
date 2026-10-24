using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public enum API_v1_CaptureDestination
{
	[OriginalName("disk")]
	Disk,
	[OriginalName("rtmp")]
	Rtmp,
	[OriginalName("resi")]
	Resi
}
