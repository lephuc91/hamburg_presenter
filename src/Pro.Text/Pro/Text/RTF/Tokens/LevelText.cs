namespace Pro.Text.RTF.Tokens;

public class LevelText : TokenBase
{
	internal const string MatchPattern = "leveltext";

	public override TokenType TokenType => TokenType.LevelText;

	protected internal override string ToRawValue()
	{
		return "leveltext";
	}
}
