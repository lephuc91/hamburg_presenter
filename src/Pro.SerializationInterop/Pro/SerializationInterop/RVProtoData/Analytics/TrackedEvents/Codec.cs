using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

public enum Codec
{
	[OriginalName("H264")]
	H264,
	[OriginalName("H264SOFTWARE")]
	H264Software,
	[OriginalName("H265")]
	H265,
	[OriginalName("H265SOFTWARE")]
	H265Software,
	[OriginalName("PRORES422PROXY")]
	Prores422Proxy,
	[OriginalName("PRORES422LT")]
	Prores422Lt,
	[OriginalName("PRORES422")]
	Prores422,
	[OriginalName("PRORES422HQ")]
	Prores422Hq,
	[OriginalName("PRORES4444")]
	Prores4444,
	[OriginalName("PRORES4444XQ")]
	Prores4444Xq,
	[OriginalName("HAP")]
	Hap,
	[OriginalName("HAPALPHA")]
	Hapalpha,
	[OriginalName("NOTCH")]
	Notch,
	[OriginalName("AUTOMATIC")]
	Automatic,
	[OriginalName("HAPQ")]
	Hapq,
	[OriginalName("HAPQALPHA")]
	Hapqalpha
}
