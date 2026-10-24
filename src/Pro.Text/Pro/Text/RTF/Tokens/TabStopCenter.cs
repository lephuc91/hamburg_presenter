namespace Pro.Text.RTF.Tokens;

public class TabStopCenter : TokenBase
{
	internal const string MatchPattern = "tqc";

	public override TokenType TokenType => TokenType.TabStopCenter;

	protected internal override string ToRawValue()
	{
		return "tqc";
	}
}
