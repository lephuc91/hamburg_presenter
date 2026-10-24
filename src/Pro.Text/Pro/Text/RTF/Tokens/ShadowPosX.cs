namespace Pro.Text.RTF.Tokens;

public class ShadowPosX : TokenBase
{
	internal const string MatchPattern = "shadx(-?[0-9]+)";

	public override TokenType TokenType => TokenType.ShadowPosX;

	public double X { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		X = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"shadx{(int)(X * 20.0)}";
	}
}
