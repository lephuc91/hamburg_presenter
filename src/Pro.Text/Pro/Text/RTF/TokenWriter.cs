using System.Linq;
using System.Text;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

public static class TokenWriter
{
	public static string WriteDocument(Group rootGroup)
	{
		return WriteGroup(rootGroup);
	}

	private static string WriteGroup(Group group)
	{
		if (!group.Tokens.Any())
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{");
		for (int i = 0; i < group.Tokens.Count; i++)
		{
			IToken token = ((i >= 1) ? group.Tokens[i - 1] : null);
			if (i < group.Tokens.Count - 1)
			{
				_ = group.Tokens[i + 1];
			}
			IToken token2 = group.Tokens[i];
			if (token2.IsText && token != null && !token.IsText)
			{
				stringBuilder.Append(" ");
			}
			switch (token2.TokenType)
			{
			case TokenType.Group:
				stringBuilder.Append(WriteGroup((Group)token2));
				continue;
			case TokenType.PlainText:
				stringBuilder.Append(((PlainText)token2).ToRawValue());
				continue;
			case TokenType.GroupDelimiter:
				stringBuilder.Append(";");
				continue;
			}
			if (token2 is TokenBase)
			{
				stringBuilder.Append($"\\{((TokenBase)token2).ToRawValue()}");
			}
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
