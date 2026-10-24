using Google.Protobuf.Reflection;

namespace Rv.Analytics.Powerpoint;

public enum ImportFormat
{
	[OriginalName("UNKOWN")]
	Unkown,
	[OriginalName("PPT")]
	Ppt,
	[OriginalName("PPTX")]
	Pptx
}
