namespace Pro.Text.RTF.Tokens;

public class RightIndent : TokenBase
{
	internal const string MatchPattern = "ri(-?[0-9]+)";

	public override TokenType TokenType => TokenType.RightIndent;

	public double Indentation { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Indentation = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"ri{(int)(Indentation * 20.0)}";
	}
}
