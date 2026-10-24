namespace Pro.Text.RTF.Tokens;

public class MacRTF : TokenBase
{
	internal const string MatchPattern = "cocoartf([0-9]+)";

	public override TokenType TokenType => TokenType.MacRTF;

	public int Index { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Index = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"cocoartf{Index.ToString()}";
	}
}
