namespace Pro.Text.RTF.Tokens;

public class LeftQuote : TokenBase
{
	internal const string MatchPattern = "lquote";

	public override TokenType TokenType => TokenType.LeftQuote;

	protected internal override string ToRawValue()
	{
		return "lquote";
	}
}
