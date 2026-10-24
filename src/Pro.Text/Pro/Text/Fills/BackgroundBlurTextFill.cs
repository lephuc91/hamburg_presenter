using System;
using System.Windows.Media;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;

namespace Pro.Text.Fills;

public class BackgroundBlurTextFill : TextFillBase
{
	public double Blur { get; }

	public override bool IsTransparent => false;

	public override System.Windows.Media.Color PrimaryColor => Colors.White;

	public double Saturation { get; }

	public override TextFillType TextFillType => TextFillType.BackgroundBlur;

	public override bool IsMask => true;

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.IFill> fill)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IFill.IBackgroundEffect backgroundEffect = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IFill.IBackgroundEffect>();
		IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur backgroundBlur = entityFactory.Create<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur>();
		backgroundBlur.Value.BlurAmount.Set(Blur);
		backgroundBlur.Value.Saturation.Set(Saturation);
		backgroundEffect.Value.EffectType.Set(backgroundBlur);
		fill.Set(backgroundEffect);
	}

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute> attributeProperty)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect backgroundEffect = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.IBackgroundEffect>();
		IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur backgroundBlur = entityFactory.Create<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur>();
		backgroundBlur.Value.BlurAmount.Set(Blur);
		backgroundBlur.Value.Saturation.Set(Saturation);
		backgroundEffect.Value.EffectType.Set(backgroundBlur);
		attributeProperty.Set(backgroundEffect);
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.IFill attribute)
	{
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute)
	{
	}

	public BackgroundBlurTextFill()
		: this(0.0, 0.5)
	{
	}

	public BackgroundBlurTextFill(double saturation, double blur)
	{
		Saturation = saturation;
		Blur = blur;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(TextFillType, Blur, Saturation);
	}

	protected override bool OnEquals(TextFillBase other)
	{
		BackgroundBlurTextFill backgroundBlurTextFill = other as BackgroundBlurTextFill;
		if (backgroundBlurTextFill == null)
		{
			return false;
		}
		if (Math.Abs(Saturation - backgroundBlurTextFill.Saturation) < double.Epsilon)
		{
			return Math.Abs(Blur - backgroundBlurTextFill.Blur) < double.Epsilon;
		}
		return false;
	}

	public override TextFillBase Clone()
	{
		return new BackgroundBlurTextFill(Saturation, Blur);
	}
}
