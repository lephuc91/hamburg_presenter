namespace Pro.Text.RTF.Tokens;

public class UnicodeCharacter : TokenBase
{
	internal const string MatchPattern = "u(-?[0-9]+)(.*)";

	public override TokenType TokenType => TokenType.UnicodeCharacter;

	public char Character { get; set; }

	protected internal override void ParseRawValue(string value, string[] additionalValues, out string unconsumedData)
	{
		unconsumedData = additionalValues[0];
		Character = (char)int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"u{(short)Character}";
	}
}
