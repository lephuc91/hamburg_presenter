using System.Diagnostics.CodeAnalysis;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class PresentationNotesLinkedObject : LinkedTextObjectBase
{
	public override LinkedTextType LinkedTextType => LinkedTextType.PresentationNotes;

	public override string DisplayText => LocalizedStrings.Get("TEXT_LINK_PRESENTATION_NOTES_title");

	public override FormattingType FormattingType => FormattingType.None;

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is PresentationNotesLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return 0;
	}

	public override ILinkedTextObject Clone()
	{
		return new PresentationNotesLinkedObject();
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.PresentationNotes = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PresentationNotes();
	}

	public override string GetText(ILinkData? linkData)
	{
		return linkData?.PresentationInfo?.Notes ?? DisplayText;
	}
}
