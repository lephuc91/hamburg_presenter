namespace ProPresenter.DO.MultiTracks;

public class MultiTracksSearchResults
{
	public int TotalResults { get; }

	public int TotalPages { get; }

	public int PageNumber { get; }

	public MultiTracksSearchResult[] Items { get; }

	internal MultiTracksSearchResults(int totalResults, int totalPages, int pageNumber, MultiTracksSearchResult[] items)
	{
		TotalResults = totalResults;
		TotalPages = totalPages;
		PageNumber = pageNumber;
		Items = items;
	}
}
