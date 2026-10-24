namespace Pro.Text.RTF.Tokens;

public class ShadowRadius : TokenBase
{
	internal const string MatchPattern = "shadr([0-9]+)";

	public override TokenType TokenType => TokenType.ShadowRadius;

	public double Radius { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Radius = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"shadr{(int)(Radius * 20.0)}";
	}
}
