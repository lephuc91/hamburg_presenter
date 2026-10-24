namespace Pro.Text.RTF.Tokens;

public class DocumentVersion : TokenBase
{
	internal const string MatchPattern = "rtf([0-9]+)";

	public override TokenType TokenType => TokenType.DocumentVersion;

	public int Index { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Index = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"rtf{Index.ToString()}";
	}
}
