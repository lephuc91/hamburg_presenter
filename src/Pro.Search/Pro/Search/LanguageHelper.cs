using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace Pro.Search;

public static class LanguageHelper
{
	private static readonly (Language, Regex)[] _languageRegexMap;

	private static readonly Language[] _languageLookup;

	[GeneratedRegex("^\\p{IsArabic}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ArabicRegex()
	{
		return _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__ArabicRegex_0.Instance;
	}

	[GeneratedRegex("^\\p{IsHangulJamo}|\\p{IsCJKRadicalsSupplement}|\\p{IsCJKSymbolsandPunctuation}|\\p{IsEnclosedCJKLettersandMonths}|\\p{IsCJKCompatibility}|\\p{IsCJKUnifiedIdeographsExtensionA}|\\p{IsCJKUnifiedIdeographs}|\\p{IsHangulSyllables}|\\p{IsCJKCompatibilityForms}|\\p{IsKatakana}|\\p{IsHiragana}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex CJKRegex()
	{
		return _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__CJKRegex_1.Instance;
	}

	[GeneratedRegex("^\\p{IsBasicLatin}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex EnglishRegex()
	{
		return _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__EnglishRegex_2.Instance;
	}

	static LanguageHelper()
	{
		_languageRegexMap = new(Language, Regex)[3]
		{
			(Language.English, EnglishRegex()),
			(Language.CJK, CJKRegex()),
			(Language.Arabic, ArabicRegex())
		};
		_languageLookup = new Language[65535];
		for (int i = 0; i < 65535; i++)
		{
			string input = ((char)i).ToString();
			bool flag = false;
			(Language, Regex)[] languageRegexMap = _languageRegexMap;
			for (int j = 0; j < languageRegexMap.Length; j++)
			{
				(Language, Regex) tuple = languageRegexMap[j];
				var (language, _) = tuple;
				if (tuple.Item2.IsMatch(input))
				{
					flag = true;
					_languageLookup[i] = language;
					break;
				}
			}
			if (!flag)
			{
				_languageLookup[i] = Language.Unknown;
			}
		}
	}

	public static Language DetectPredominantLanguage(this string field)
	{
		if (string.IsNullOrWhiteSpace(field))
		{
			return Language.English;
		}
		int[] counts = new int[4];
		foreach (char c in field)
		{
			Language language = _languageLookup[(uint)c];
			int num = (int)language;
			counts[num]++;
			if (language != 0 && counts[num] >= field.Length / 2)
			{
				return language;
			}
		}
		return (from v in Enum.GetValues<Language>().Except(new _003C_003Ez__ReadOnlyArray<Language>(new Language[2]
			{
				Language.Unknown,
				Language.MAX_COUNT
			}))
			select (value: v, count: counts[(int)v]) into v
			orderby v.count descending
			select v).First().value;
	}
}
