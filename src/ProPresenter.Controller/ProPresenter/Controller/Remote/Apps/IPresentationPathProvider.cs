using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public interface IPresentationPathProvider
{
	string GetPath(IDocumentCue documentCue);
}
