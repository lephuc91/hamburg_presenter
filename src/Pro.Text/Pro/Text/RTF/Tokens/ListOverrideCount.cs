namespace Pro.Text.RTF.Tokens;

public class ListOverrideCount : TokenBase
{
	internal const string MatchPattern = "listoverridecount([0-9])";

	public override TokenType TokenType => TokenType.ListOverrideCount;

	public int Count { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Count = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"listoverridecount{Count}";
	}
}
