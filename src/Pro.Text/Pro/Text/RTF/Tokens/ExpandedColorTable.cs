namespace Pro.Text.RTF.Tokens;

public class ExpandedColorTable : TokenBase
{
	internal const string MatchPattern = "expandedcolortbl";

	public override TokenType TokenType => TokenType.ExpandedColorTable;

	protected internal override string ToRawValue()
	{
		return "expandedcolortbl";
	}
}
