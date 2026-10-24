namespace Pro.Text.RTF.Tokens;

public class ColorTable : TokenBase
{
	internal const string MatchPattern = "colortbl";

	public override TokenType TokenType => TokenType.ColorTable;

	protected internal override string ToRawValue()
	{
		return "colortbl";
	}
}
