using Google.Protobuf.Reflection;

namespace Rv.Analytics.Powerpoint;

public enum ImportType
{
	[OriginalName("SLIDES_AS_IMAGES")]
	SlidesAsImages,
	[OriginalName("TEXT_ONLY")]
	TextOnly,
	[OriginalName("TEXT_AND_IMAGES")]
	TextAndImages,
	[OriginalName("CORE_OPEN_XML")]
	CoreOpenXml
}
