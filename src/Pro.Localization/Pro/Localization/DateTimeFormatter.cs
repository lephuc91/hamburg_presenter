using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.Cache;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Localization.SourceGenerator.Attributes;
using TimeZoneNames;

namespace Pro.Localization;

public static class DateTimeFormatter
{
	private sealed class PatternKey : IEquatable<PatternKey?>
	{
		private readonly int _hashCode;

		public CultureInfo Culture { get; }

		public FormatLength DateLength { get; }

		public FormatLength TimeLength { get; }

		public bool Use24HourMode { get; }

		public PatternKey(CultureInfo culture, FormatLength dateLength, FormatLength timeLength, bool use24HourMode)
		{
			Culture = culture;
			DateLength = dateLength;
			TimeLength = timeLength;
			Use24HourMode = use24HourMode;
			_hashCode = HashCodeHelper.GenerateHashCode(Culture.IetfLanguageTag, DateLength, TimeLength, Use24HourMode);
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as PatternKey);
		}

		public bool Equals(PatternKey? other)
		{
			if ((object)other != null && Culture.IetfLanguageTag == other.Culture.IetfLanguageTag && DateLength == other.DateLength && TimeLength == other.TimeLength)
			{
				return Use24HourMode == other.Use24HourMode;
			}
			return false;
		}

		public static bool operator ==(PatternKey lhs, PatternKey rhs)
		{
			return lhs.NullableEquals<PatternKey>(rhs);
		}

