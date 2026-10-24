namespace Pro.Text.RTF.Tokens;

public class LineSpacing : TokenBase
{
	internal const string MatchPattern = "sl(-?[0-9]+)";

	public override TokenType TokenType => TokenType.LineSpacing;

	public double Spacing { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Spacing = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"sl{(int)(Spacing * 20.0)}";
	}
}
