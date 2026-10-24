namespace Pro.Text.RTF.Tokens;

public class Subscript : TokenBase
{
	internal const string MatchPattern = "sub([0-9]*)";

	public override TokenType TokenType => TokenType.Subscript;

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
		return "sub" + ((Level == 1) ? string.Empty : Level.ToString());
	}
}
