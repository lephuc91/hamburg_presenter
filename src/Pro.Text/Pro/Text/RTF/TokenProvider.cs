using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Pro.Common.Reflection;

namespace Pro.Text.RTF;

internal static class TokenProvider
{
	[DebuggerDisplay("{TokenClassType, nq}")]
	private class TokenInfo
	{
		public Regex MatchRegex { get; }

		public Type TokenClassType { get; }

		public TokenInfo(string? matchPattern, Type tokenClassType)
		{
			MatchRegex = new Regex($"^{matchPattern}$", RegexOptions.Compiled);
			TokenClassType = tokenClassType;
		}
	}

	private const string MatchPatternConstant = "MatchPattern";

	private static readonly TokenInfo[] _availableTokens;

	static TokenProvider()
	{
		List<TokenInfo> list = new List<TokenInfo>();
		foreach (Type item in from t in Assembly.GetExecutingAssembly().GetTypes()
			where t.BaseType == typeof(TokenBase)
			select t)
		{
			FieldInfo field = item.GetField("MatchPattern", BindingFlags.Static | BindingFlags.NonPublic);
			if (!(field == null) && !(field.FieldType != typeof(string)))
			{
				list.Add(new TokenInfo(field.GetValue(null) as string, item));
			}
		}
		_availableTokens = list.ToArray();
	}

	public static TokenBase? ParseToken(string tokenData, out string unconsumedData)
	{
		unconsumedData = string.Empty;
		TokenInfo[] availableTokens = _availableTokens;
		foreach (TokenInfo tokenInfo in availableTokens)
		{
			Match match = tokenInfo.MatchRegex.Match(tokenData);
			if (!match.Success)
			{
				continue;
			}
			TokenBase tokenBase = (TokenBase)tokenInfo.TokenClassType.Construct();
			if (match.Groups.Count >= 2)
			{
				tokenBase.ParseRawValue(match.Groups[1].Value, (from g in match.Groups.OfType<Group>().Skip(2)
					select g.Value).ToArray(), out unconsumedData);
			}
			return tokenBase;
		}
		return null;
	}
}
