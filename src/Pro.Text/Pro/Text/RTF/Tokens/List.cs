namespace Pro.Text.RTF.Tokens;

public class List : TokenBase
{
	internal const string MatchPattern = "list";

	public override TokenType TokenType => TokenType.List;

	protected internal override string ToRawValue()
	{
		return "list";
	}
}
