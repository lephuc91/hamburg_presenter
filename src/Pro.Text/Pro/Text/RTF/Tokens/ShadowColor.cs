namespace Pro.Text.RTF.Tokens;

public class ShadowColor : TokenBase
{
	internal const string MatchPattern = "shadc([0-9]+)";

	public override TokenType TokenType => TokenType.ShadowColor;

	public int ColorIndex { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		ColorIndex = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"shadc{ColorIndex}";
	}
}
