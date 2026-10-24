namespace Pro.Text.RTF.Tokens;

public class FontCharacterSet : TokenBase
{
	internal const string MatchPattern = "fcharset([0-9]+)";

	public override TokenType TokenType => TokenType.FontCharacterSet;

	public int CharacterSet { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		CharacterSet = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"fcharset{CharacterSet}";
	}
}
