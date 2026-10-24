using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.ClearGroups;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ImageType), typeof(ClearGroupsDocument.Types.ClearGroup.Types.ImageType), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "All", DestinationToSourceMethodName = "ToImageType", SourceDefaultValue = "All")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ImageType), typeof(IClearGroupsDocument.Types.IClearGroup.Types.ImageType), SourceToDestinationMethodName = "ToEntityImageType", DestinationDefaultValue = "All", DestinationToSourceMethodName = "ToImageType", SourceDefaultValue = "All")]
public static class ImageTypeExtensions
{
	public static ClearGroupsDocument.Types.ClearGroup.Types.ImageType ToProto(this ImageType source)
	{
		return source switch
		{
			ImageType.Zero => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Zero, 
			ImageType.One => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.One, 
			ImageType.Two => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Two, 
			ImageType.Three => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Three, 
			ImageType.Four => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Four, 
			ImageType.Five => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Five, 
			ImageType.Six => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Six, 
			ImageType.Seven => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Seven, 
			ImageType.Eight => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Eight, 
			ImageType.Nine => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Nine, 
			ImageType.All => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.All, 
			ImageType.Megahorn => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Megahorn, 
			ImageType.Play => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Play, 
			ImageType.Bulb => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Bulb, 
			ImageType.Sunglasses => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Sunglasses, 
			ImageType.Arrow => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Arrow, 
			ImageType.Target => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Target, 
			ImageType.Star => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Star, 
			ImageType.Sun => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Sun, 
			ImageType.Bell => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Bell, 
			ImageType.Paperclip => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Paperclip, 
			ImageType.Flask => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Flask, 
			ImageType.Eyeglasses => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Eyeglasses, 
			ImageType.Cupcake => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Cupcake, 
			ImageType.Slide => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Slide, 
			ImageType.Hat => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Hat, 
			ImageType.Flower => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Flower, 
			ImageType.Heart => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Heart, 
			ImageType.Message => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Message, 
			ImageType.Audio => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Audio, 
			ImageType.Cloud => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Cloud, 
			ImageType.Exclamation => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Exclamation, 
			ImageType.Custom => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Custom, 
			_ => ClearGroupsDocument.Types.ClearGroup.Types.ImageType.All, 
		};
	}

	public static ImageType ToImageType(this ClearGroupsDocument.Types.ClearGroup.Types.ImageType source)
	{
		return source switch
		{
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Custom => ImageType.Custom, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.One => ImageType.One, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Two => ImageType.Two, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Three => ImageType.Three, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Four => ImageType.Four, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Five => ImageType.Five, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Six => ImageType.Six, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Seven => ImageType.Seven, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Eight => ImageType.Eight, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Nine => ImageType.Nine, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Zero => ImageType.Zero, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.All => ImageType.All, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Megahorn => ImageType.Megahorn, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Play => ImageType.Play, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Bulb => ImageType.Bulb, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Sunglasses => ImageType.Sunglasses, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Arrow => ImageType.Arrow, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Target => ImageType.Target, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Star => ImageType.Star, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Sun => ImageType.Sun, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Bell => ImageType.Bell, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Paperclip => ImageType.Paperclip, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Flask => ImageType.Flask, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Eyeglasses => ImageType.Eyeglasses, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Cupcake => ImageType.Cupcake, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Slide => ImageType.Slide, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Hat => ImageType.Hat, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Flower => ImageType.Flower, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Heart => ImageType.Heart, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Message => ImageType.Message, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Audio => ImageType.Audio, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Cloud => ImageType.Cloud, 
			ClearGroupsDocument.Types.ClearGroup.Types.ImageType.Exclamation => ImageType.Exclamation, 
			_ => ImageType.All, 
		};
	}

	public static IClearGroupsDocument.Types.IClearGroup.Types.ImageType ToEntityImageType(this ImageType source)
	{
		return source switch
		{
			ImageType.Zero => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Zero, 
			ImageType.One => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.One, 
			ImageType.Two => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Two, 
			ImageType.Three => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Three, 
			ImageType.Four => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Four, 
			ImageType.Five => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Five, 
			ImageType.Six => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Six, 
			ImageType.Seven => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Seven, 
			ImageType.Eight => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Eight, 
			ImageType.Nine => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Nine, 
			ImageType.All => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.All, 
			ImageType.Megahorn => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Megahorn, 
			ImageType.Play => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Play, 
			ImageType.Bulb => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Bulb, 
			ImageType.Sunglasses => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Sunglasses, 
			ImageType.Arrow => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Arrow, 
			ImageType.Target => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Target, 
			ImageType.Star => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Star, 
			ImageType.Sun => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Sun, 
			ImageType.Bell => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Bell, 
			ImageType.Paperclip => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Paperclip, 
			ImageType.Flask => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Flask, 
			ImageType.Eyeglasses => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Eyeglasses, 
			ImageType.Cupcake => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Cupcake, 
			ImageType.Slide => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Slide, 
			ImageType.Hat => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Hat, 
			ImageType.Flower => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Flower, 
			ImageType.Heart => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Heart, 
			ImageType.Message => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Message, 
			ImageType.Audio => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Audio, 
			ImageType.Cloud => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Cloud, 
			ImageType.Exclamation => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Exclamation, 
			ImageType.Custom => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Custom, 
			_ => IClearGroupsDocument.Types.IClearGroup.Types.ImageType.All, 
		};
	}

	public static ImageType ToImageType(this IClearGroupsDocument.Types.IClearGroup.Types.ImageType source)
	{
		return source switch
		{
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Custom => ImageType.Custom, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.One => ImageType.One, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Two => ImageType.Two, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Three => ImageType.Three, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Four => ImageType.Four, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Five => ImageType.Five, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Six => ImageType.Six, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Seven => ImageType.Seven, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Eight => ImageType.Eight, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Nine => ImageType.Nine, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Zero => ImageType.Zero, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.All => ImageType.All, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Megahorn => ImageType.Megahorn, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Play => ImageType.Play, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Bulb => ImageType.Bulb, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Sunglasses => ImageType.Sunglasses, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Arrow => ImageType.Arrow, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Target => ImageType.Target, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Star => ImageType.Star, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Sun => ImageType.Sun, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Bell => ImageType.Bell, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Paperclip => ImageType.Paperclip, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Flask => ImageType.Flask, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Eyeglasses => ImageType.Eyeglasses, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Cupcake => ImageType.Cupcake, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Slide => ImageType.Slide, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Hat => ImageType.Hat, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Flower => ImageType.Flower, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Heart => ImageType.Heart, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Message => ImageType.Message, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Audio => ImageType.Audio, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Cloud => ImageType.Cloud, 
			IClearGroupsDocument.Types.IClearGroup.Types.ImageType.Exclamation => ImageType.Exclamation, 
			_ => ImageType.All, 
		};
	}
}
