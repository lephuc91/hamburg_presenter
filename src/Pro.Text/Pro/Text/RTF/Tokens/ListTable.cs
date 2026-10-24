namespace Pro.Text.RTF.Tokens;

public class ListTable : TokenBase
{
	internal const string MatchPattern = "listtable";

	public override TokenType TokenType => TokenType.ListTable;

	protected internal override string ToRawValue()
	{
		return "listtable";
	}
}
