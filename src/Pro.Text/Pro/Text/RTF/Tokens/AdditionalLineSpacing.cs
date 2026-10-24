namespace Pro.Text.RTF.Tokens;

public class AdditionalLineSpacing : TokenBase
{
	internal const string MatchPattern = "slleading(-?[0-9]+)";

	public override TokenType TokenType => TokenType.AdditionalLineSpacing;

	public double Spacing { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Spacing = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"slleading{(int)(Spacing * 20.0)}";
	}
}
