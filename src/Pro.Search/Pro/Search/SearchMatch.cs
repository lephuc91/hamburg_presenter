namespace Pro.Search;

public struct SearchMatch
{
	public double Weight { get; }

	public MatchType MatchType { get; }

	public SearchMatch(double weight, MatchType matchType)
	{
		Weight = weight;
		MatchType = matchType;
	}
}
