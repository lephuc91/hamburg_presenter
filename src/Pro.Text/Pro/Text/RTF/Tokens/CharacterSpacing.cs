namespace Pro.Text.RTF.Tokens;

public class CharacterSpacing : TokenBase
{
	internal const string MatchPattern = "expnd(tw|)(-?[0-9]+)";

	public override TokenType TokenType => TokenType.CharacterSpacing;

	public double Spacing { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		int num = ((value == "tw") ? 20 : 4);
		Spacing = double.Parse(additionalValues[0]) / (double)num;
	}

	protected internal override string ToRawValue()
	{
		return $"expnd{(int)(Spacing * 4.0)}\\expndtw{(int)(Spacing * 20.0)}";
	}
}
