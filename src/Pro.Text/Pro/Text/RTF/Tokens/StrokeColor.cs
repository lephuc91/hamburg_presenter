namespace Pro.Text.RTF.Tokens;

public class StrokeColor : TokenBase
{
	internal const string MatchPattern = "strokec([0-9]+)";

	public override TokenType TokenType => TokenType.StrokeColor;

	public int ColorIndex { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		ColorIndex = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"strokec{ColorIndex.ToString()}";
	}
}
