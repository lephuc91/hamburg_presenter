using System;
using System.Linq;
using System.Text.RegularExpressions;
using Pro.Common.Collections;
using Pro.Common.Utility;

namespace ProPresenter.DO.Bibles.Formats.USX;

internal static class ParagraphStyleProvider
{
	private class ParagraphStyleInfo
	{
		public Regex MatchRegex { get; }

		public ParagraphStyle Style { get; }

		public ParagraphStyleInfo(ParagraphStyle style)
		{
			MatchRegex = new Regex("^" + style.GetEnumDescription() + "$", RegexOptions.Compiled);
			Style = style;
		}
	}

	private static ParagraphStyleInfo[] _styleInfo;

	static ParagraphStyleProvider()
	{
		_styleInfo = (from s in Enum.GetValues<ParagraphStyle>().Except(ParagraphStyle.Unknown)
			select new ParagraphStyleInfo(s)).ToArray();
	}

	public static ParagraphStyle ParseStyle(string style)
	{
		if (string.IsNullOrEmpty(style))
		{
			return ParagraphStyle.Unknown;
		}
		return _styleInfo.FirstOrDefault((ParagraphStyleInfo i) => i.MatchRegex.IsMatch(style))?.Style ?? ParagraphStyle.Unknown;
	}
}
