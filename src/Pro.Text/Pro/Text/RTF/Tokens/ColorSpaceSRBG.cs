namespace Pro.Text.RTF.Tokens;

public class ColorSpaceSRBG : TokenBase
{
	internal const string MatchPattern = "cssrgb";

	public override TokenType TokenType => TokenType.ColorSpaceSRGB;

	protected internal override string ToRawValue()
	{
		return "cssrgb";
	}
}
