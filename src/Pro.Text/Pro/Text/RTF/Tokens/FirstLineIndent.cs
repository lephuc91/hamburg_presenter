namespace Pro.Text.RTF.Tokens;

public class FirstLineIndent : TokenBase
{
	internal const string MatchPattern = "fi(-?[0-9]+)";

	public override TokenType TokenType => TokenType.FirstLineIndent;

	public double Indentation { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Indentation = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"fi{(int)(Indentation * 20.0)}";
	}
}
