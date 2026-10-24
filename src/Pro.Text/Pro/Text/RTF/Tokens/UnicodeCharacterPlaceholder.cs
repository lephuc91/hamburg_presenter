namespace Pro.Text.RTF.Tokens;

public class UnicodeCharacterPlaceholder : TokenBase
{
	internal const string MatchPattern = "uc([0-9]+)";

	public override TokenType TokenType => TokenType.UnicodeCharacterPlaceholder;

	public int CharacterCount { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		CharacterCount = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"uc{CharacterCount}";
	}
}
