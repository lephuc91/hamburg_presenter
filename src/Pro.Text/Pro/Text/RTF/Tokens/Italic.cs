namespace Pro.Text.RTF.Tokens;

public class Italic : TokenBase
{
	internal const string MatchPattern = "i(0|)";

	public override TokenType TokenType => TokenType.Italic;

	public bool IsActive { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsActive = value != "0";
	}

	protected internal override string ToRawValue()
	{
		if (!IsActive)
		{
			return "i0";
		}
		return "i";
	}
}
