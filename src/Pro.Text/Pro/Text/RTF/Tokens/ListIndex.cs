namespace Pro.Text.RTF.Tokens;

public class ListIndex : TokenBase
{
	internal const string MatchPattern = "ls([0-9]+)";

	public override TokenType TokenType => TokenType.ListIndex;

	public int Index { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Index = int.Parse(value);
	}

	protected internal override string ToRawValue()
	{
		return $"ls{Index}";
	}
}
