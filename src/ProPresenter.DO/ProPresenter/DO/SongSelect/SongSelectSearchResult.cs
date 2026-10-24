namespace ProPresenter.DO.SongSelect;

public class SongSelectSearchResult : ISongSelectSearchResult
{
	public string ID { get; }

	public int SongNumber { get; }

	public string Title { get; }

	public string Authors { get; }

	public string LyricsPreview { get; }

	public SongSelectSearchResult(string id, int songNumber, string title, string authors, string lyricsPreview)
	{
		ID = id;
		SongNumber = songNumber;
		Title = title;
		Authors = authors;
		LyricsPreview = lyricsPreview;
	}

	public override int GetHashCode()
	{
		return ID.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		if (obj is SongSelectSearchResult songSelectSearchResult)
		{
			return songSelectSearchResult.ID == ID;
		}
		return false;
	}
}
