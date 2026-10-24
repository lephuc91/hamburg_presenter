namespace Pro.Text.RTF.Tokens;

public class ListHybrid : TokenBase
{
	internal const string MatchPattern = "listhybrid";

	public override TokenType TokenType => TokenType.ListHybrid;

	protected internal override string ToRawValue()
	{
		return "listhybrid";
	}
}
