namespace Pro.Text.RTF.Tokens;

public class ListOverride : TokenBase
{
	internal const string MatchPattern = "listoverride";

	public override TokenType TokenType => TokenType.ListOverride;

	protected internal override string ToRawValue()
	{
		return "listoverride";
	}
}
