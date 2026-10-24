using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class GradientColorFill : FillBase
{
	private static readonly System.Windows.Media.Color DefaultStartColor = System.Windows.Media.Color.FromArgb(byte.MaxValue, 2, 91, 233);

	private static readonly System.Windows.Media.Color DefaultStopColor = System.Windows.Media.Color.FromArgb(byte.MaxValue, 2, 196, 250);

	private static readonly Angle<double> DefaultAngle = new Angle<double>(315.0, isCartesian: true);

	private System.Windows.Media.Color _startColor = DefaultStartColor;

	private System.Windows.Media.Color _stopColor = DefaultStopColor;

	private Angle<double> _angle = DefaultAngle;

	public override FillType Type => FillType.Gradient;

	public override string DisplayName => string.Empty;

	public System.Windows.Media.Color StartColor
	{
		get
		{
			return _startColor;
		}
		set
		{
			SetValue("StartColor", ref _startColor, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillStartColor), this, "StartColor", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public System.Windows.Media.Color StopColor
	{
		get
		{
			return _stopColor;
		}
		set
		{
			SetValue("StopColor", ref _stopColor, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillStopColor), this, "StopColor", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public Angle<double> Angle
	{
		get
		{
			return _angle;
		}
		set
		{
			SetValue("Angle", ref _angle, value, delegate(Angle<double> o, Angle<double> n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementGradientFillAngle), this, "Angle", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<GradientColorFill, IGraphics.Types.IFill.Types.IFillType.IGradient> CreateBinder(IUiScheduler uiScheduler, IEntityFactory entityFactory, GradientColorFill left, IGraphics.Types.IFill.Types.IFillType.IGradient right)
	{
		ObjectBinder<GradientColorFill, IGraphics.Types.IFill.Types.IFillType.IGradient> objectBinder = new ObjectBinder<GradientColorFill, IGraphics.Types.IFill.Types.IFillType.IGradient>(left, right);
		objectBinder.Bind((GradientColorFill l) => l.WhenPropertyChanges("Angle"), (IGraphics.Types.IFill.Types.IFillType.IGradient r) => r.Value.Angle.WhenValueChanges, delegate(GradientColorFill l, IGraphics.Types.IFill.Types.IFillType.IGradient r)
		{
			r.Value.Angle.Set(l.Angle.Value);
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IGradient r, GradientColorFill l)
		{
			l.Angle = new Angle<double>(r.Value.Angle.Value);
		}, null, uiScheduler.Scheduler).Bind((GradientColorFill l) => l.WhenPropertyChanges("StartColor").Merge(l.WhenPropertyChanges("StopColor")), (IGraphics.Types.IFill.Types.IFillType.IGradient r) => r.Value.Stops.WhenAnyValueChanges, delegate(GradientColorFill l, IGraphics.Types.IFill.Types.IFillType.IGradient r)
		{
			IGraphics.Types.IGradient.Types.IColorStop colorStop = r.Value.Stops.Items.ElementAtOrDefault(0);
			if (colorStop == null)
			{
				colorStop = entityFactory.Create<IGraphics.Types.IGradient.Types.IColorStop>();
				r.Value.Stops.Add(colorStop);
			}
			colorStop.Color.Set(l.StartColor.ToEntityColor());
			IGraphics.Types.IGradient.Types.IColorStop colorStop2 = r.Value.Stops.Items.ElementAtOrDefault(1);
			if (colorStop2 == null)
			{
				colorStop2 = entityFactory.Create<IGraphics.Types.IGradient.Types.IColorStop>();
				r.Value.Stops.Add(colorStop2);
			}
			colorStop2.Color.Set(l.StopColor.ToEntityColor());
			for (int num = r.Value.Stops.Items.Count - 1; num >= 2; num--)
			{
				r.Value.Stops.RemoveAt(num);
			}
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IGradient r, GradientColorFill l)
		{
			l.StartColor = (r.Value.Stops.Items.ElementAtOrDefault(0)?.Color.Value).ToColor();
			l.StopColor = (r.Value.Stops.Items.ElementAtOrDefault(1)?.Color.Value).ToColor();
		}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other) && other is GradientColorFill gradientColorFill && _startColor == gradientColorFill._startColor && _stopColor == gradientColorFill._stopColor)
		{
			return _angle == gradientColorFill._angle;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), _startColor, _stopColor, _angle);
	}

	public override System.Windows.Media.Color Sample()
	{
		return StartColor * 0.5f + StopColor * 0.5f;
	}

	public override IFill Clone()
	{
		GradientColorFill gradientColorFill = new GradientColorFill
		{
			StartColor = _startColor,
			StopColor = _stopColor,
			Angle = _angle
		};
		CopyProperties(gradientColorFill);
		return gradientColorFill;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		Graphics.Types.Gradient gradient = new Graphics.Types.Gradient
		{
			Angle = Angle.ToProtoAngle()
		};
		gradient.Stops.Add(StartColor.ToProtoColorStop());
		gradient.Stops.Add(StopColor.ToProtoColorStop());
		protoFill.Gradient = gradient;
	}

	protected override void OnDeserialize(Graphics.Types.Fill fill, string containerId)
	{
		StartColor = fill.Gradient.Stops[0].Color.ToColor();
		StopColor = fill.Gradient.Stops[1].Color.ToColor();
		Angle = fill.Gradient.Angle.ToAngle();
	}

	public void SwapGradientColors()
	{
		System.Windows.Media.Color startColor = StartColor;
		StartColor = StopColor;
		StopColor = startColor;
	}
}
