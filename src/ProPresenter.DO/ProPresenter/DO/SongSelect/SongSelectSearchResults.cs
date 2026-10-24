namespace ProPresenter.DO.SongSelect;

public class SongSelectSearchResults
{
	public int TotalResults { get; }

	public SongSelectSearchResult[] Items { get; }

	internal SongSelectSearchResults(int totalResults, SongSelectSearchResult[] items)
	{
		TotalResults = totalResults;
		Items = items;
	}
}
