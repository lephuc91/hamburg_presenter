using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class BackgroundEffectInvertFill : BackgroundEffectFillBase
{
	public override FillType Type => FillType.BackgroundEffectInvert;

	public override string DisplayName => LocalizedStrings.Get("GRAPHIC_FILL_BACKGROUND_EFFECT_title") + " - " + LocalizedStrings.Get("GRAPHIC_FILL_BACKGROUND_EFFECT_INVERT_title");

	public override IFill Clone()
	{
		BackgroundEffectInvertFill backgroundEffectInvertFill = new BackgroundEffectInvertFill();
		CopyProperties(backgroundEffectInvertFill);
		return backgroundEffectInvertFill;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other))
		{
			return other is BackgroundEffectInvertFill;
		}
		return false;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		base.OnSerialize(protoFill);
		protoFill.BackgroundEffect.BackgroundInvert = new Graphics.Types.BackgroundEffect.Types.BackgroundEffectInvert();
	}

	public override System.Windows.Media.Color Sample()
	{
		return Colors.Transparent;
	}
}
