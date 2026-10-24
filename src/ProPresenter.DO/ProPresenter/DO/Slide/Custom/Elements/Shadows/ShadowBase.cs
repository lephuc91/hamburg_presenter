using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Shadows;

public abstract class ShadowBase : NotifyPropertyChangedBase, IShadow, INotifyPropertyChanged, ICloneable<IShadow>, IRenderEquatable<IShadow>, IRenderHashable
{
	private bool _isEnabled;

	private double _blurRadius = 5.0;

	private double _offset = 5.0;

	private double _opacity = 0.75;

	private Angle<double> _angle = new Angle<double>(45.0);

	private System.Windows.Media.Color _color = Colors.Black;

	public abstract ShadowType Type { get; }

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			SetValue("IsEnabled", ref _isEnabled, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowEnabled), this, "IsEnabled", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public double BlurRadius
	{
		get
		{
			return _blurRadius;
		}
		set
		{
			SetValue("BlurRadius", ref _blurRadius, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowBlurRadius), this, "BlurRadius", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public double Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			SetValue("Offset", ref _offset, Math.Max(value, 0.0), delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowOffset), this, "Offset", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public double Opacity
	{
		get
		{
			return _opacity;
		}
		set
		{
			SetValue("Opacity", ref _opacity, value.Clamp(0.0, 1.0), delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowOpacity), this, "Opacity", o, n);
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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowAngle), this, "Angle", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementShadowColor), this, "Color", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? VisualInvalidated;

	public event Action<IShadow>? DataModified;

	public static ObjectBinder<IShadow, IGraphics.Types.IShadow> CreateBinder(IEntityFactory entityFactory, IShadow? left, IGraphics.Types.IShadow? right)
	{
		return new ObjectBinder<IShadow, IGraphics.Types.IShadow>(left, right).Bind((IShadow l) => l.WhenPropertyChanges("IsEnabled"), (IGraphics.Types.IShadow r) => r.Enable.WhenValueChanges, delegate(IShadow l, IGraphics.Types.IShadow r)
		{
			r.Enable.Set(l.IsEnabled);
		}, delegate(IGraphics.Types.IShadow r, IShadow l)
		{
			l.IsEnabled = r.Enable.Value;
		}).Bind((IShadow l) => l.WhenPropertyChanges("BlurRadius"), (IGraphics.Types.IShadow r) => r.Radius.WhenValueChanges, delegate(IShadow l, IGraphics.Types.IShadow r)
		{
			r.Radius.Set(l.BlurRadius);
		}, delegate(IGraphics.Types.IShadow r, IShadow l)
		{
			l.BlurRadius = r.Radius.Value;
		}).Bind((IShadow l) => l.WhenPropertyChanges("Offset"), (IGraphics.Types.IShadow r) => r.Offset.WhenValueChanges, delegate(IShadow l, IGraphics.Types.IShadow r)
		{
			r.Offset.Set(l.Offset);
		}, delegate(IGraphics.Types.IShadow r, IShadow l)
		{
			l.Offset = r.Offset.Value;
		})
			.Bind((IShadow l) => l.WhenPropertyChanges("Opacity"), (IGraphics.Types.IShadow r) => r.Opacity.WhenValueChanges, delegate(IShadow l, IGraphics.Types.IShadow r)
			{
				r.Opacity.Set(l.Opacity);
			}, delegate(IGraphics.Types.IShadow r, IShadow l)
			{
				l.Opacity = r.Opacity.Value;
			})
			.Bind((IShadow l) => l.WhenPropertyChanges("Angle"), (IGraphics.Types.IShadow r) => r.Angle.WhenValueChanges, delegate(IShadow l, IGraphics.Types.IShadow r)
			{
				r.Angle.Set(l.Angle.ToProtoAngle());
			}, delegate(IGraphics.Types.IShadow r, IShadow l)
			{
				l.Angle = r.Angle.Value.ToAngle();
			})
			.Bind((IShadow l) => l.WhenPropertyChanges("Color"), (IGraphics.Types.IShadow r) => r.Color.WhenValueChanges, delegate(IShadow l, IGraphics.Types.IShadow r)
			{
				r.Color.Set(l.Color.ToEntityColor());
			}, delegate(IGraphics.Types.IShadow r, IShadow l)
			{
				l.Color = r.Color.Value.ToColor();
			});
	}

	public bool RenderEquals([NotNullWhen(true)] IShadow? other)
	{
		if (other is ShadowBase shadowBase && _angle == shadowBase._angle && _blurRadius == shadowBase._blurRadius && _color == shadowBase._color && _isEnabled == shadowBase._isEnabled && _offset == shadowBase._offset)
		{
			return _opacity == shadowBase._opacity;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_angle, _blurRadius, _color, _isEnabled, _offset, _opacity);
	}

	public abstract IShadow Clone();

	protected void CopyProperties(ShadowBase shadow)
	{
		shadow._angle = _angle;
		shadow._blurRadius = _blurRadius;
		shadow._color = _color;
		shadow._isEnabled = _isEnabled;
		shadow._offset = _offset;
		shadow._opacity = _opacity;
	}

	public Graphics.Types.Shadow Serialize()
	{
		return new Graphics.Types.Shadow
		{
			Angle = Angle.ToProtoAngle(),
			Color = Color.ToProtoColor(),
			Enable = IsEnabled,
			Offset = Offset,
			Opacity = Opacity,
			Radius = BlurRadius,
			Style = ShadowHelper.GetProtoShadowType(Type)
		};
	}

	public void Deserialize(Graphics.Types.Shadow protoShadow)
	{
		if (protoShadow != null)
		{
			Angle = protoShadow.Angle.ToAngle();
			Color = protoShadow.Color.ToColor();
			IsEnabled = protoShadow.Enable;
			Offset = protoShadow.Offset;
			Opacity = protoShadow.Opacity;
			BlurRadius = protoShadow.Radius;
		}
	}

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}
}
