using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace ProPresenter.DO.Import;

public static class MediaShoutImportHelper
{
	public static bool IsMediaShoutFormat(this string text)
	{
		return text.StartsWith("Title:");
	}

	[GeneratedRegex("(?=Title:)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex TitleRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__TitleRegex_6.Instance;
	}

	public static IEnumerable<string> SplitByTitle(this string text)
	{
		return from s in TitleRegex().Split(text)
			where !string.IsNullOrEmpty(s)
			select s;
	}
}
