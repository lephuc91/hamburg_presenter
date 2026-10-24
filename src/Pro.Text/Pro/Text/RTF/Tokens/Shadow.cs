namespace Pro.Text.RTF.Tokens;

public class Shadow : TokenBase
{
	internal const string MatchPattern = "shad(0|)";

	public override TokenType TokenType => TokenType.Shadow;

	public bool IsActive { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsActive = value != "0";
	}

	protected internal override string ToRawValue()
	{
		if (!IsActive)
		{
			return "shad0";
		}
		return "shad";
	}
}
