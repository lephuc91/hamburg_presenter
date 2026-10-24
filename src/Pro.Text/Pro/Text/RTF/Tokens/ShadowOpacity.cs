namespace Pro.Text.RTF.Tokens;

public class ShadowOpacity : TokenBase
{
	internal const string MatchPattern = "shado([0-9]+)";

	public override TokenType TokenType => TokenType.ShadowOpacity;

	public double Opacity { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Opacity = (double)(int)byte.Parse(value) / 255.0;
	}

	protected internal override string ToRawValue()
	{
		return $"shado{(byte)(Opacity * 255.0)}";
	}
}
