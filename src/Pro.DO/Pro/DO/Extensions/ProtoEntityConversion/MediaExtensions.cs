using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.ScaleBehavior), typeof(Media.Types.ScaleBehavior), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Fit", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "Fit")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.ScaleAlignment), typeof(Media.Types.ScaleAlignment), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "MiddleCenter", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "MiddleCenter")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.IDrawingProperties.Types.NativeRotationType), typeof(Media.Types.DrawingProperties.Types.NativeRotationType), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "RotateStandard", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "RotateStandard")]
public static class MediaExtensions
{
	public static Media ToProtoMedia(this IMedia source)
	{
		Media media = new Media
		{
			Uuid = source.Uuid.Value.ToUUID(),
			Metadata = source.Metadata.Value.ToProtoMediaMetadata()
		};
		ToProto(source.TypeProperties.Value, media);
		return media;
	}

	public static IMedia ToEntityMedia(this Media source, IEntityFactory entityFactory)
	{
		IMedia media = entityFactory.Create<IMedia>();
		media.Uuid.Set(source.Uuid.ToGuid());
		media.Metadata.Set(source.Metadata.ToEntityMediaMetadata(entityFactory));
		media.TypeProperties.Set(ToEntityTypeProperties(source, entityFactory));
		return media;
	}

	private static void ToProto(IMedia.Types.ITypeProperties value, Media media)
	{
		if (!(value is IMedia.Types.ITypeProperties.IAudio audio))
		{
			if (!(value is IMedia.Types.ITypeProperties.IImage image))
			{
				if (!(value is IMedia.Types.ITypeProperties.IVideo video))
				{
					if (!(value is IMedia.Types.ITypeProperties.ILiveVideo liveVideo))
					{
						if (value is IMedia.Types.ITypeProperties.IWebContent webContent)
						{
							media.WebContent = new Media.Types.WebContentTypeProperties
							{
								Drawing = webContent.Value.Drawing.Value.ToProto(),
								Url = webContent.Value.Url.Value.ToProtoUrl()
							};
						}
					}
					else
					{
						media.LiveVideo = new Media.Types.LiveVideoTypeProperties
						{
							Drawing = liveVideo.Value.Drawing.Value.ToProto(),
							Audio = liveVideo.Value.Audio.Value.ToProto(),
							LiveVideo = liveVideo.Value.LiveVideo.Value.ToProto()
						};
					}
				}
				else
				{
					media.Video = new Media.Types.VideoTypeProperties
					{
						Drawing = video.Value.Drawing.Value.ToProto(),
						Audio = video.Value.Audio.Value.ToProto(),
						Transport = video.Value.Transport.Value.ToProto(),
						Video = video.Value.Video.Value.ToProto(),
						File = video.Value.File.Value.ToProto()
					};
				}
			}
			else
			{
				media.Image = new Media.Types.ImageTypeProperties
				{
					Drawing = image.Value.Drawing.Value.ToProto(),
					File = image.Value.File.Value.ToProto()
				};
			}
		}
		else
		{
			media.Audio = new Media.Types.AudioTypeProperties
			{
				Audio = audio.Value.Audio.Value.ToProto(),
				Transport = audio.Value.Transport.Value.ToProto(),
				File = audio.Value.File.Value.ToProto()
			};
		}
	}

	private static IMedia.Types.ITypeProperties ToEntityTypeProperties(Media source, IEntityFactory entityFactory)
	{
		switch (source.TypePropertiesCase)
		{
		case Media.TypePropertiesOneofCase.Audio:
		{
			IMedia.Types.ITypeProperties.IAudio audio = entityFactory.Create<IMedia.Types.ITypeProperties.IAudio>();
			audio.Value.Audio.Set(source.Audio.Audio.ToEntity(entityFactory));
			audio.Value.Transport.Set(source.Audio.Transport.ToEntity(entityFactory));
			audio.Value.File.Set(source.Audio.File.ToEntity(entityFactory));
			return audio;
		}
		case Media.TypePropertiesOneofCase.Image:
		{
			IMedia.Types.ITypeProperties.IImage image = entityFactory.Create<IMedia.Types.ITypeProperties.IImage>();
			image.Value.Drawing.Set(source.Image.Drawing.ToEntity(entityFactory));
			image.Value.File.Set(source.Image.File.ToEntity(entityFactory));
			return image;
		}
		case Media.TypePropertiesOneofCase.Video:
		{
			IMedia.Types.ITypeProperties.IVideo video = entityFactory.Create<IMedia.Types.ITypeProperties.IVideo>();
			video.Value.Drawing.Set(source.Video.Drawing.ToEntity(entityFactory));
			video.Value.Audio.Set(source.Video.Audio.ToEntity(entityFactory));
			video.Value.Transport.Set(source.Video.Transport.ToEntity(entityFactory));
			video.Value.Video.Set(source.Video.Video.ToEntity(entityFactory));
			video.Value.File.Set(source.Video.File.ToEntity(entityFactory));
			return video;
		}
		case Media.TypePropertiesOneofCase.LiveVideo:
		{
			IMedia.Types.ITypeProperties.ILiveVideo liveVideo = entityFactory.Create<IMedia.Types.ITypeProperties.ILiveVideo>();
			liveVideo.Value.Drawing.Set(source.LiveVideo.Drawing.ToEntity(entityFactory));
			liveVideo.Value.Audio.Set(source.LiveVideo.Audio.ToEntity(entityFactory));
			liveVideo.Value.LiveVideo.Set(source.LiveVideo.LiveVideo.ToEntity(entityFactory));
			return liveVideo;
		}
		case Media.TypePropertiesOneofCase.WebContent:
		{
			IMedia.Types.ITypeProperties.IWebContent webContent = entityFactory.Create<IMedia.Types.ITypeProperties.IWebContent>();
			webContent.Value.Drawing.Set(source.WebContent.Drawing.ToEntity(entityFactory));
			webContent.Value.Url.Set(source.WebContent.Url.ToEntityUrl());
			return webContent;
		}
		default:
			throw new NotSupportedException();
		}
	}

