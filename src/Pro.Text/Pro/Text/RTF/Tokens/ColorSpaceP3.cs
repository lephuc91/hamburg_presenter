namespace Pro.Text.RTF.Tokens;

public class ColorSpaceP3 : TokenBase
{
	internal const string MatchPattern = "cspthree";

	public override TokenType TokenType => TokenType.ColorSpaceP3;

	protected internal override string ToRawValue()
	{
		return "cspthree";
	}
}
