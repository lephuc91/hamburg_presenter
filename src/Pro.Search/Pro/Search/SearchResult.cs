namespace Pro.Search;

public class SearchResult<T>
{
	public T? Item { get; }

	public double Score { get; internal set; }

	public SearchResult(T? item, double score)
	{
		Item = item;
		Score = score;
	}
}
