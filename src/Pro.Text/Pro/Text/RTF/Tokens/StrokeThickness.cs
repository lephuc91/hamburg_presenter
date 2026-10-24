namespace Pro.Text.RTF.Tokens;

public class StrokeThickness : TokenBase
{
	internal const string MatchPattern = "strokewidth(-?[0-9]+)";

	public override TokenType TokenType => TokenType.StrokeThickness;

	public double Thickness { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Thickness = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"strokewidth{(int)(Thickness * 20.0)}";
	}
}
