namespace Pro.Text.RTF.Tokens;

public class ExpandedColorComponent : TokenBase
{
	internal const string MatchPattern = "c([0-9]+)";

	public override TokenType TokenType => TokenType.ExpandedColorComponent;

	public double Value { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Value = double.Parse(value) / 100000.0;
	}

	protected internal override string ToRawValue()
	{
		return $"c{(long)(Value * 100000.0)}";
	}
}
