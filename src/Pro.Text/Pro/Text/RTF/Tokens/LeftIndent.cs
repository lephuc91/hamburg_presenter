namespace Pro.Text.RTF.Tokens;

public class LeftIndent : TokenBase
{
	internal const string MatchPattern = "li(-?[0-9]+)";

	public override TokenType TokenType => TokenType.LeftIndent;

	public double Indentation { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Indentation = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"li{(int)(Indentation * 20.0)}";
	}
}
