namespace Pro.Text.RTF.Tokens;

public class StrikethroughColor : TokenBase
{
	internal const string MatchPattern = "strikec([0-9]+)";

	public override TokenType TokenType => TokenType.StrikethroughColor;

	public int ColorIndex { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		ColorIndex = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"strikec{ColorIndex.ToString()}";
	}
}
