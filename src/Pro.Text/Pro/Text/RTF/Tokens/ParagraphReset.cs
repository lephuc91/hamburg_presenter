namespace Pro.Text.RTF.Tokens;

public class ParagraphReset : TokenBase
{
	internal const string MatchPattern = "pard";

	public override TokenType TokenType => TokenType.ParagraphReset;

	protected internal override string ToRawValue()
	{
		return "pard";
	}
}
