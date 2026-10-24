using System;
using System.Linq;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

public static class TokenReader
{
	public static Group? Parse(string rtfData)
	{
		int index = 0;
		return ReadGroup(rtfData, ref index);
	}

	private static Group? ReadGroup(string rtfData, ref int index)
	{
		string read = string.Empty;
		bool isControl = false;
		Group group = null;
		bool isGroupValid = true;
		bool isExtended = false;
		while (index < rtfData.Length)
		{
			char c = rtfData[index];
			switch (c)
			{
			case '{':
				if (isControl && !hasData())
				{
					read += c;
					break;
				}
				processRead();
				if (group != null)
				{
					Group group2 = ReadGroup(rtfData, ref index);
					if (group2 != null)
					{
						group.Tokens.Add(group2);
					}
				}
				else
				{
					group = new Group();
				}
				break;
			case '}':
				if (isControl && !hasData())
				{
					read += c;
					break;
				}
				if (!processRead())
				{
					checkGroup();
				}
				if (!isGroupValid)
				{
					return null;
				}
				return group;
			case '\\':
				if (isControl)
				{
					if (hasData())
					{
						parseToken(out var _);
					}
					else
					{
						read += c;
					}
				}
				else if (hasData())
				{
					addPlainText();
				}
				else
				{
					checkGroup();
				}
				isControl = true;
				break;
			case ';':
				if (!processRead())
				{
					checkGroup();
				}
				group?.Tokens.Add(new GroupDelimiter());
				break;
			case ' ':
				if (group == null)
				{
					break;
				}
				if (isControl)
				{
					parseToken(out var wasTokenText2);
					if (wasTokenText2)
					{
						index--;
					}
				}
				else
				{
					read += c;
				}
				break;
			case '\n':
			case '\r':
				if (!processRead() && isControl)
				{
					group?.Tokens.Add(new ParagraphBreak());
					isControl = false;
				}
				break;
			case '\v':
				processRead();
				group?.Tokens.Add(new VerticalTab());
				break;
			case '\t':
				processRead();
				group?.Tokens.Add(new TabCharacter());
				break;
			default:
				checkGroup();
				read += c;
				break;
			}
			index++;
		}
		throw new Exception("RTF group malformed");
		void addPlainText()
		{
			group?.Tokens.Add(new PlainText(read));
			read = string.Empty;
		}
		void checkGroup()
		{
			if (group == null)
			{
				throw new Exception("RTF group malformed: group never started");
			}
		}
		bool hasData()
		{
			return !string.IsNullOrEmpty(read);
		}
		void parseToken(out bool wasTokenText)
		{
			wasTokenText = false;
			string unconsumedData;
			TokenBase tokenBase = TokenProvider.ParseToken(read, out unconsumedData);
			if (tokenBase != null)
			{
				wasTokenText = tokenBase.IsText;
				if (group != null && tokenBase.TokenType == TokenType.ExtendedMarker && !group.Tokens.Any())
				{
					isExtended = true;
				}
				group?.Tokens.Add(tokenBase);
				read = unconsumedData;
				if (hasData())
				{
					if (read.StartsWith("\\"))
					{
						parseToken(out wasTokenText);
					}
					else
					{
						addPlainText();
						wasTokenText = true;
					}
				}
			}
			else
			{
				read = string.Empty;
				if (isExtended)
				{
					isGroupValid = false;
					isExtended = false;
				}
			}
			isControl = false;
		}
		bool processRead()
		{
			if (hasData())
			{
				if (isControl)
				{
					parseToken(out var _);
				}
				else
				{
					addPlainText();
				}
				return true;
			}
			return false;
		}
	}
}
