using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Feathers;

public class Feather : NotifyPropertyChangedBase, IFeather, INotifyPropertyChanged, IRenderEquatable<IFeather>, IRenderHashable, ICloneable<IFeather>
{
	private bool _isEnabled;

	private double _radius = 0.05;

	private FeatherType _type;

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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementFeatherEnabled), this, "IsEnabled", o, n);
				OnDataModified();
				OnVisualInvalidated();
			});
		}
	}

	public double Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			SetValue("Radius", ref _radius, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementFeatherRadius), this, "Radius", o, n);
				OnDataModified();
				OnVisualInvalidated();
			});
		}
	}

	public FeatherType Type
	{
		get
		{
			return _type;
		}
		set
		{
			SetValue("Type", ref _type, value);
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? VisualInvalidated;

	public event Action<IFeather>? DataModified;

	public static ObjectBinder<IFeather, IGraphics.Types.IFeather> CreateBinder(IFeather? left, IGraphics.Types.IFeather right)
	{
		ObjectBinder<IFeather, IGraphics.Types.IFeather> objectBinder = new ObjectBinder<IFeather, IGraphics.Types.IFeather>(left, right);
		objectBinder.Bind((IFeather l) => l.WhenPropertyChanges("IsEnabled"), (IGraphics.Types.IFeather r) => r.Enable.WhenValueChanges, delegate(IFeather l, IGraphics.Types.IFeather r)
		{
			r.Enable.Set(l.IsEnabled);
		}, delegate(IGraphics.Types.IFeather r, IFeather l)
		{
			l.IsEnabled = r.Enable.Value;
		}).Bind((IFeather l) => l.WhenPropertyChanges("Radius"), (IGraphics.Types.IFeather r) => r.Radius.WhenValueChanges, delegate(IFeather l, IGraphics.Types.IFeather r)
		{
			r.Radius.Set(l.Radius);
		}, delegate(IGraphics.Types.IFeather r, IFeather l)
		{
			l.Radius = r.Radius.Value;
		}).Bind((IFeather l) => l.WhenPropertyChanges("Type"), (IGraphics.Types.IFeather r) => r.Style.WhenValueChanges, delegate(IFeather l, IGraphics.Types.IFeather r)
		{
			r.Style.Set(l.Type.ToEntityFeatherType());
		}, delegate(IGraphics.Types.IFeather r, IFeather l)
		{
			l.Type = r.Style.Value.ToFeatherType();
		});
		return objectBinder;
	}

	public bool RenderEquals([NotNullWhen(true)] IFeather? other)
	{
		if (other is Feather feather && _isEnabled == feather._isEnabled && _radius == feather._radius)
		{
			return _type == feather._type;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_isEnabled, _radius, _type);
	}

	public IFeather Clone()
	{
		return new Feather
		{
			_isEnabled = _isEnabled,
			_radius = _radius,
			_type = _type
		};
	}

	public void Deserialize(Graphics.Types.Feather protoFeather)
	{
		if (protoFeather != null)
		{
			IsEnabled = protoFeather.Enable;
			Type = protoFeather.Style.ToFeatherType();
			Radius = protoFeather.Radius;
		}
	}

	public Graphics.Types.Feather Serialize()
	{
		return new Graphics.Types.Feather
		{
			Enable = IsEnabled,
			Style = Type.ToProtoFeatherType(),
			Radius = Radius
		};
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
