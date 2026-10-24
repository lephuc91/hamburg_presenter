namespace Pro.Text.RTF;

public interface IToken
{
	TokenType TokenType { get; }

	bool IsText { get; }
}
