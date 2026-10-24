namespace Pro.Text.RTF.Tokens;

public class ParagraphSpacing : TokenBase
{
	internal const string MatchPattern = "s(a|b)(-?[0-9]+)";

	public override TokenType TokenType => TokenType.ParagraphSpacing;

	public bool IsBefore { get; set; }

	public double Spacing { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsBefore = value == "b";
		Spacing = double.Parse(additionalValues[0]) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return string.Format("s{0}{1}", IsBefore ? "b" : "a", (int)(Spacing * 20.0));
	}
}
