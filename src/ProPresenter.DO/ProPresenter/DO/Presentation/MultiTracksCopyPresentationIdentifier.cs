namespace ProPresenter.DO.Presentation;

public record MultiTracksCopyPresentationIdentifier(long SongId) : ICopyPresentationIdentifier
{
	public bool CanPasteFrom(ICopyPresentationIdentifier? source)
	{
		if (source is MultiTracksCopyPresentationIdentifier multiTracksCopyPresentationIdentifier)
		{
			return SongId == multiTracksCopyPresentationIdentifier.SongId;
		}
		return true;
	}
}