	public static Media.Types.ScaleBehavior ToProto(this IMedia.Types.ScaleBehavior source)
	{
		return source switch
		{
			IMedia.Types.ScaleBehavior.Fit => Media.Types.ScaleBehavior.Fit, 
			IMedia.Types.ScaleBehavior.Fill => Media.Types.ScaleBehavior.Fill, 
			IMedia.Types.ScaleBehavior.Stretch => Media.Types.ScaleBehavior.Stretch, 
			IMedia.Types.ScaleBehavior.Custom => Media.Types.ScaleBehavior.Custom, 
			_ => Media.Types.ScaleBehavior.Fit, 
		};
	}

	public static IMedia.Types.ScaleBehavior ToEntity(this Media.Types.ScaleBehavior source)
	{
		return source switch
		{
			Media.Types.ScaleBehavior.Fit => IMedia.Types.ScaleBehavior.Fit, 
			Media.Types.ScaleBehavior.Fill => IMedia.Types.ScaleBehavior.Fill, 
			Media.Types.ScaleBehavior.Stretch => IMedia.Types.ScaleBehavior.Stretch, 
			Media.Types.ScaleBehavior.Custom => IMedia.Types.ScaleBehavior.Custom, 
			_ => IMedia.Types.ScaleBehavior.Fit, 
		};
	}

	public static Media.Types.ScaleAlignment ToProto(this IMedia.Types.ScaleAlignment source)
	{
		return source switch
		{
			IMedia.Types.ScaleAlignment.MiddleCenter => Media.Types.ScaleAlignment.MiddleCenter, 
			IMedia.Types.ScaleAlignment.TopLeft => Media.Types.ScaleAlignment.TopLeft, 
			IMedia.Types.ScaleAlignment.TopCenter => Media.Types.ScaleAlignment.TopCenter, 
			IMedia.Types.ScaleAlignment.TopRight => Media.Types.ScaleAlignment.TopRight, 
			IMedia.Types.ScaleAlignment.MiddleRight => Media.Types.ScaleAlignment.MiddleRight, 
			IMedia.Types.ScaleAlignment.BottomRight => Media.Types.ScaleAlignment.BottomRight, 
			IMedia.Types.ScaleAlignment.BottomCenter => Media.Types.ScaleAlignment.BottomCenter, 
			IMedia.Types.ScaleAlignment.BottomLeft => Media.Types.ScaleAlignment.BottomLeft, 
			IMedia.Types.ScaleAlignment.MiddleLeft => Media.Types.ScaleAlignment.MiddleLeft, 
			_ => Media.Types.ScaleAlignment.MiddleCenter, 
		};
	}

	public static IMedia.Types.ScaleAlignment ToEntity(this Media.Types.ScaleAlignment source)
	{
		return source switch
		{
			Media.Types.ScaleAlignment.MiddleCenter => IMedia.Types.ScaleAlignment.MiddleCenter, 
			Media.Types.ScaleAlignment.TopLeft => IMedia.Types.ScaleAlignment.TopLeft, 
			Media.Types.ScaleAlignment.TopCenter => IMedia.Types.ScaleAlignment.TopCenter, 
			Media.Types.ScaleAlignment.TopRight => IMedia.Types.ScaleAlignment.TopRight, 
			Media.Types.ScaleAlignment.MiddleRight => IMedia.Types.ScaleAlignment.MiddleRight, 
			Media.Types.ScaleAlignment.BottomRight => IMedia.Types.ScaleAlignment.BottomRight, 
			Media.Types.ScaleAlignment.BottomCenter => IMedia.Types.ScaleAlignment.BottomCenter, 
			Media.Types.ScaleAlignment.BottomLeft => IMedia.Types.ScaleAlignment.BottomLeft, 
			Media.Types.ScaleAlignment.MiddleLeft => IMedia.Types.ScaleAlignment.MiddleLeft, 
			_ => IMedia.Types.ScaleAlignment.MiddleCenter, 
		};
	}

	public static Media.Types.DrawingProperties.Types.NativeRotationType ToProto(this IMedia.Types.IDrawingProperties.Types.NativeRotationType source)
	{
		return source switch
		{
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.RotateStandard => Media.Types.DrawingProperties.Types.NativeRotationType.RotateStandard, 
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate90 => Media.Types.DrawingProperties.Types.NativeRotationType.Rotate90, 
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate180 => Media.Types.DrawingProperties.Types.NativeRotationType.Rotate180, 
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate270 => Media.Types.DrawingProperties.Types.NativeRotationType.Rotate270, 
			_ => Media.Types.DrawingProperties.Types.NativeRotationType.RotateStandard, 
		};
	}

	public static IMedia.Types.IDrawingProperties.Types.NativeRotationType ToEntity(this Media.Types.DrawingProperties.Types.NativeRotationType source)
	{
		return source switch
		{
			Media.Types.DrawingProperties.Types.NativeRotationType.RotateStandard => IMedia.Types.IDrawingProperties.Types.NativeRotationType.RotateStandard, 
			Media.Types.DrawingProperties.Types.NativeRotationType.Rotate90 => IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate90, 
			Media.Types.DrawingProperties.Types.NativeRotationType.Rotate180 => IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate180, 
			Media.Types.DrawingProperties.Types.NativeRotationType.Rotate270 => IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate270, 
			_ => IMedia.Types.IDrawingProperties.Types.NativeRotationType.RotateStandard, 
		};
	}
}
