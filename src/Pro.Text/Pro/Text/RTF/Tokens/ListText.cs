namespace Pro.Text.RTF.Tokens;

public class ListText : TokenBase
{
	internal const string MatchPattern = "listtext";

	public override TokenType TokenType => TokenType.ListText;

	protected internal override string ToRawValue()
	{
		return "listtext";
	}
}
