using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Strokes;

public class Stroke : NotifyPropertyChangedBase, IStroke, INotifyPropertyChanged, IRenderEquatable<IStroke>, IRenderHashable, ICloneable<IStroke>
{
	private StrokeStyle _style;

	private bool _isEnabled;

	private System.Windows.Media.Color _strokeColor = Colors.White;

	private double _strokeThickness = 3.0;

	public StrokeType Type => StrokeType.Default;

	public StrokeStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			SetValue("Style", ref _style, value, delegate(StrokeStyle o, StrokeStyle n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementStrokeStyle), this, "Style", o, n);
				Pattern = n.GetAttribute<StrokeStyle, StrokePatternAttribute>()?.Pattern ?? Array.Empty<double>();
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementStrokeEnabled), this, "IsEnabled", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public System.Windows.Media.Color StrokeColor
	{
		get
		{
			return _strokeColor;
		}
		set
		{
			SetValue("StrokeColor", ref _strokeColor, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementStrokeColor), this, "StrokeColor", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public double StrokeThickness
	{
		get
		{
			return _strokeThickness;
		}
		set
		{
			SetValue("StrokeThickness", ref _strokeThickness, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementStrokeThickness), this, "StrokeThickness", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public double[] Pattern { get; protected set; } = Array.Empty<double>();

	public UndoStack? UndoStack { get; set; }

	public event System.Action? VisualInvalidated;

	public event Action<IStroke>? DataModified;

	public static ObjectBinder<IStroke, IGraphics.Types.IStroke> CreateBinder(IStroke? left, IGraphics.Types.IStroke right)
	{
		ObjectBinder<IStroke, IGraphics.Types.IStroke> objectBinder = new ObjectBinder<IStroke, IGraphics.Types.IStroke>(left, right);
		objectBinder.Bind((IStroke l) => l.WhenPropertyChanges("IsEnabled"), (IGraphics.Types.IStroke r) => r.Enable.WhenValueChanges, delegate(IStroke l, IGraphics.Types.IStroke r)
		{
			r.Enable.Set(l.IsEnabled);
		}, delegate(IGraphics.Types.IStroke r, IStroke l)
		{
			l.IsEnabled = r.Enable.Value;
		}).Bind((IStroke l) => l.WhenPropertyChanges("StrokeColor"), (IGraphics.Types.IStroke r) => r.Color.WhenValueChanges, delegate(IStroke l, IGraphics.Types.IStroke r)
		{
			r.Color.Set(l.StrokeColor.ToEntityColor());
		}, delegate(IGraphics.Types.IStroke r, IStroke l)
		{
			l.StrokeColor = r.Color.Value.ToColor();
		}).Bind((IStroke l) => l.WhenPropertyChanges("StrokeThickness"), (IGraphics.Types.IStroke r) => r.Width.WhenValueChanges, delegate(IStroke l, IGraphics.Types.IStroke r)
		{
			r.Width.Set(l.StrokeThickness);
		}, delegate(IGraphics.Types.IStroke r, IStroke l)
		{
			l.StrokeThickness = r.Width.Value;
		})
			.Bind((IStroke l) => l.WhenPropertyChanges("Type"), (IGraphics.Types.IStroke r) => r.Width.WhenValueChanges, delegate(IStroke l, IGraphics.Types.IStroke r)
			{
				r.Style.Set(l.Style.ToEntityStrokeStyle());
			}, delegate(IGraphics.Types.IStroke r, IStroke l)
			{
				l.Style = r.Style.Value.ToStrokeStyle();
			});
		return objectBinder;
	}

	public bool RenderEquals([NotNullWhen(true)] IStroke? other)
	{
		if (other is Stroke stroke && _style == stroke._style && _isEnabled == stroke._isEnabled && _strokeColor == stroke._strokeColor && _strokeThickness == stroke._strokeThickness)
		{
			return Pattern.ContentsMatchExactly(stroke.Pattern);
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(new IEnumerable[1] { Pattern }, _style, _isEnabled, _strokeColor, _strokeThickness);
	}

	public IStroke Clone()
	{
		return new Stroke
		{
			_style = _style,
			_isEnabled = _isEnabled,
			_strokeColor = _strokeColor,
			_strokeThickness = _strokeThickness,
			Pattern = Pattern
		};
	}

	public Graphics.Types.Stroke Serialize()
	{
		Graphics.Types.Stroke stroke = new Graphics.Types.Stroke();
		stroke.Enable = IsEnabled;
		stroke.Style = Style.ToProtoStrokeStyle();
		stroke.Color = StrokeColor.ToProtoColor();
		stroke.Width = StrokeThickness;
		stroke.Pattern.AddRange(Pattern);
		return stroke;
	}

	public void Deserialize(Graphics.Types.Stroke protoStroke)
	{
		if (protoStroke != null)
		{
			IsEnabled = protoStroke.Enable;
			Style = protoStroke.Style.ToStrokeStyle();
			StrokeThickness = protoStroke.Width;
			if (protoStroke.Color != null)
			{
				StrokeColor = protoStroke.Color.ToColor();
			}
			Pattern = protoStroke.Pattern.ToArray();
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
