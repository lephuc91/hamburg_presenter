namespace ProPresenter.DO.SongSelect;

public interface ISongSelectSearchResult
{
	string Authors { get; }

	string ID { get; }

	int SongNumber { get; }

	string Title { get; }

	string LyricsPreview { get; }
}
