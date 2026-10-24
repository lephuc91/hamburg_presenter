namespace Pro.Text.RTF.Tokens;

public class Superscript : TokenBase
{
	internal const string MatchPattern = "super([0-9]*)";

	public override TokenType TokenType => TokenType.Superscript;

	public int Level { get; set; } = 1;

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		if (int.TryParse(value, out var result))
		{
			Level = result;
		}
	}

	protected internal override string ToRawValue()
	{
		return "super" + ((Level == 1) ? string.Empty : Level.ToString());
	}
}
