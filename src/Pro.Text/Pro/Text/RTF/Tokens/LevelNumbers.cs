namespace Pro.Text.RTF.Tokens;

public class LevelNumbers : TokenBase
{
	internal const string MatchPattern = "levelnumbers";

	public override TokenType TokenType => TokenType.LevelNumbers;

	protected internal override string ToRawValue()
	{
		return "levelnumbers";
	}
}
