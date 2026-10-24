using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public static class FillGenerator
{
	public static IFill GenerateFill(this FillType type, IMediaFactory factory, string containerId)
	{
		return type switch
		{
			FillType.Solid => new SolidColorFill(), 
			FillType.Gradient => new GradientColorFill(), 
			FillType.Media => new MediaFill(factory, containerId), 
			FillType.Live => new LiveVideoFill(factory), 
			FillType.HTML => new HTMLFill(), 
			FillType.SlidePreview => new SlidePreviewFill(null, includeBackground: false, null), 
			FillType.OutputScreen => new OutputScreenFill(), 
			FillType.PDF => new PDFFill(null), 
			FillType.Bitmap => new BitmapFill(null), 
			FillType.BackgroundEffectBlur => new BackgroundEffectBlurFill(), 
			FillType.BackgroundEffectInvert => new BackgroundEffectInvertFill(), 
			_ => new SolidColorFill(), 
		};
	}

	private static IFill GenerateFill(Graphics.Types.Fill fill, IMediaFactory factory, string containerId)
	{
		switch (fill.FillTypeCase)
		{
		case Graphics.Types.Fill.FillTypeOneofCase.None:
		case Graphics.Types.Fill.FillTypeOneofCase.Color:
			return new SolidColorFill();
		case Graphics.Types.Fill.FillTypeOneofCase.Gradient:
			return new GradientColorFill();
		case Graphics.Types.Fill.FillTypeOneofCase.Media:
			return GenerateMediaFill(fill, factory, containerId);
		case Graphics.Types.Fill.FillTypeOneofCase.BackgroundEffect:
			return fill.BackgroundEffect.EffectTypeCase switch
			{
				Graphics.Types.BackgroundEffect.EffectTypeOneofCase.None => new SolidColorFill(), 
				Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundBlur => new BackgroundEffectBlurFill(), 
				Graphics.Types.BackgroundEffect.EffectTypeOneofCase.BackgroundInvert => new BackgroundEffectInvertFill(), 
				_ => new SolidColorFill(), 
			};
		default:
			return new SolidColorFill();
		}
	}

	private static IFill GenerateMediaFill(Graphics.Types.Fill fill, IMediaFactory factory, string containerId)
	{
		if (fill.Media.LiveVideo != null)
		{
			return new LiveVideoFill(factory);
		}
		if (fill.Media.WebContent != null)
		{
			return new HTMLFill();
		}
		return new MediaFill(factory, containerId);
	}

	public static IFill DeserializeFill(Graphics.Types.Fill fill, IMediaFactory factoryProvider, string containerId)
	{
		IFill fill2 = GenerateFill(fill, factoryProvider, containerId);
		fill2.Deserialize(fill, containerId);
		return fill2;
	}
}
