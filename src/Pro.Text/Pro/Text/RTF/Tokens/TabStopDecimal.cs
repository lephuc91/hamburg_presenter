namespace Pro.Text.RTF.Tokens;

public class TabStopDecimal : TokenBase
{
	internal const string MatchPattern = "tqdec";

	public override TokenType TokenType => TokenType.TabStopDecimal;

	protected internal override string ToRawValue()
	{
		return "tqdec";
	}
}
