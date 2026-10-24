namespace Pro.Text.RTF.Tokens;

public class ShadowPosY : TokenBase
{
	internal const string MatchPattern = "shady(-?[0-9]+)";

	public override TokenType TokenType => TokenType.ShadowPosY;

	public double Y { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Y = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"shady{(int)(Y * 20.0)}";
	}
}
