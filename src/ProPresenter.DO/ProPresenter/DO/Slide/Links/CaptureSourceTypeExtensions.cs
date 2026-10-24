using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CaptureTextType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase), SourceToDestinationMethodName = "ToProtoCaptureSourceType", DestinationDefaultValue = "StatusText", DestinationToSourceMethodName = "ToCaptureTextType", SourceDefaultValue = "StatusText", UnmatchedSourceNames = new string[] { "StatusText" }, UnmatchedDestinationNames = new string[] { "None" })]
public static class CaptureSourceTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase ToProtoCaptureSourceType(this CaptureTextType source)
	{
		return source switch
		{
			CaptureTextType.StatusText => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase.None, 
			CaptureTextType.ElapsedTime => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase.ElapsedTime, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase.StatusText, 
		};
	}

	public static CaptureTextType ToCaptureTextType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase.None => CaptureTextType.StatusText, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase.StatusText => CaptureTextType.StatusText, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.CaptureStatusText.TextTypeOneofCase.ElapsedTime => CaptureTextType.ElapsedTime, 
			_ => CaptureTextType.StatusText, 
		};
	}
}
