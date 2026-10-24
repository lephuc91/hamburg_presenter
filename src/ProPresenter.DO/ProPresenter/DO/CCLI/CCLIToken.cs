using Pro.Common.Utility;
using Pro.DO.Token;

namespace ProPresenter.DO.CCLI;

public class CCLIToken : TokenBase
{
	public CCLITokenType TokenType { get; }

	public override string Content { get; }

	public CCLIToken(CCLITokenType tokenType)
	{
		TokenType = tokenType;
		Content = TokenType.GetEnumDescription();
	}

	public override TokenBase Clone()
	{
		return new CCLIToken(TokenType);
	}
}
