namespace ProPresenter.DO.Presentation;

public interface ICopyPresentationIdentifier
{
	bool CanPasteFrom(ICopyPresentationIdentifier? source);
}
