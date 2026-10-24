namespace Pro.Search;

public struct IndexField
{
	public string Name { get; }

	public AnalyzerType AnalyzerType { get; }

	public SearchMatch[] SearchMatches { get; }

	public IndexField(string name, double weight, MatchType matchType, AnalyzerType analyzerType = AnalyzerType.Default)
	{
		Name = name;
		AnalyzerType = analyzerType;
		SearchMatches = new SearchMatch[1]
		{
			new SearchMatch(weight, matchType)
		};
	}

	public IndexField(string name, AnalyzerType analyzerType = AnalyzerType.Default, params SearchMatch[] searchMatches)
	{
		Name = name;
		AnalyzerType = analyzerType;
		SearchMatches = searchMatches;
	}
}
