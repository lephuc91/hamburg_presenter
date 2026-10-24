using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Container), typeof(Recording.Types.Stream.Types.Container), SourceToDestinationMethodName = "ToProtoContainer", DestinationToSourceMethodName = "ToContainer", SourceDefaultValue = "Unknown", DestinationDefaultValue = "Unknown", UnmatchedSourceNames = new string[] { "MOV", "MP4" }, UnmatchedDestinationNames = new string[] { "Mov", "Mp4" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Container), typeof(IRecording.Types.IStream.Types.Container), SourceToDestinationMethodName = "ToEntityContainer", DestinationToSourceMethodName = "ToContainer", SourceDefaultValue = "Unknown", DestinationDefaultValue = "Unknown", UnmatchedSourceNames = new string[] { "MOV", "MP4" }, UnmatchedDestinationNames = new string[] { "Mov", "Mp4" })]
public static class ContainerExtensions
{
	public static Recording.Types.Stream.Types.Container ToProtoContainer(this Container source)
	{
		return source switch
		{
			Container.Unknown => Recording.Types.Stream.Types.Container.Unknown, 
			Container.MOV => Recording.Types.Stream.Types.Container.Mov, 
			Container.MP4 => Recording.Types.Stream.Types.Container.Mp4, 
			_ => Recording.Types.Stream.Types.Container.Unknown, 
		};
	}

	public static Container ToContainer(this Recording.Types.Stream.Types.Container source)
	{
		return source switch
		{
			Recording.Types.Stream.Types.Container.Unknown => Container.Unknown, 
			Recording.Types.Stream.Types.Container.Mov => Container.MOV, 
			Recording.Types.Stream.Types.Container.Mp4 => Container.MP4, 
			_ => Container.Unknown, 
		};
	}

	public static IRecording.Types.IStream.Types.Container ToEntityContainer(this Container source)
	{
		return source switch
		{
			Container.Unknown => IRecording.Types.IStream.Types.Container.Unknown, 
			Container.MOV => IRecording.Types.IStream.Types.Container.Mov, 
			Container.MP4 => IRecording.Types.IStream.Types.Container.Mp4, 
			_ => IRecording.Types.IStream.Types.Container.Unknown, 
		};
	}

	public static Container ToContainer(this IRecording.Types.IStream.Types.Container source)
	{
		return source switch
		{
			IRecording.Types.IStream.Types.Container.Unknown => Container.Unknown, 
			IRecording.Types.IStream.Types.Container.Mov => Container.MOV, 
			IRecording.Types.IStream.Types.Container.Mp4 => Container.MP4, 
			_ => Container.Unknown, 
		};
	}
}
