namespace Pro.Text.RTF.Tokens;

public class RightQuote : TokenBase
{
	internal const string MatchPattern = "rquote";

	public override TokenType TokenType => TokenType.RightQuote;

	protected internal override string ToRawValue()
	{
		return "rquote";
	}
}
