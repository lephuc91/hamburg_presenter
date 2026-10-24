namespace Pro.Text.RTF.Tokens;

public class PaperWidth : TokenBase
{
	internal const string MatchPattern = "paperw([0-9]+)";

	public override TokenType TokenType => TokenType.PaperWidth;

	public double Width { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Width = double.Parse(value) / 20.0;
	}

	protected internal override string ToRawValue()
	{
		return $"paperw{(int)(Width * 20.0)}";
	}
}
