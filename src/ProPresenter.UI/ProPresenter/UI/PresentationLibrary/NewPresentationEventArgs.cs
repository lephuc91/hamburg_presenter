using ProPresenter.DO.Cues;

namespace ProPresenter.UI.PresentationLibrary;

public class NewPresentationEventArgs
{
	public DocumentCue Document { get; }

	public bool ShouldActivate { get; set; } = true;

	public NewPresentationEventArgs(DocumentCue document)
	{
		Document = document;
	}
}
