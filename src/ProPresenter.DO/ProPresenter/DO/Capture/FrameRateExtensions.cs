using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(FrameRate), typeof(Recording.Types.Stream.Types.FrameRate), SourceToDestinationMethodName = "ToProtoFrameRate", SourceDefaultValue = "Unknown", DestinationToSourceMethodName = "ToFrameRate", DestinationDefaultValue = "Unknown")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(FrameRate), typeof(IRecording.Types.IStream.Types.FrameRate), SourceToDestinationMethodName = "ToEntityFrameRate", SourceDefaultValue = "Unknown", DestinationToSourceMethodName = "ToFrameRate", DestinationDefaultValue = "Unknown")]
public static class FrameRateExtensions
{
	public static FrameRate ToFrameRate(this float frameRate)
	{
		if (frameRate != 24f)
		{
			if (frameRate != 25f)
			{
				if (frameRate != 29.97f)
				{
					if (frameRate != 30f)
					{
						if (frameRate != 50f)
						{
							if (frameRate == 59.9f)
							{
								return FrameRate._5994;
							}
							return FrameRate._60;
						}
						return FrameRate._50;
					}
					return FrameRate._30;
				}
				return FrameRate._2997;
			}
			return FrameRate._25;
		}
		return FrameRate._24;
	}

	public static float ToFloat(this FrameRate frameRate)
	{
		return frameRate switch
		{
			FrameRate._24 => 24f, 
			FrameRate._25 => 25f, 
			FrameRate._2997 => 29.97f, 
			FrameRate._30 => 30f, 
			FrameRate._50 => 50f, 
			FrameRate._5994 => 59.9f, 
			_ => 60f, 
		};
	}

	public static string GetString(this FrameRate frameRate)
	{
		return frameRate switch
		{
			FrameRate._24 => "24", 
			FrameRate._25 => "25", 
			FrameRate._2997 => "29.97", 
			FrameRate._30 => "30", 
			FrameRate._50 => "50", 
			FrameRate._5994 => "59.94", 
			FrameRate._60 => "60", 
			_ => string.Empty, 
		};
	}

	public static Recording.Types.Stream.Types.FrameRate ToProtoFrameRate(this FrameRate source)
	{
		return source switch
		{
			FrameRate.Unknown => Recording.Types.Stream.Types.FrameRate.Unknown, 
			FrameRate._24 => Recording.Types.Stream.Types.FrameRate._24, 
			FrameRate._25 => Recording.Types.Stream.Types.FrameRate._25, 
			FrameRate._2997 => Recording.Types.Stream.Types.FrameRate._2997, 
			FrameRate._30 => Recording.Types.Stream.Types.FrameRate._30, 
			FrameRate._50 => Recording.Types.Stream.Types.FrameRate._50, 
			FrameRate._5994 => Recording.Types.Stream.Types.FrameRate._5994, 
			FrameRate._60 => Recording.Types.Stream.Types.FrameRate._60, 
			_ => Recording.Types.Stream.Types.FrameRate.Unknown, 
		};
	}

	public static FrameRate ToFrameRate(this Recording.Types.Stream.Types.FrameRate source)
	{
		return source switch
		{
			Recording.Types.Stream.Types.FrameRate.Unknown => FrameRate.Unknown, 
			Recording.Types.Stream.Types.FrameRate._24 => FrameRate._24, 
			Recording.Types.Stream.Types.FrameRate._25 => FrameRate._25, 
			Recording.Types.Stream.Types.FrameRate._2997 => FrameRate._2997, 
			Recording.Types.Stream.Types.FrameRate._30 => FrameRate._30, 
			Recording.Types.Stream.Types.FrameRate._50 => FrameRate._50, 
			Recording.Types.Stream.Types.FrameRate._5994 => FrameRate._5994, 
			Recording.Types.Stream.Types.FrameRate._60 => FrameRate._60, 
			_ => FrameRate.Unknown, 
		};
	}

	public static IRecording.Types.IStream.Types.FrameRate ToEntityFrameRate(this FrameRate source)
	{
		return source switch
		{
			FrameRate.Unknown => IRecording.Types.IStream.Types.FrameRate.Unknown, 
			FrameRate._24 => IRecording.Types.IStream.Types.FrameRate._24, 
			FrameRate._25 => IRecording.Types.IStream.Types.FrameRate._25, 
			FrameRate._2997 => IRecording.Types.IStream.Types.FrameRate._2997, 
			FrameRate._30 => IRecording.Types.IStream.Types.FrameRate._30, 
			FrameRate._50 => IRecording.Types.IStream.Types.FrameRate._50, 
			FrameRate._5994 => IRecording.Types.IStream.Types.FrameRate._5994, 
			FrameRate._60 => IRecording.Types.IStream.Types.FrameRate._60, 
			_ => IRecording.Types.IStream.Types.FrameRate.Unknown, 
		};
	}

	public static FrameRate ToFrameRate(this IRecording.Types.IStream.Types.FrameRate source)
	{
		return source switch
		{
			IRecording.Types.IStream.Types.FrameRate.Unknown => FrameRate.Unknown, 
			IRecording.Types.IStream.Types.FrameRate._24 => FrameRate._24, 
			IRecording.Types.IStream.Types.FrameRate._25 => FrameRate._25, 
			IRecording.Types.IStream.Types.FrameRate._2997 => FrameRate._2997, 
			IRecording.Types.IStream.Types.FrameRate._30 => FrameRate._30, 
			IRecording.Types.IStream.Types.FrameRate._50 => FrameRate._50, 
			IRecording.Types.IStream.Types.FrameRate._5994 => FrameRate._5994, 
			IRecording.Types.IStream.Types.FrameRate._60 => FrameRate._60, 
			_ => FrameRate.Unknown, 
		};
	}
}
