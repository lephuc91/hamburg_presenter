using System;
using System.Linq;
using System.Text.RegularExpressions;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles.Formats.USX;

internal static class CharacterStyleProvider
{
	private class CharacterStyleInfo
	{
		public Regex MatchRegex { get; }

		public CharacterStyle Style { get; }

		public CharacterStyleInfo(CharacterStyle style)
		{
			MatchRegex = new Regex("^" + style.GetEnumDescription() + "$", RegexOptions.Compiled);
			Style = style;
		}
	}

	private static readonly CharacterStyleInfo[] _styleInfo;

	static CharacterStyleProvider()
	{
		_styleInfo = (from s in Enum.GetValues<CharacterStyle>().Except(CharacterStyle.Unknown)
			select new CharacterStyleInfo(s)).ToArray();
	}

	public static CharacterStyle ParseStyle(string? style)
	{
		if (style.NullableIsNullOrEmpty())
		{
			return CharacterStyle.Unknown;
		}
		return _styleInfo.FirstOrDefault((CharacterStyleInfo i) => i.MatchRegex.IsMatch(style))?.Style ?? CharacterStyle.Unknown;
	}
}
