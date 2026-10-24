namespace Pro.Text.RTF.Tokens;

public class ParagraphBreak : TokenBase
{
	internal const string MatchPattern = "par";

	public override TokenType TokenType => TokenType.ParagraphBreak;

	protected internal override string ToRawValue()
	{
		return "par";
	}
}
