namespace Pro.Text.RTF.Tokens;

public class GroupDelimiter : IToken
{
	public TokenType TokenType => TokenType.GroupDelimiter;

	public bool IsText => false;
}
