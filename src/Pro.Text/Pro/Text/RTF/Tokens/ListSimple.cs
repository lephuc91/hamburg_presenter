namespace Pro.Text.RTF.Tokens;

public class ListSimple : TokenBase
{
	internal const string MatchPattern = "listsimple([0-9]+)";

	public override TokenType TokenType => TokenType.ListSimple;

	public bool IsSimple { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsSimple = int.Parse(value) == 1;
	}

	protected internal override string ToRawValue()
	{
		return $"listsimple{(IsSimple ? 1 : 0)}";
	}
}
