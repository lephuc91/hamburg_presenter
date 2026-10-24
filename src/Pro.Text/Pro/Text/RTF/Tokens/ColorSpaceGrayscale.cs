namespace Pro.Text.RTF.Tokens;

public class ColorSpaceGrayscale : TokenBase
{
	internal const string MatchPattern = "csgray";

	public override TokenType TokenType => TokenType.ColorSpaceGrayscale;

	protected internal override string ToRawValue()
	{
		return "csgray";
	}
}
