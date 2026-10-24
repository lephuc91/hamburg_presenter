namespace Pro.Text.RTF.Tokens;

public class TabStopRight : TokenBase
{
	internal const string MatchPattern = "tqr";

	public override TokenType TokenType => TokenType.TabStopRight;

	protected internal override string ToRawValue()
	{
		return "tqr";
	}
}
