namespace Pro.Text.RTF.Tokens;

public class EmDash : TokenBase
{
	internal const string MatchPattern = "emdash";

	public const string UnicodeCharacter = "—";

	public override TokenType TokenType => TokenType.EmDash;

	protected internal override string ToRawValue()
	{
		return "emdash";
	}
}
