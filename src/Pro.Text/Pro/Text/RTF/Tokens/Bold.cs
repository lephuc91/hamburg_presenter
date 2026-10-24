namespace Pro.Text.RTF.Tokens;

public class Bold : TokenBase
{
	internal const string MatchPattern = "b(0|)";

	public override TokenType TokenType => TokenType.Bold;

	public bool IsActive { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsActive = value != "0";
	}

	protected internal override string ToRawValue()
	{
		if (!IsActive)
		{
			return "b0";
		}
		return "b";
	}
}
