namespace Pro.Text.RTF.Tokens;

public class FontTable : TokenBase
{
	internal const string MatchPattern = "fonttbl";

	public override TokenType TokenType => TokenType.FontTable;

	protected internal override string ToRawValue()
	{
		return "fonttbl";
	}
}
