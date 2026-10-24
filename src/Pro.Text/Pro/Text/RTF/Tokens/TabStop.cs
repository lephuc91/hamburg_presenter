namespace Pro.Text.RTF.Tokens;

public class TabStop : TokenBase
{
	internal const string MatchPattern = "tx([0-9]+)";

	public override TokenType TokenType => TokenType.TabStop;

	public double Position { get; set; }

	public TabStopType Type { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Position = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"tx{(int)(Position * 20.0)}";
	}
}
