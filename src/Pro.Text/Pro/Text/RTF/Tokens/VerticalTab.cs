namespace Pro.Text.RTF.Tokens;

public class VerticalTab : TokenBase
{
	internal const string MatchPattern = "\\v";

	public override TokenType TokenType => TokenType.ParagraphBreak;

	protected internal override string ToRawValue()
	{
		return "\v";
	}
}
