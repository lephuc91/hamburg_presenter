namespace Pro.Text.RTF.Tokens;

public class ListName : TokenBase
{
	internal const string MatchPattern = "listname";

	public override TokenType TokenType => TokenType.ListName;

	protected internal override string ToRawValue()
	{
		return "listname";
	}
}
