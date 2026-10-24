namespace Pro.Text.RTF.Tokens;

public class RunReset : TokenBase
{
	internal const string MatchPattern = "plain";

	public override TokenType TokenType => TokenType.RunReset;

	protected internal override string ToRawValue()
	{
		return "plain";
	}
}
