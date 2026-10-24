namespace ProPresenter.DO.Presentation;

public class CustomPresentationCopyIdentifier : ICopyPresentationIdentifier
{
	public bool CanPasteFrom(ICopyPresentationIdentifier? source)
	{
		return !(source is MultiTracksCopyPresentationIdentifier);
	}
}
