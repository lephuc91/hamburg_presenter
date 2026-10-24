using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public interface IPresentationEncoder
{
	PresentationResponse Encode(IDocumentCue documentCue, string action, int slideQuality);

	PresentationResponse Encode(IDocumentCue documentCue, string path, string action, int slideQuality);
}
