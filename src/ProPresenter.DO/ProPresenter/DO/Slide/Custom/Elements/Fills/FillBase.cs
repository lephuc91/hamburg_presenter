using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Editor;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public abstract class FillBase : LinkedNotifyPropertyChangedBase, IFill, INotifyPropertyChanged, IRenderEquatable<IFill>, IRenderHashable, ICloneable<IFill>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private bool _isAspectRatioLocked;

	private bool _isEnabled = true;

	private UndoStack? _undoStack;

	public abstract FillType Type { get; }

	public abstract string DisplayName { get; }

	public virtual bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			SetValue("IsEnabled", ref _isEnabled, value, delegate(bool o, bool n)
			{
				OnEnabledChanged();
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementFillEnabled), this, "IsEnabled", o, n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public bool IsAspectRatioLocked
	{
		get
		{
			return _isAspectRatioLocked;
		}
		set
		{
			SetValue("IsAspectRatioLocked", ref _isAspectRatioLocked, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementAspectRatioLocked), this, "IsAspectRatioLocked", o, n);
				OnDataModified();
			});
		}
	}

	public virtual bool IsAspectRatioLockForced => false;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			OnUndoStackChanged(value);
		}
	}

	public string ContainerId { get; protected set; } = "";

	public event System.Action? VisualInvalidated;

	public event Action<IFill>? DataModified;

	public virtual bool RenderEquals([NotNullWhen(true)] IFill? other)
	{
		if (other is FillBase fillBase && _isEnabled == fillBase._isEnabled)
		{
			return _isAspectRatioLocked == fillBase._isAspectRatioLocked;
		}
		return false;
	}

	public virtual int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_isEnabled, _isAspectRatioLocked);
	}

	public virtual ICanvasElement[] GetEditableChildren(ICanvasElement parent)
	{
		return Array.Empty<ICanvasElement>();
	}

	public virtual void OnSizeChanged(Vector2<double> oldSize, Vector2<double> newSize)
	{
	}

	protected virtual void OnEnabledChanged()
	{
	}

	public abstract System.Windows.Media.Color Sample();

	public abstract IFill Clone();

	protected void CopyProperties(FillBase fill)
	{
		fill._isEnabled = _isEnabled;
		fill._isAspectRatioLocked = IsAspectRatioLocked;
		fill.ContainerId = ContainerId;
	}

	public virtual Graphics.Types.Fill Serialize()
	{
		Graphics.Types.Fill fill = new Graphics.Types.Fill
		{
			Enable = _isEnabled
		};
		OnSerialize(fill);
		return fill;
	}

	protected virtual void OnSerialize(Graphics.Types.Fill protoFill)
	{
	}

	public void Deserialize(Graphics.Types.Fill fill, string containerId)
	{
		IsEnabled = fill.Enable;
		OnDeserialize(fill, containerId);
	}

	protected virtual void OnDeserialize(Graphics.Types.Fill protoFill, string containerId)
	{
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	protected virtual void OnUndoStackChanged(UndoStack? value)
	{
	}

	public virtual void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
	}
}