		public static bool operator !=(PatternKey lhs, PatternKey rhs)
		{
			return !lhs.NullableEquals<PatternKey>(rhs);
		}
	}

	private sealed class PatternCache : Cache<PatternKey, string>
	{
		protected override string GenerateValue(PatternKey target)
		{
			return GenerateFormatPattern(target.Culture, target.DateLength, target.TimeLength, target.Use24HourMode);
		}

		private static string GenerateFormatPattern(CultureInfo culture, FormatLength dateLength, FormatLength timeLength, bool use24HourMode)
		{
			if (dateLength == FormatLength.None && timeLength == FormatLength.None)
			{
				return string.Empty;
			}
			if (dateLength == FormatLength.None)
			{
				return ConvertPattern(GetTimePattern(culture, timeLength), use24HourMode);
			}
			if (timeLength == FormatLength.None)
			{
				return ConvertPattern(GetDatePattern(culture, dateLength), use24HourMode);
			}
			string datePattern = GetDatePattern(culture, dateLength);
			string timePattern = GetTimePattern(culture, timeLength);
			return ConvertPattern(string.Format(GetCombinePattern(culture, dateLength) ?? string.Empty, timePattern, datePattern), use24HourMode);
		}

		private static string? GetDatePattern(CultureInfo culture, FormatLength length)
		{
			return length switch
			{
				FormatLength.Short => culture.DateTimeFormat.ShortDatePattern, 
				FormatLength.Full => culture.DateTimeFormat.LongDatePattern, 
				_ => GetPattern(culture, length, (FormatSet? s) => s?.Date), 
			};
		}

		private static string? GetTimePattern(CultureInfo culture, FormatLength length)
		{
			return length switch
			{
				FormatLength.Short => culture.DateTimeFormat.ShortTimePattern, 
				FormatLength.Medium => culture.DateTimeFormat.LongTimePattern, 
				_ => GetPattern(culture, length, (FormatSet? s) => s?.Time), 
			};
		}

		private static string? GetCombinePattern(CultureInfo culture, FormatLength length)
		{
			return GetPattern(culture, length, (FormatSet? s) => s?.Combine);
		}

		private static string? GetPattern(CultureInfo culture, FormatLength length, Func<FormatSet?, FormatData?> dataSelector)
		{
			if (length == FormatLength.None)
			{
				return string.Empty;
			}
			string key = culture.TwoLetterISOLanguageName.ToUpperInvariant();
			string key2 = new RegionInfo(culture.Name).TwoLetterISORegionName.ToUpperInvariant();
			if (!_languageMap.TryGetValue(key, out Language value))
			{
				return GetPattern(length, dataSelector(_languageMap["EN"]));
			}
			value.Regions.TryGetValue(key2, out FormatSet value2);
			return GetPattern(length, dataSelector(value2)) ?? GetPattern(length, dataSelector(value)) ?? GetPattern(length, dataSelector(_languageMap["EN"]));
		}

		private static string? GetPattern(FormatLength length, FormatData? formatData)
		{
			return length switch
			{
				FormatLength.Short => formatData?.ShortPattern, 
				FormatLength.Medium => formatData?.MediumPattern, 
				FormatLength.Long => formatData?.LongPattern, 
				FormatLength.Full => formatData?.FullPattern, 
				_ => throw new NotSupportedException(), 
			};
		}

		private static string ConvertPattern(string? pattern, bool use24HourMode)
		{
			int placeholderCount = 0;
			List<string> placeholderValues = new List<string>();
			if (pattern.NullableIsNullOrEmpty())
			{
				return string.Empty;
			}
			pattern = PlaceholderRegex().Replace(pattern, delegate(Match m)
			{
				placeholderValues.Add(m.Value);
				return $"{{{placeholderCount++}}}";
			});
			pattern = pattern.RemoveField('g').Replace('G', 'g').Replace('Y', 'y')
				.Replace('u', 'y')
				.Replace("yyyy", "YYYY")
				.Replace("yyy", "YYYY")
				.Replace("yy", "YY")
				.Replace("y", "yyyy")
				.Replace('Y', 'y')
				.RemoveField('U')
				.RemoveField('r')
				.RemoveField('Q')
				.RemoveField('q')
				.Replace("MMMMM", "M")
				.Replace('L', 'M')
				.RemoveField('l')
				.RemoveField('w')
				.RemoveField('W')
				.RemoveField('D')
				.RemoveField('F')
				.Replace('c', 'E')
				.Replace("EEEEEE", "ddd")
				.Replace("EEEEE", "ddd")
				.Replace("EEEE", "dddd")
				.Replace('E', 'd')
				.Replace('b', 'a')
				.Replace('B', 'a')
				.Replace("aaaaa", "t")
				.Replace("a", "tt")
				.Replace('K', 'h')
				.Replace('k', 'H')
				.Replace('j', 'H')
				.Replace('J', 'H')
				.Replace('C', 't')
				.Replace("SSSSSS", "ss.ffffff")
				.Replace("SSSSS", "ss.fffff")
				.Replace("SSSS", "ss.ffff")
				.Replace("SSS", "ss.fff")
				.Replace("SS", "ss.ff")
				.Replace("S", "ss.f")
				.RemoveField('A')
				.RemoveField('V')
				.RemoveField('v')
				.Replace("ZZZZZ", "'zzz")
				.Replace("ZZZZ", "'GMT'zzz")
				.Replace("zzzz", "$_LTZ_L_")
				.Replace("zzz", "$_LTZ_S_")
				.Replace("zz", "$_LTZ_S_")
				.Replace("z", "$_LTZ_S_")
				.Replace("OOOO", "'GMT'zzz")
				.Replace("O", "'GMT'z")
				.Replace('X', 'z')
				.Replace('x', 'z');
			if (use24HourMode)
			{
				pattern = pattern.RemoveField('t').Replace('h', 'H');
			}
			string text;
			if (!placeholderValues.Any())
			{
				text = pattern;
			}
			else
			{
				string? format = pattern;
				object[] args = placeholderValues.ToArray();
				text = string.Format(format, args);
			}
			return text.Trim();
		}
	}

	private sealed class TZAbbreviationCache : Cache<(string timeZoneID, CultureInfo culture), TimeZoneValues>
	{
		protected override TimeZoneValues GenerateValue((string timeZoneID, CultureInfo culture) target)
		{
			string languageCode = target.culture.IetfLanguageTag;
			string languageKey = target.culture.TwoLetterISOLanguageName.ToLowerInvariant();
			if ((from l in TZNames.GetLanguageCodes()
				select l.ToLowerInvariant()).None((string l) => l.StartsWith(languageKey)))
			{
				languageCode = "EN";
			}
			return TZNames.GetAbbreviationsForTimeZone(target.timeZoneID, languageCode);
		}
	}

	private const string FallbackLanguageKey = "EN";

	public const string LocalTZShortToken = "$_LTZ_S_";

	public const string LocalTZLongToken = "$_LTZ_L_";

	[GenerateFormatData("format_data.json")]
	private static readonly ImmutableDictionary<string, Language> _languageMap;

	private static readonly PatternCache _patternCache;

	private static readonly TZAbbreviationCache _tzAbbreviationCache;

	[GeneratedRegex("(\\'[^\\']*\\')")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex PlaceholderRegex()
	{
		return _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__PlaceholderRegex_1.Instance;
	}

	private static string RemoveField(this string pattern, char field)
	{
		return pattern.Replace($" {field} ", string.Empty).Replace($"{field} ", string.Empty).Replace($" {field}", string.Empty)
			.Replace($"{field}", string.Empty);
	}

	public static string GetFormatPattern(FormatLength dateLength, FormatLength timeLength, bool use24HourMode)
	{
		return GetFormatPattern(CultureInfo.CurrentCulture, dateLength, timeLength, use24HourMode);
	}

	public static string GetFormatPattern(CultureInfo culture, FormatLength dateLength, FormatLength timeLength, bool use24HourMode)
	{
		return _patternCache.Get(new PatternKey(culture, dateLength, timeLength, use24HourMode));
	}

	public static string FormatDateTime(DateTime time, FormatLength dateLength, FormatLength timeLength, bool use24HourMode)
	{
		return FormatDateTime(time, CultureInfo.CurrentCulture, dateLength, timeLength, use24HourMode);
	}

	public static string FormatDateTime(DateTime time, CultureInfo culture, FormatLength dateLength, FormatLength timeLength, bool use24HourMode)
	{
		string formatPattern = GetFormatPattern(culture, dateLength, timeLength, use24HourMode);
		TimeZoneValues timeZoneValues = _tzAbbreviationCache.Get((TimeZoneInfo.Local.Id, culture));
		bool flag = TimeZoneInfo.Local.IsDaylightSavingTime(time);
		formatPattern = formatPattern.Replace("$_LTZ_S_", "'" + (flag ? timeZoneValues.Daylight : timeZoneValues.Standard) + "'").Replace("$_LTZ_L_", "'" + (flag ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName) + "'");
		if (!string.IsNullOrWhiteSpace(formatPattern))
		{
			return time.ToString(formatPattern);
		}
		return string.Empty;
	}

	static DateTimeFormatter()
	{
		_patternCache = new PatternCache();
		_tzAbbreviationCache = new TZAbbreviationCache();
		_languageMap = InitializeLanguageMap();
	}

	private static ImmutableDictionary<string, Language> InitializeLanguageMap()
	{
		ImmutableDictionary<string, Language>.Builder builder = ImmutableDictionary.CreateBuilder<string, Language>();
		ImmutableDictionary<string, FormatSet>.Builder builder2 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder2.Add("NA", new FormatSet(new FormatData(null, "d MMM y", "d MMMM y", "EEEE d MMMM y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder.Add("AF", new Language(new FormatData("y-MM-dd", "dd MMM y", "dd MMMM y", "EEEE dd MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder2.ToImmutable()));
		builder.Add("AGQ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("AK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("yy/MM/dd", "y MMM d", "y MMMM d", "EEEE, y MMMM dd"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("AM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "y MMMM d, EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder3 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder3.Add("IL", new FormatSet(null, new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), null));
		builder3.Add("KM", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder3.Add("MA", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("AR", new Language(new FormatData("d\u200f/M\u200f/y", "dd\u200f/MM\u200f/y", "d MMMM y", "EEEE، d MMMM y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder3.ToImmutable()));
		builder.Add("AS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d-M-y", "dd-MM-y", "d MMMM, y", "EEEE, d MMMM, y"), time: new FormatData("a h.mm", "a h.mm.ss", "a h.mm.ss z", "a h.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("ASA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("AST", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM 'de' y", "EEEE, d MMMM 'de' y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1}, {0}", "{1} 'a' 'les' {0}", "{1} 'a' 'les' {0}")));
		builder.Add("AZ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "d MMM y", "d MMMM y", "d MMMM y, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("BAS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("BE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.MM.yy", "d.MM.y", "d MMMM y 'г'.", "EEEE, d MMMM y 'г'."), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss, zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'у' {0}", "{1} 'у' {0}")));
		builder.Add("BEM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("BEZ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("BG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.MM.yy 'г'.", "d.MM.y 'г'.", "d MMMM y 'г'.", "EEEE, d MMMM y 'г'."), time: new FormatData("H:mm 'ч'.", "H:mm:ss 'ч'.", "H:mm:ss 'ч'. z", "H:mm:ss 'ч'. zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("BM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("BN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE, d MMMM, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("BO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y ལ\u0f7cའ\u0f72་MMMཚ\u0f7aས་d", "ས\u0fa4\u0fb1\u0f72་ལ\u0f7c་y MMMMའ\u0f72་ཚ\u0f7aས་d", "y MMMMའ\u0f72་ཚ\u0f7aས་d, EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("BR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1}, {0}", "{1} 'da' {0}", "{1} 'da' {0}")));
		builder.Add("BRX", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("BS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d. M. y.", "d. MMM y.", "d. MMMM y.", "EEEE, d. MMMM y."), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} 'u' {0}", "{1} 'u' {0}")));
		builder.Add("CA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM 'de' y", "EEEE, d MMMM 'de' y"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1}, {0}", "{1} 'a' 'les' {0}", "{1} 'a' 'les' {0}")));
		builder.Add("CCP", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE, d MMMM, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("CEB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'sa' {0}", "{1} 'sa' {0}")));
		builder.Add("CGG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("CHR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} ᎤᎾᎢ {0}", "{1} ᎤᎾᎢ {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder4 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder4.Add("IR", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("CKB", new Language(new FormatData("y-MM-dd", "y MMM d", "dی MMMMی y", "y MMMM d, EEEE"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder4.ToImmutable()));
		builder.Add("CS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "d. M. y", "d. MMMM y", "EEEE d. MMMM y"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("CU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y.MM.dd", "y MMM d", "y MMMM d", "EEEE, d MMMM 'л'. y."), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("CY", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} 'am' {0}", "{1} 'am' {0}")));
		builder.Add("DA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d. MMM y", "d. MMMM y", "EEEE 'den' d. MMMM y"), time: new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "HH.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} 'kl'. {0}", "{1} 'kl'. {0}")));
		builder.Add("DAV", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("DE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "dd.MM.y", "d. MMMM y", "EEEE, d. MMMM y"), time: null, combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'um' {0}", "{1} 'um' {0}")));
		builder.Add("DJE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("DSB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.yy", "d.M.y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("DUA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("DYO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("DZ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "ས\u0fa4\u0fb1\u0f72་ལ\u0f7c་y ཟ\u0fb3་MMM ཚ\u0f7aས་dd", "ས\u0fa4\u0fb1\u0f72་ལ\u0f7c་y MMMM ཚ\u0f7aས་ dd", "EEEE, ས\u0fa4\u0fb1\u0f72་ལ\u0f7c་y MMMM ཚ\u0f7aས་dd"), time: new FormatData("ཆ\u0f74་ཚ\u0f7cད་ h ས\u0f90ར་མ་ mm a", "ཆ\u0f74་ཚ\u0f7cད་h:mm:ss a", "ཆ\u0f74་ཚ\u0f7cད་ h ས\u0f90ར་མ་ mm:ss a z", "ཆ\u0f74་ཚ\u0f7cད་ h ས\u0f90ར་མ་ mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("EBU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		ImmutableDictionary<string, FormatSet>.Builder builder5 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder5.Add("TG", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("EE", new Language(new FormatData("M/d/yy", "MMM d 'lia', y", "MMMM d 'lia' y", "EEEE, MMMM d 'lia' y"), new FormatData("a 'ga' h:mm", "a 'ga' h:mm:ss", "a 'ga' h:mm:ss z", "a 'ga' h:mm:ss zzzz"), new FormatData("{0} {1}", "{0} {1}", "{0} {1}", "{0} {1}"), builder5.ToImmutable()));
		builder.Add("EL", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} - {0}", "{1} - {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder6 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder6.Add("001", new FormatSet(new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), null, null));
		builder6.Add("150", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("AE", new FormatSet(new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), null, null));
		builder6.Add("AI", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("AU", new FormatSet(new FormatData("d/M/yy", null, null, null), null, null));
		builder6.Add("BE", new FormatSet(new FormatData("dd/MM/yy", "dd MMM y", null, null), null, null));
		builder6.Add("BI", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("BW", new FormatSet(new FormatData("dd/MM/yy", "dd MMM y", "dd MMMM y", "EEEE, dd MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("BZ", new FormatSet(new FormatData("dd/MM/yy", "dd-MMM-y", "dd MMMM y", "EEEE, dd MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("CA", new FormatSet(new FormatData("y-MM-dd", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), null, null));
		builder6.Add("CC", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("CK", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("CM", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("CX", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("DG", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("DK", new FormatSet(null, new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "HH.mm.ss zzzz"), null));
		builder6.Add("FI", new FormatSet(null, new FormatData("H.mm", "H.mm.ss", "H.mm.ss z", "H.mm.ss zzzz"), null));
		builder6.Add("FK", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("GB", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("GG", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("GI", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("HK", new FormatSet(new FormatData("d/M/y", null, null, null), null, null));
		builder6.Add("IE", new FormatSet(new FormatData(null, null, null, "EEEE d MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("IL", new FormatSet(null, new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), null));
		builder6.Add("IM", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("IN", new FormatSet(new FormatData("dd/MM/yy", "dd-MMM-y", null, "EEEE, d MMMM, y"), null, null));
		builder6.Add("IO", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("JE", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("JM", new FormatSet(new FormatData("d/M/yy", null, null, null), null, null));
		builder6.Add("KE", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("MG", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("MS", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("MT", new FormatSet(new FormatData(null, "dd MMM y", "dd MMMM y", null), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("MU", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("NF", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("NG", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("NR", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("NU", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("NZ", new FormatSet(new FormatData("d/MM/yy", "d/MM/y", null, null), null, null));
		builder6.Add("PK", new FormatSet(new FormatData(null, "dd-MMM-y", null, null), null, null));
		builder6.Add("PN", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("RW", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("SC", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("SE", new FormatSet(new FormatData("y-MM-dd", null, null, null), null, null));
		builder6.Add("SG", new FormatSet(new FormatData("d/M/yy", null, null, null), null, null));
		builder6.Add("SH", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("SX", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("TK", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("TV", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("TZ", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("UG", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("ZA", new FormatSet(new FormatData("y/MM/dd", "dd MMM y", "dd MMMM y", "EEEE, dd MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder6.Add("ZW", new FormatSet(new FormatData("d/M/y", "dd MMM,y", "dd MMMM y", "EEEE, dd MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("EN", new Language(new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1}, {0}", "{1}, {0}", "{1} 'at' {0}", "{1} 'at' {0}"), builder6.ToImmutable()));
		builder.Add("EO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("yy-MM-dd", "y-MMM-dd", "y-MMMM-dd", "EEEE, d-'a' 'de' MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "H-'a' 'horo' 'kaj' m:ss zzzz"), combine: null));
		ImmutableDictionary<string, FormatSet>.Builder builder7 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder7.Add("419", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder7.Add("BO", new FormatSet(new FormatData(null, "d MMM 'de' y", null, null), null, null));
		builder7.Add("CL", new FormatSet(new FormatData("dd-MM-yy", "dd-MM-y", null, null), null, null));
		builder7.Add("CO", new FormatSet(new FormatData("d/MM/yy", "d/MM/y", null, null), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1}, {0}", "{1}, {0}", null, null)));
		builder7.Add("DO", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder7.Add("GT", new FormatSet(new FormatData("d/MM/yy", "d/MM/y", null, null), null, null));
		builder7.Add("HN", new FormatSet(new FormatData(null, null, "dd 'de' MMMM 'de' y", "EEEE dd 'de' MMMM 'de' y"), null, null));
		builder7.Add("MX", new FormatSet(new FormatData("dd/MM/yy", null, null, null), new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), null));
		builder7.Add("PA", new FormatSet(new FormatData("MM/dd/yy", "MM/dd/y", null, null), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder7.Add("PE", new FormatSet(new FormatData("d/MM/yy", null, null, null), null, null));
		builder7.Add("PH", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder7.Add("PR", new FormatSet(new FormatData("MM/dd/yy", "MM/dd/y", null, null), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder7.Add("US", new FormatSet(new FormatData("d/M/y", null, null, null), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder7.Add("VE", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder.Add("ES", new Language(new FormatData("d/M/yy", "d MMM y", "d 'de' MMMM 'de' y", "EEEE, d 'de' MMMM 'de' y"), new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss (zzzz)"), new FormatData("{1} {0}", "{1} {0}", "{1}, {0}", "{1}, {0}"), builder7.ToImmutable()));
		builder.Add("ET", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "d. MMM y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("EU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("yy/M/d", "y('e')'ko' MMM d('a')", "y('e')'ko' MMMM'ren' d('a')", "y('e')'ko' MMMM'ren' d('a'), EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss (z)", "HH:mm:ss (zzzz)"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("EWO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("FA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y/M/d", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss (z)", "H:mm:ss (zzzz)"), combine: new FormatData("{1}،\u200f {0}", "{1}،\u200f {0}", "{1}، ساعت {0}", "{1}، ساعت {0}")));
		builder.Add("FF", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("FI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.y", "d.M.y", "d. MMMM y", "cccc d. MMMM y"), time: new FormatData("H.mm", "H.mm.ss", "H.mm.ss z", "H.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} 'klo' {0}", "{1} 'klo' {0}", "{1} 'klo' {0}")));
		builder.Add("FIL", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'nang' {0}", "{1} 'nang' {0}")));
		builder.Add("FO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "dd.MM.y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'kl'. {0}", "{1} 'kl'. {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder8 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder8.Add("BE", new FormatSet(new FormatData("d/MM/yy", null, null, null), null, null));
		builder8.Add("CA", new FormatSet(new FormatData("yy-MM-dd", null, null, null), null, new FormatData(null, "{1} {0}", null, null)));
		builder8.Add("CH", new FormatSet(new FormatData("dd.MM.yy", null, null, "EEEE, d MMMM y"), null, null));
		builder8.Add("ML", new FormatSet(null, null, new FormatData("{1}, {0}", "{1}, {0}", null, null)));
		builder.Add("FR", new Language(new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), null, new FormatData("{1} {0}", "{1} 'à' {0}", "{1} 'à' {0}", "{1} 'à' {0}"), builder8.ToImmutable()));
		builder.Add("FUR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "dd/MM/y", "d 'di' MMMM 'dal' y", "EEEE d 'di' MMMM 'dal' y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("FY", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-yy", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} 'om' {0}", "{1} 'om' {0}")));
		builder.Add("GA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("GD", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d'mh' MMMM y", "EEEE, d'mh' MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("GL", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "d 'de' MMM 'de' y", "d 'de' MMMM 'de' y", "EEEE, d 'de' MMMM 'de' y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{0}, {1}", "{0}, {1}", "{0} 'do' {1}", "{0} 'do' {1}")));
		builder.Add("GSW", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "dd.MM.y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("GU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE, d MMMM, y"), time: new FormatData("hh:mm a", "hh:mm:ss a", "hh:mm:ss a z", "hh:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} એ {0} વ\u0abeગ\u0acdય\u0ac7", "{1} એ {0} વ\u0abeગ\u0acdય\u0ac7")));
		builder.Add("GUZ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("GV", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "MMM dd, y", "dd MMMM y", "EEEE dd MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		ImmutableDictionary<string, FormatSet>.Builder builder9 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder9.Add("GH", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder9.Add("NE", new FormatSet(new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE d MMMM, y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("HA", new Language(new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE d MMMM, y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder9.ToImmutable()));
		builder.Add("HAW", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("HE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.y", "d בMMM y", "d בMMMM y", "EEEE, d בMMMM y"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} בשעה {0}", "{1} בשעה {0}")));
		builder.Add("HI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} क\u094b {0}", "{1} क\u094b {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder10 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder10.Add("BA", new FormatSet(new FormatData("d. M. yy.", null, null, null), null, null));
		builder.Add("HR", new Language(new FormatData("dd. MM. y.", "d. MMM y.", "d. MMMM y.", "EEEE, d. MMMM y."), new FormatData(null, null, null, "HH:mm:ss (zzzz)"), new FormatData("{1} {0}", "{1} {0}", "{1} 'u' {0}", "{1} 'u' {0}"), builder10.ToImmutable()));
		builder.Add("HSB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.yy", "d.M.y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("H:mm 'hodź'.", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("HU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y. MM. dd.", "y. MMM d.", "y. MMMM d.", "y. MMMM d., EEEE"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("HY", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "dd MMM, y թ.", "dd MMMM, y թ.", "y թ. MMMM d, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("IA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-y", "d MMM y", "d 'de' MMMM y", "EEEE 'le' d 'de' MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} 'a' {0}", "{1} 'a' {0}")));
		builder.Add("ID", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "d MMM y", "d MMMM y", "EEEE, dd MMMM y"), time: new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "HH.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("IG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'na' {0}", "{1} 'na' {0}")));
		builder.Add("II", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("IS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.y", "d. MMM y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'kl'. {0}", "{1} 'kl'. {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder11 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder11.Add("CH", new FormatSet(new FormatData("dd.MM.yy", null, null, "EEEE, d MMMM y"), null, null));
		builder.Add("IT", new Language(new FormatData("dd/MM/yy", "d MMM y", "d MMMM y", "EEEE d MMMM y"), null, new FormatData("{1}, {0}", "{1}, {0}", "{1} {0}", "{1} {0}"), builder11.ToImmutable()));
		builder.Add("JA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y/MM/dd", "y/MM/dd", "y年M月d日", "y年M月d日EEEE"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H時mm分ss秒 zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("JGO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "EEEE, y MMMM dd"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("JMC", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("JV", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "d MMM. y", "d MMMM, y", "EEEE, dd MMMM, y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("KAB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'af' {0}", "{1} 'af' {0}")));
		builder.Add("KAM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KDE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KEA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d 'di' MMMM 'di' y", "EEEE, d 'di' MMMM 'di' y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KHQ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "y 'ж'. dd MMM", "y 'ж'. d MMMM", "y 'ж'. d MMMM, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("KKJ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM y", "d MMM y", "d MMMM y", "EEEE dd MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", null, null), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KL", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "MMM dd, y", "dd MMMM y", "EEEE dd MMMM y"), time: new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "HH.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KLN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} ន\u17c5\u200bម\u17c9\u17c4ង {0}", "{1} ន\u17c5\u200bម\u17c9\u17c4ង {0}")));
		builder.Add("KN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("hh:mm a", "hh:mm:ss a", "hh:mm:ss a z", "hh:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("yy. M. d.", "y. M. d.", "y년 M월 d일", "y년 M월 d일 EEEE"), time: new FormatData("a h:mm", "a h:mm:ss", "a h시 m분 s초 z", "a h시 m분 s초 zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KOK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d-M-yy", "dd-MM-y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("KSB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KSF", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KSH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d. M. y", "d. MMM. y", "d. MMMM y", "EEEE, 'dä' d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KW", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("KY", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "y-'ж'., d-MMM", "y-'ж'., d-MMMM", "y-'ж'., d-MMMM, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("LAG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("LB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "d. MMM y", "d. MMMM y", "EEEE, d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("LG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("LKT", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("LN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("LO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE ທ\u0eb5 d MMMM G y"), time: new FormatData("H:mm", "H:mm:ss", "H ໂມງ m ນາທ\u0eb5 ss ວ\u0eb4ນາທ\u0eb5 z", "H ໂມງ m ນາທ\u0eb5 ss ວ\u0eb4ນາທ\u0eb5 zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder12 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder12.Add("IQ", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder.Add("LRC", new Language(new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder12.ToImmutable()));
		builder.Add("LT", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y-MM-dd", "y 'm'. MMMM d 'd'.", "y 'm'. MMMM d 'd'., EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("LU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("LUO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("LUY", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("LV", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "y. 'gada' d. MMM", "y. 'gada' d. MMMM", "EEEE, y. 'gada' d. MMMM"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MAS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("MER", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("MFE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("MG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MGH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("MGO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "EEEE, y MMMM dd"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("h:mm", "h:mm:ss", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.M.yy", "dd.M.y", "dd MMMM y", "EEEE, dd MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("ML", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "y, MMM d", "y, MMMM d", "y, MMMM d, EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y.MM.dd", "y 'оны' MMM'ын' d", "y.MM.dd", "y.MM.dd, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss (z)", "HH:mm:ss (zzzz)"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE, d MMMM, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} र\u094bज\u0940 {0}", "{1} र\u094bज\u0940 {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder13 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder13.Add("BN", new FormatSet(new FormatData(null, null, null, "dd MMMM y"), null, null));
		builder.Add("MS", new Language(new FormatData("d/MM/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1}, {0}", "{1}, {0}", "{1} {0}", "{1} {0}"), builder13.ToImmutable()));
		builder.Add("MT", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "dd MMM y", "d 'ta'’ MMMM y", "EEEE, d 'ta'’ MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("MUA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("MY", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-yy", "y၊ MMM d", "y၊ d MMMM", "y၊ MMMM d၊ EEEE"), time: new FormatData("B H:mm", "B HH:mm:ss", "z HH:mm:ss", "zzzz HH:mm:ss"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("NAQ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("NB", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d. MMM y", "d. MMMM y", "EEEE d. MMMM y"), time: new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "HH.mm.ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'kl'. {0}", "{1} {0}")));
		builder.Add("ND", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("NDS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.MM.yy", "d. MMM y", "d. MMMM y", "EEEE, 'de' d. MMMM y"), time: new FormatData("'Kl'. H.mm", "'Klock' H.mm:ss", "'Klock' H.mm:ss (z)", "'Klock' H.mm:ss (zzzz)"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder14 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder14.Add("IN", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder.Add("NE", new Language(new FormatData("yy/M/d", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1}, {0}", "{1}, {0}", "{1} {0}", "{1} {0}"), builder14.ToImmutable()));
		ImmutableDictionary<string, FormatSet>.Builder builder15 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder15.Add("BE", new FormatSet(new FormatData("d/MM/y", null, null, null), null, null));
		builder.Add("NL", new Language(new FormatData("dd-MM-y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), null, new FormatData("{1} {0}", "{1} {0}", "{1} 'om' {0}", "{1} 'om' {0}"), builder15.ToImmutable()));
		builder.Add("NMG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("NN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d. MMM y", "d. MMMM y", "EEEE d. MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "'kl'. HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'kl'. {0}", "{1} {0}")));
		builder.Add("NNH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "d MMM, y", "'lyɛ'\u030cʼ d 'na' MMMM, y", "EEEE , 'lyɛ'\u030cʼ d 'na' MMMM, y"), time: null, combine: new FormatData(null, null, "{1}, {0}", "{1},{0}")));
		builder.Add("NUS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/MM/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "z h:mm:ss a", "zzzz h:mm:ss a"), combine: null));
		builder.Add("NYN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		ImmutableDictionary<string, FormatSet>.Builder builder16 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder16.Add("KE", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("OM", new Language(new FormatData("dd/MM/yy", "dd-MMM-y", "dd MMMM y", "EEEE, MMMM d, y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder16.ToImmutable()));
		builder.Add("OR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{0} ଠ\u0b3eର\u0b47 {1}", "{0} ଠ\u0b3eର\u0b47 {1}")));
		builder.Add("OS", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "dd MMM y 'аз'", "d MMMM, y 'аз'", "EEEE, d MMMM, y 'аз'"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("PA", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} {0}", "{1} {0}")));
		builder.Add("PL", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: null, combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} {0}", "{1} {0}")));
		builder.Add("PRG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "dd.MM 'st'. y", "y 'mettas' d. MMMM", "EEEE, y 'mettas' d. MMMM"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder17 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder17.Add("PK", new FormatSet(null, new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), null));
		builder.Add("PS", new Language(new FormatData("y/M/d", "y MMM d", "د y د MMMM d", "EEEE د y د MMMM d"), new FormatData("H:mm", "H:mm:ss", "H:mm:ss (z)", "H:mm:ss (zzzz)"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder17.ToImmutable()));
		ImmutableDictionary<string, FormatSet>.Builder builder18 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder18.Add("PT", new FormatSet(new FormatData("dd/MM/yy", "dd/MM/y", null, null), null, new FormatData("{1}, {0}", "{1}, {0}", "{1} 'às' {0}", "{1} 'às' {0}")));
		builder.Add("PT", new Language(new FormatData("dd/MM/y", "d 'de' MMM 'de' y", "d 'de' MMMM 'de' y", "EEEE, d 'de' MMMM 'de' y"), null, new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder18.ToImmutable()));
		builder.Add("QU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM, y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{0} {1}", "{1} {0}")));
		builder.Add("RM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-yy", "dd-MM-y", "d 'da' MMMM y", "EEEE, 'ils' d 'da' MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("RN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("RO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: null, combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("ROF", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("ROOT", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("RU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d MMM y 'г'.", "d MMMM y 'г'.", "EEEE, d MMMM y 'г'."), time: null, combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("RW", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("RWK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("SAH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("yy/M/d", "y, MMM d", "y, MMMM d", "y 'сыл' MMMM d 'күнэ', EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("SAQ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("SBP", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("SD", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder19 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder19.Add("FI", new FormatSet(new FormatData("dd.MM.y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), null, null));
		builder.Add("SE", new Language(new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder19.ToImmutable()));
		builder.Add("SEH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d 'de' MMM 'de' y", "d 'de' MMMM 'de' y", "EEEE, d 'de' MMMM 'de' y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("SES", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("SG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("SHI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: null, combine: null));
		builder.Add("SI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "HH.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("SK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d. M. y", "d. M. y", "d. MMMM y", "EEEE d. MMMM y"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("SL", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d. MM. yy", "d. MMM y", "dd. MMMM y", "EEEE, dd. MMMM y"), time: null, combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("SMN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.y", "MMM d. y", "MMMM d. y", "cccc, MMMM d. y"), time: new FormatData("H.mm", "H.mm.ss", "H.mm.ss z", "H.mm.ss zzzz"), combine: new FormatData("{1} {0}", "{1} 'tme' {0}", "{1} 'tme' {0}", "{1} 'tme' {0}")));
		builder.Add("SN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder20 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder20.Add("KE", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("SO", new Language(new FormatData("dd/MM/yy", "dd-MMM-y", "dd MMMM y", "EEEE, MMMM dd, y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder20.ToImmutable()));
		ImmutableDictionary<string, FormatSet>.Builder builder21 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder21.Add("MK", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder21.Add("XK", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("SQ", new Language(new FormatData("d.M.yy", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a, z", "h:mm:ss a, zzzz"), new FormatData("{1}, {0}", "{1}, {0}", "{1} 'në' {0}", "{1} 'në' {0}"), builder21.ToImmutable()));
		builder.Add("SR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.M.yy.", "dd.MM.y.", "dd. MMMM y.", "EEEE, dd. MMMM y."), time: null, combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder22 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder22.Add("FI", new FormatSet(new FormatData("dd-MM-y", null, null, null), null, null));
		builder.Add("SV", new Language(new FormatData(null, "d MMM y", "d MMMM y", "EEEE d MMMM y"), new FormatData("HH.mm", "HH.mm.ss", "HH.mm.ss z", "'kl'. HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder22.ToImmutable()));
		ImmutableDictionary<string, FormatSet>.Builder builder23 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder23.Add("KE", new FormatSet(null, null, new FormatData("{1}, {0}", "{1}, {0}", "{1} 'saa' {0}", "{1} 'saa' {0}")));
		builder.Add("SW", new Language(new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder23.ToImmutable()));
		ImmutableDictionary<string, FormatSet>.Builder builder24 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder24.Add("LK", new FormatSet(null, new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), null));
		builder.Add("TA", new Language(new FormatData("d/M/yy", "d MMM, y", "d MMMM, y", "EEEE, d MMMM, y"), new FormatData("a h:mm", "a h:mm:ss", "a h:mm:ss z", "a h:mm:ss zzzz"), new FormatData("{1}, {0}", "{1}, {0}", "{1} ’அன\u0bcdற\u0bc1’ {0}", "{1} ’அன\u0bcdற\u0bc1’ {0}"), builder24.ToImmutable()));
		builder.Add("TE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-yy", "d MMM, y", "d MMMM, y", "d, MMMM y, EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}క\u0c3f", "{1} {0}క\u0c3f")));
		builder.Add("TEO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("TG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "dd MMM y", "dd MMMM y", "EEEE, dd MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("TH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM G y", "EEEEท\u0e35\u0e48 d MMMM G y"), time: new FormatData(null, null, "H นาฬ\u0e34กา mm นาท\u0e35 ss ว\u0e34นาท\u0e35 z", "H นาฬ\u0e34กา mm นาท\u0e35 ss ว\u0e34นาท\u0e35 zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("TI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "dd-MMM-y", "dd MMMM y", "EEEE፣ dd MMMM መዓልቲ y G"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("TK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d MMM y", "d MMMM y", "d MMMM y EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("TO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("TR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d.MM.y", "d MMM y", "d MMMM y", "d MMMM y EEEE"), time: null, combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("TT", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.y", "d MMM, y 'ел'", "d MMMM, y 'ел'", "d MMMM, y 'ел', EEEE"), time: new FormatData("H:mm", "H:mm:ss", "H:mm:ss z", "H:mm:ss zzzz"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("TWQ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("TZM", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: null, combine: null));
		builder.Add("UG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "d-MMM، y", "d-MMMM، y", "y d-MMMM، EEEE"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1}، {0}", "{1}، {0}", "{1} {0}", "{1} {0}")));
		builder.Add("UK", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd.MM.yy", "d MMM y 'р'.", "d MMMM y 'р'.", "EEEE, d MMMM y 'р'."), time: null, combine: new FormatData("{1}, {0}", "{1}, {0}", "{1} 'о' {0}", "{1} 'о' {0}")));
		builder.Add("UR", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/yy", "d MMM، y", "d MMMM، y", "EEEE، d MMMM، y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("UZ", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "d-MMM, y", "d-MMMM, y", "EEEE, d-MMMM, y"), time: new FormatData("HH:mm", "HH:mm:ss", "H:mm:ss (z)", "H:mm:ss (zzzz)"), combine: new FormatData("{1}, {0}", "{1}, {0}", "{1}, {0}", "{1}, {0}")));
		builder.Add("VAI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("h:mm a", "h:mm:ss a", "h:mm:ss a z", "h:mm:ss a zzzz"), combine: null));
		builder.Add("VI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM, y", "d MMMM, y", "EEEE, d MMMM, y"), time: null, combine: new FormatData("{0}, {1}", "{0}, {1}", "{0} {1}", "{0} {1}")));
		builder.Add("VO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM. d", "y MMMM d", "y MMMM'a' 'd'. d'id'"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("VUN", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("WAE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData(null, "d. MMM y", "d. MMMM y", "EEEE, d. MMMM y"), time: null, combine: null));
		builder.Add("WO", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd-MM-y", "d MMM, y", "d MMMM, y", "EEEE, d MMM, y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} - {0}", "{1} - {0}", "{1} 'ci' {0}", "{1} 'ci' {0}")));
		builder.Add("XH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y-MM-dd", "y MMM d", "y MMMM d", "y MMMM d, EEEE"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("XOG", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/y", "d MMM y", "d MMMM y", "EEEE, d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("YAV", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: null));
		builder.Add("YI", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("dd/MM/yy", "dטן MMM y", "dטן MMMM y", "EEEE, dטן MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1}, {0}", "{1} {0}", "{1} {0}")));
		ImmutableDictionary<string, FormatSet>.Builder builder25 = ImmutableDictionary.CreateBuilder<string, FormatSet>();
		builder25.Add("BJ", new FormatSet(new FormatData("d/M/y", "d MM y", "d MMM y", "EEEE, d MMM y"), new FormatData("H:m", "H:m:s", "H:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("YO", new Language(new FormatData("d/M/y", "d MM y", "d MMM y", "EEEE, d MMM y"), new FormatData("H:m", "H:m:s", "H:mm:ss z", "HH:mm:ss zzzz"), new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}"), builder25.ToImmutable()));
		builder.Add("YUE", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y/M/d", "y年M月d日", "y年M月d日", "y年M月d日 EEEE"), time: new FormatData("ah:mm", "ah:mm:ss", "ah:mm:ss [z]", "ah:mm:ss [zzzz]"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("ZGH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("d/M/y", "d MMM, y", "d MMMM y", "EEEE d MMMM y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("ZH", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("y/M/d", "y年M月d日", "y年M月d日", "y年M月d日EEEE"), time: new FormatData("ah:mm", "ah:mm:ss", "z ah:mm:ss", "zzzz ah:mm:ss"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		builder.Add("ZU", new Language(regions: ImmutableDictionary.CreateBuilder<string, FormatSet>().ToImmutable(), date: new FormatData("M/d/yy", "MMM d, y", "MMMM d, y", "EEEE, MMMM d, y"), time: new FormatData("HH:mm", "HH:mm:ss", "HH:mm:ss z", "HH:mm:ss zzzz"), combine: new FormatData("{1} {0}", "{1} {0}", "{1} {0}", "{1} {0}")));
		return builder.ToImmutable();
	}
}
