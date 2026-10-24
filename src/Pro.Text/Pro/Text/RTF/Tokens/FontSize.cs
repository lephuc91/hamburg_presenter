namespace Pro.Text.RTF.Tokens;

public class FontSize : TokenBase
{
	internal const string MatchPattern = "fs([0-9]+)";

	public override TokenType TokenType => TokenType.FontSize;

	public int CharacterSize { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		CharacterSize = int.Parse(value) / 2;
	}

	protected internal override string ToRawValue()
	{
		return $"fs{CharacterSize * 2}";
	}
}
