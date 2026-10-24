namespace Pro.Text.RTF.Tokens;

public class Font : TokenBase
{
	internal const string MatchPattern = "f([0-9]+)";

	public override TokenType TokenType => TokenType.FontIndex;

	public int FontIndex { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		FontIndex = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"f{FontIndex}";
	}
}
