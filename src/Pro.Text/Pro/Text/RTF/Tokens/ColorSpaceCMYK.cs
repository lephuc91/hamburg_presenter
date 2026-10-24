namespace Pro.Text.RTF.Tokens;

public class ColorSpaceCMYK : TokenBase
{
	internal const string MatchPattern = "cscmyk";

	public override TokenType TokenType => TokenType.ColorSpaceCMYK;

	protected internal override string ToRawValue()
	{
		return "cscmyk";
	}
}
