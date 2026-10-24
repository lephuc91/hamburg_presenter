using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

public interface ILinkedFillObject : ILinkedObject, INotifyPropertyChanged, IRenderEquatable<ILinkedFillObject>, IRenderHashable, ICloneable<ILinkedFillObject>
{
	LinkedFillType LinkedFillType { get; }

	bool IsValid { get; }

	UndoStack? UndoStack { get; set; }

	SlideTargetSourceMode TargetSourceMode { get; }

	IFill? GetFill(ILinkData? linkData);

	void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink);

	void Teardown();
}
