using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public abstract class LinkedFillObjectBase : LinkedNotifyPropertyChangedBase, ILinkedFillObject, ILinkedObject, INotifyPropertyChanged, IRenderEquatable<ILinkedFillObject>, IRenderHashable, ICloneable<ILinkedFillObject>
{
	public abstract LinkedFillType LinkedFillType { get; }

	public virtual bool IsValid => true;

	public abstract string DisplayText { get; }

	public UndoStack? UndoStack { get; set; }

	public virtual SlideTargetSourceMode TargetSourceMode { get; set; }

	public abstract bool RenderEquals(ILinkedFillObject? other);

	public abstract int GetRenderHashCode();

	public abstract IFill? GetFill(ILinkData? linkData);

	public abstract ILinkedFillObject Clone();

	public abstract void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink);

	public virtual void Teardown()
	{
	}
}
