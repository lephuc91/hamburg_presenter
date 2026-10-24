using System;
using System.Linq;
using System.Text.RegularExpressions;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles.Formats.USX;

internal static class NoteStyleProvider
{
	private class NoteStyleInfo
	{
		public Regex MatchRegex { get; }

		public NoteStyle Style { get; }

		public NoteStyleInfo(NoteStyle style)
		{
			MatchRegex = new Regex("^" + style.GetEnumDescription() + "$", RegexOptions.Compiled);
			Style = style;
		}
	}

	private static readonly NoteStyleInfo[] _styleInfo;

	static NoteStyleProvider()
	{
		_styleInfo = (from s in Enum.GetValues<NoteStyle>().Except(NoteStyle.Unknown)
			select new NoteStyleInfo(s)).ToArray();
	}

	public static NoteStyle ParseStyle(string? style)
	{
		if (style.NullableIsNullOrEmpty())
		{
			return NoteStyle.Unknown;
		}
		return _styleInfo.FirstOrDefault((NoteStyleInfo i) => i.MatchRegex.IsMatch(style))?.Style ?? NoteStyle.Unknown;
	}
}
