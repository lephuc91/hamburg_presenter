namespace Pro.Text.RTF.Tokens;

public class PlainText : TokenBase
{
	internal const string MatchPattern = "(\\\\|\\{|\\})(.*)";

	public override TokenType TokenType => TokenType.PlainText;

	public override bool IsText => true;

	public string Text { get; set; }

	public PlainText()
		: this(string.Empty)
	{
	}

	public PlainText(string text)
	{
		Text = text;
	}

	protected internal override void ParseRawValue(string value, string[] additionalValues, out string unconsumedData)
	{
		unconsumedData = additionalValues[0];
		Text = value;
	}

	protected internal override string ToRawValue()
	{
		return Text.Replace("\\", "\\\\").Replace("{", "\\{").Replace("}", "\\}");
	}
}
