namespace Pro.Text.RTF.Tokens;

public class StyleSheet : TokenBase
{
	internal const string MatchPattern = "stylesheet";

	public override TokenType TokenType => TokenType.StyleSheet;

	protected internal override string ToRawValue()
	{
		return "stylesheet";
	}
}
