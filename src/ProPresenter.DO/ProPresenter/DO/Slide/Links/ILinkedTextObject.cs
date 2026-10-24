using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;

namespace ProPresenter.DO.Slide.Links;

public interface ILinkedTextObject : ILinkedObject, INotifyPropertyChanged, IRenderEquatable<ILinkedTextObject>, IRenderHashable, ICloneable<ILinkedTextObject>
{
	LinkedTextType LinkedTextType { get; }

	FormattingType FormattingType { get; }

	bool SupportsPlaceholderText { get; }

	UndoStack? UndoStack { get; set; }

	event System.Action VisualInvalidated;

	event System.Action DataModified;

	string? GetText(ILinkData? linkData);

	TextDocument? GetFormattedText(ILinkData linkData, TextDocument linkedText);

	void FormatText(ILinkData? linkData, TextDocument? text);

	void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink);
}
