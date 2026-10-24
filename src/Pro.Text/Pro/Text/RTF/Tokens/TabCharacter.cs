namespace Pro.Text.RTF.Tokens;

public class TabCharacter : TokenBase
{
	internal const string MatchPattern = "tab";

	public override TokenType TokenType => TokenType.TabCharacter;

	protected internal override string ToRawValue()
	{
		return "tab";
	}
}
