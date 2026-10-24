namespace Pro.Text.RTF.Tokens;

public class ColorSpaceGenericRGB : TokenBase
{
	internal const string MatchPattern = "csgenericrgb";

	public override TokenType TokenType => TokenType.ColorSpaceGenericRGB;

	protected internal override string ToRawValue()
	{
		return "csgenericrgb";
	}
}
