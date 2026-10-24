namespace Pro.Text.RTF.Tokens;

public class Strikethrough : TokenBase
{
	internal const string MatchPattern = "strike(0|)";

	public override TokenType TokenType => TokenType.Strikethrough;

	public bool IsActive { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsActive = value != "0";
	}

	protected internal override string ToRawValue()
	{
		if (!IsActive)
		{
			return "strike0";
		}
		return "strike";
	}
}
