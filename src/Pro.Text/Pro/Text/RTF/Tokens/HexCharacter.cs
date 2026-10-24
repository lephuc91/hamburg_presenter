using System.Globalization;

namespace Pro.Text.RTF.Tokens;

public class HexCharacter : TokenBase
{
	internal const string MatchPattern = "'([a-fA-F0-9]{2})(.*)";

	public override TokenType TokenType => TokenType.HexCharacter;

	public override bool IsText => true;

	public byte EncodedCharacter { get; set; }

	protected internal override void ParseRawValue(string value, string[] additionalValues, out string unconsumedData)
	{
		unconsumedData = additionalValues[0];
		EncodedCharacter = byte.Parse(value, NumberStyles.HexNumber);
	}

	protected internal override string ToRawValue()
	{
		return $"'{EncodedCharacter:x2}";
	}
}
