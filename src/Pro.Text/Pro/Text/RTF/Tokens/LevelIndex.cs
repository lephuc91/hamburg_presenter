namespace Pro.Text.RTF.Tokens;

public class LevelIndex : TokenBase
{
	internal const string MatchPattern = "ilvl([0-9]+)";

	public override TokenType TokenType => TokenType.LevelIndex;

	public int Index { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Index = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"ilvl{Index}";
	}
}
