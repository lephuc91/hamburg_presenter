namespace Pro.Text.RTF.Tokens;

public class ClearScript : TokenBase
{
	internal const string MatchPattern = "nosupersub";

	public override TokenType TokenType => TokenType.ClearScript;

	protected internal override string ToRawValue()
	{
		return "nosupersub";
	}
}
