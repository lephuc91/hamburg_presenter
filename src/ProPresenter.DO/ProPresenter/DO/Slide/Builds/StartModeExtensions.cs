using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Builds;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(StartMode), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start), DestinationToSourceMethodName = "Deserialize", SourceDefaultValue = "OnClick", SourceToDestinationMethodName = "Serialize", DestinationDefaultValue = "OnClick")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(StartMode), typeof(ISlide.Types.IElement.Types.IBuild.Types.Start), DestinationToSourceMethodName = "Deserialize", SourceDefaultValue = "OnClick", SourceToDestinationMethodName = "ToEntity", DestinationDefaultValue = "OnClick")]
public static class StartModeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start Serialize(this StartMode source)
	{
		return source switch
		{
			StartMode.OnClick => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.OnClick, 
			StartMode.WithPrevious => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.WithPrevious, 
			StartMode.AfterPrevious => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.AfterPrevious, 
			StartMode.WithSlide => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.WithSlide, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.OnClick, 
		};
	}

	public static StartMode Deserialize(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.OnClick => StartMode.OnClick, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.WithPrevious => StartMode.WithPrevious, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.AfterPrevious => StartMode.AfterPrevious, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build.Types.Start.WithSlide => StartMode.WithSlide, 
			_ => StartMode.OnClick, 
		};
	}

	public static ISlide.Types.IElement.Types.IBuild.Types.Start ToEntity(this StartMode source)
	{
		return source switch
		{
			StartMode.OnClick => ISlide.Types.IElement.Types.IBuild.Types.Start.OnClick, 
			StartMode.WithPrevious => ISlide.Types.IElement.Types.IBuild.Types.Start.WithPrevious, 
			StartMode.AfterPrevious => ISlide.Types.IElement.Types.IBuild.Types.Start.AfterPrevious, 
			StartMode.WithSlide => ISlide.Types.IElement.Types.IBuild.Types.Start.WithSlide, 
			_ => ISlide.Types.IElement.Types.IBuild.Types.Start.OnClick, 
		};
	}

	public static StartMode Deserialize(this ISlide.Types.IElement.Types.IBuild.Types.Start source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IBuild.Types.Start.OnClick => StartMode.OnClick, 
			ISlide.Types.IElement.Types.IBuild.Types.Start.WithPrevious => StartMode.WithPrevious, 
			ISlide.Types.IElement.Types.IBuild.Types.Start.AfterPrevious => StartMode.AfterPrevious, 
			ISlide.Types.IElement.Types.IBuild.Types.Start.WithSlide => StartMode.WithSlide, 
			_ => StartMode.OnClick, 
		};
	}
}
