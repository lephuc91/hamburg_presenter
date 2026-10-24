using Pro.Text;

namespace ProPresenter.DO.Bibles;

public class SearchResult
{
	public VerseContent Verse { get; }

	public string PassageText { get; }

	public Range[] KeywordRanges { get; }

	public SearchResult(VerseContent content, Range[] keywordRange, string passageText)
	{
		Verse = content;
		KeywordRanges = keywordRange ?? new Range[0];
		PassageText = passageText;
	}
}
