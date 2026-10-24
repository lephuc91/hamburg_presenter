using System.Windows.Media;

namespace Pro.Text.RTF.Tokens;

public class HighlightColor : TokenBase
{
	internal const string MatchPattern = "highlight([0-9]+)";

	public static readonly Color DefaultColor = Colors.Transparent;

	public override TokenType TokenType => TokenType.HighlightColor;

	public int ColorIndex { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		ColorIndex = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"highlight{ColorIndex}";
	}
}
