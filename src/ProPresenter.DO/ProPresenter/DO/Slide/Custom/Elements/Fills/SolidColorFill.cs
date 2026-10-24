using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class SolidColorFill : FillBase
{
	private static readonly System.Windows.Media.Color DefaultColor = Colors.DodgerBlue;

	private System.Windows.Media.Color _color = DefaultColor;

	public override FillType Type => FillType.Solid;

	public override string DisplayName => string.Empty;

	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementSolidColorFill), this, "Color", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<SolidColorFill, IGraphics.Types.IFill.Types.IFillType.IColor> CreateBinder(IUiScheduler uiScheduler, SolidColorFill left, IGraphics.Types.IFill.Types.IFillType.IColor right)
	{
		ObjectBinder<SolidColorFill, IGraphics.Types.IFill.Types.IFillType.IColor> objectBinder = new ObjectBinder<SolidColorFill, IGraphics.Types.IFill.Types.IFillType.IColor>(left, right);
		objectBinder.Bind((SolidColorFill l) => l.WhenPropertyChanges("Color"), (IGraphics.Types.IFill.Types.IFillType.IColor r) => r.WhenValueChanges, delegate(SolidColorFill l, IGraphics.Types.IFill.Types.IFillType.IColor r)
		{
			r.Set(l.Color.ToEntityColor());
		}, delegate(IGraphics.Types.IFill.Types.IFillType.IColor r, SolidColorFill l)
		{
			l.Color = r.Value.ToColor();
		}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	public override bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (base.RenderEquals(other) && other is SolidColorFill solidColorFill)
		{
			return _color == solidColorFill.Color;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(base.GetRenderHashCode(), Color);
	}

	public override System.Windows.Media.Color Sample()
	{
		return Color;
	}

	public override IFill Clone()
	{
		SolidColorFill solidColorFill = new SolidColorFill
		{
			Color = Color
		};
		CopyProperties(solidColorFill);
		return solidColorFill;
	}

	protected override void OnSerialize(Graphics.Types.Fill protoFill)
	{
		protoFill.Color = Color.ToProtoColor();
	}

	protected override void OnDeserialize(Graphics.Types.Fill fill, string containerId)
	{
		Color = fill?.Color?.ToColor() ?? DefaultColor;
	}
}
