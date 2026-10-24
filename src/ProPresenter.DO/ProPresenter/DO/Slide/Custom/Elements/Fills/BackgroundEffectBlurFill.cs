using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class BackgroundEffectBlurFill : BackgroundEffectFillBase
{
	public const double DEFAULT_BLUR_AMOUNT = 0.5;

	private double _saturation;

	private double _blurAmount = 0.5;

	public double Saturation
	{
		get
		{
			return _saturation;
		}
		set
		{
			SetValue("Saturation", ref _saturation, value, delegate(double o, double n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ElementBackgroundEffectFillBlurSaturation.ToAction(), this, "Saturation", o, n);
				OnDataModified();
			});
		}
	}

	public double BlurAmount
	{
		get
		{
			return _blurAmount;
		}
		set
		{
			SetValue("BlurAmount", ref _blurAmount, value, delegate(double o, double n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ElementBackgroundEffectFillBlurAmmount.ToAction(), this, "BlurAmount", o, n);
				OnDataModified();
			});
		}
	}

	public override FillType Type => FillType.BackgroundEffectBlur;

	public override string DisplayName => LocalizedStrings.Get("GRAPHIC_FILL_BACKGROUND_EFFECT_title") + " - " + LocalizedStrings.Get("GRAPHIC_FILL_BACKGROUND_EFFECT_BLUR_title");

	public static ObjectBinder<BackgroundEffectBlurFill, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect> CreateBinder(IEntityFactory entityFactory, BackgroundEffectBlurFill left, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect right)
	{
		IGraphics.Types.IBackgroundEffect.Types.IEffectType value = right.Value.EffectType.Value;
		IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur backgroundBlur = value as IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur;
		if (backgroundBlur == null)
		{
			backgroundBlur = entityFactory.Create<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur>();
			right.Value.EffectType.Set(backgroundBlur);
		}
		ObjectBinder<BackgroundEffectBlurFill, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect> objectBinder = new ObjectBinder<BackgroundEffectBlurFill, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>(left, right);
		objectBinder.Bind((BackgroundEffectBlurFill l) => l.WhenPropertyChanges("BlurAmount"), (IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect r) => backgroundBlur.Value.BlurAmount.WhenValueChanges, delegate(BackgroundEffectBlurFill l, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect r)
		{
			backgroundBlur.Value.BlurAmount.Set(l.BlurAmount);
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect r, BackgroundEffectBlurFill l)
		{
			l.BlurAmount = backgroundBlur.Value.BlurAmount.Value;
		}).Bind((BackgroundEffectBlurFill l) => l.WhenPropertyChanges("Saturation"), (IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect r) => backgroundBlur.Value.Saturation.WhenValueChanges, delegate(BackgroundEffectBlurFill l, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect r)
		{
			backgroundBlur.Value.Saturation.Set(l.Saturation);
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect r, BackgroundEffectBlurFill l)
		{
			l.Saturation = backgroundBlur.Value.Saturation.Value;
		});
		return objectBinder;
	}

	public override IFill Clone()
	{
		BackgroundEffectBlurFill backgroundEffectBlurFill = new BackgroundEffectBlurFill
		{
			Saturation = Saturation,
			BlurAmount = BlurAmount
		};
		CopyProperties(backgroundEffectBlurFill);
		return backgroundEffectBlurFill;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other) && other is BackgroundEffectBlurFill backgroundEffectBlurFill && Math.Abs(backgroundEffectBlurFill.Saturation - Saturation) < double.Epsilon)
		{
			return Math.Abs(backgroundEffectBlurFill.BlurAmount - BlurAmount) < double.Epsilon;
		}
		return false;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		base.OnSerialize(protoFill);
		protoFill.BackgroundEffect.BackgroundBlur = new Graphics.Types.BackgroundEffect.Types.BackgroundEffectBlur
		{
			BlurAmount = BlurAmount,
			Saturation = Saturation
		};
	}

	protected override void OnDeserialize(Graphics.Types.Fill protoFill, string containerId)
	{
		base.OnDeserialize(protoFill, containerId);
		if (protoFill.BackgroundEffect?.BackgroundBlur != null)
		{
			BlurAmount = protoFill.BackgroundEffect.BackgroundBlur.BlurAmount;
			Saturation = protoFill.BackgroundEffect.BackgroundBlur.Saturation;
		}
	}

	public override System.Windows.Media.Color Sample()
	{
		return Colors.Transparent;
	}
}
