namespace Pro.Text.RTF.Tokens;

public class ListLevel : TokenBase
{
	internal const string MatchPattern = "listlevel";

	public override TokenType TokenType => TokenType.ListLevel;

	protected internal override string ToRawValue()
	{
		return "listlevel";
	}
}
