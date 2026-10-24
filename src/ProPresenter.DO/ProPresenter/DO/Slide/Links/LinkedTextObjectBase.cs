using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;

namespace ProPresenter.DO.Slide.Links;

public abstract class LinkedTextObjectBase : LinkedNotifyPropertyChangedBase, ILinkedTextObject, ILinkedObject, INotifyPropertyChanged, IRenderEquatable<ILinkedTextObject>, IRenderHashable, ICloneable<ILinkedTextObject>
{
	private UndoStack? _undoStack;

	public abstract LinkedTextType LinkedTextType { get; }

	public abstract string DisplayText { get; }

	public abstract FormattingType FormattingType { get; }

	public virtual bool SupportsPlaceholderText { get; }

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

	public event System.Action? VisualInvalidated;

	public event System.Action? DataModified;

	public abstract bool RenderEquals(ILinkedTextObject? other);

	public abstract int GetRenderHashCode();

	public virtual string? GetText(ILinkData? linkData)
	{
		return string.Empty;
	}

	public virtual TextDocument? GetFormattedText(ILinkData linkData, TextDocument linkedText)
	{
		return null;
	}

	public virtual void FormatText(ILinkData? linkData, TextDocument? text)
	{
	}

	protected virtual void OnUndoStackChanged(UndoStack? undoStack)
	{
	}

	public abstract ILinkedTextObject Clone();

	public abstract void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink);

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
