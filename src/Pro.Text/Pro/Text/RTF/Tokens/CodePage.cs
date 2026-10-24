namespace Pro.Text.RTF.Tokens;

public class CodePage : TokenBase
{
	internal const string MatchPattern = "(ansi|)cpg([0-9]+)";

	public override TokenType TokenType => TokenType.CodePage;

	public bool IsGlobal { get; set; }

	public int Page { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsGlobal = value == "ansi";
		Page = int.Parse(additionalValues[0]);
	}

	protected internal override string ToRawValue()
	{
		return string.Format(IsGlobal ? "ansicpg{0}" : "cpg{0}", Page);
	}
}
