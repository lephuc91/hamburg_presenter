namespace Pro.Text.RTF.Tokens;

public class ListOverrideTable : TokenBase
{
	internal const string MatchPattern = "listoverridetable";

	public override TokenType TokenType => TokenType.ListOverrideTable;

	protected internal override string ToRawValue()
	{
		return "listoverridetable";
	}
}
