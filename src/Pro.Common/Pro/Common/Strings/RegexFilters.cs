using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace Pro.Common.Strings;

public static class RegexFilters
{
	public const string ReqNumberPattern = "[0-9]+";

	public const string ReqNumberPatternAllowNeg = "-?[0-9]+";

	public const string OptNumberPattern = "[0-9]*";

	public const string OptNumberPatternAllowNeg = "-?[0-9]*";

	public const string DelimiterPattern = "[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*";

	public const string TwoOrMoreSpaces = "[\\s]{2,}";

	public const string HashtagAndUserNamePattern = "(?<![#@a-zA-Z0-9_])(([#][a-zA-Z0-9_]+)|([@][a-zA-Z0-9_\\.]+(?!\\.)))";

	public const string NumbersOnlyPattern = "^[0-9]+$";

	public static Regex YearsOnly => YearsOnlyRegex();

	public static Regex HasNumbers => HasNumbersRegex();

	public static Regex CharactersOnly => CharactersOnlyRegex();

	public static Regex HashtagAndUserRegex => HashtagAndUserRegexGetter();

	public static Regex NumbersOnly => NumbersOnlyRegex();

	[GeneratedRegex("([0-9]+)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex HasNumbersRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__HasNumbersRegex_5.Instance;
	}

	[GeneratedRegex("[a-zA-Z]+")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex CharactersOnlyRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__CharactersOnlyRegex_6.Instance;
	}

	[GeneratedRegex("(?<![#@a-zA-Z0-9_])(([#][a-zA-Z0-9_]+)|([@][a-zA-Z0-9_\\.]+(?!\\.)))")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex HashtagAndUserRegexGetter()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__HashtagAndUserRegexGetter_7.Instance;
	}

	[GeneratedRegex("^[0-9]+$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NumbersOnlyRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__NumbersOnlyRegex_8.Instance;
	}

	[GeneratedRegex("[0-9]{4}")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex YearsOnlyRegex()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__YearsOnlyRegex_9.Instance;
	}
}
