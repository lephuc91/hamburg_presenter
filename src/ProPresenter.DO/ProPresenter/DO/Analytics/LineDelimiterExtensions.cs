using ProPresenter.DO.Import;

namespace ProPresenter.DO.Analytics;

public static class LineDelimiterExtensions
{
	public static LineDelimiter ToLineDelimiter(this BreakMode breakMode)
	{
		return breakMode switch
		{
			BreakMode.BlankLine => LineDelimiter.ParagraphBreak, 
			BreakMode.NewLine => LineDelimiter.LineBreak, 
			_ => LineDelimiter.Unknown, 
		};
	}
}
