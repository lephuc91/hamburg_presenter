namespace Pro.Text.RTF.Tokens;

public class ExtendedMarker : TokenBase
{
	internal const string MatchPattern = "\\*";

	public override TokenType TokenType => TokenType.ExtendedMarker;

	public int LevelCount { get; set; }

	protected internal override string ToRawValue()
	{
		return "*";
	}
}
