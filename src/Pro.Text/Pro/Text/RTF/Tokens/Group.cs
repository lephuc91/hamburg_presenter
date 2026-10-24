using System.Collections.Generic;
using System.Linq;

namespace Pro.Text.RTF.Tokens;

public class Group : IToken
{
	public TokenType TokenType => TokenType.Group;

	public TokenType GroupType => Tokens.FirstOrDefault((IToken t) => t.TokenType != TokenType.ExtendedMarker)?.TokenType ?? TokenType.Unknown;

	public bool IsText => false;

	public List<IToken> Tokens { get; } = new List<IToken>();
}
