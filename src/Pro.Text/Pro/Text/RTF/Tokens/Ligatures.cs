namespace Pro.Text.RTF.Tokens;

public class Ligatures : TokenBase
{
	internal const string MatchPattern = "CocoaLigature([0-9]+)";

	public override TokenType TokenType => TokenType.Ligatures;

	public bool IsActive { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsActive = int.Parse(value) > 0;
	}

	protected internal override string ToRawValue()
	{
		return $"CocoaLigature{(IsActive ? 1 : 0)}";
	}
}
