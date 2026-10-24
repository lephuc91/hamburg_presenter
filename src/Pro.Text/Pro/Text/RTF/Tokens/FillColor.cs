namespace Pro.Text.RTF.Tokens;

public class FillColor : TokenBase
{
	internal const string MatchPattern = "cf([0-9]+)";

	public override TokenType TokenType => TokenType.FillColor;

	public int ColorIndex { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		ColorIndex = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"cf{ColorIndex}";
	}
}
