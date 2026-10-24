using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public abstract class LinkBase : NotifyPropertyChangedBase, ILink, IRenderEquatable<ILink>, IRenderHashable, ICloneable<ILink>
{
	private UndoStack? _undoStack;

	private bool _isEnabled;

	public abstract LinkType LinkType { get; }

	public abstract string? DisplayText { get; }

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			OnUndoStackChanged(_undoStack);
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
				OnLinkObjectUpdated();
				UndoStack?.Commit(UndoActionTypes.TextLinkEnabled.ToAction(), this, "IsEnabled", o, n);
			});
		}
	}

	public event System.Action? LinkObjectUpdated;

	public event System.Action? VisualInvalidated;

	public virtual bool RenderEquals([NotNullWhen(true)] ILink? other)
	{
		if (other is LinkBase linkBase)
		{
			return _isEnabled == linkBase._isEnabled;
		}
		return false;
	}

	public virtual int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_isEnabled);
	}

	public abstract ILink Clone();

	public abstract Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink Serialize();

	protected virtual void OnUndoStackChanged(UndoStack? undoStack)
	{
	}

	protected void CopyProperties(LinkBase other)
	{
		other._isEnabled = _isEnabled;
	}

	protected void OnLinkObjectUpdated()
	{
		this.LinkObjectUpdated?.Invoke();
	}

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}
}
