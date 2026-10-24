using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.Collections;
using Pro.Common.Nullability;

namespace Pro.Common.Time;

public static class TimeSliceHelper
{
	private static readonly Regex[] TimeParsers = new Regex[6]
	{
		IntegerPattern(),
		NumberPattern(),
		ColonIntegerPattern(),
		ColonNumberPattern(),
		TwoColonIntegerPattern(),
		TwoColonNumberPattern()
	};

	[GeneratedRegex("^(-?[0-9]+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex IntegerPattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__IntegerPattern_10.Instance;
	}

	[GeneratedRegex("^(-?[0-9]+\\.-?[0-9]+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NumberPattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__NumberPattern_11.Instance;
	}

	[GeneratedRegex("(-?[0-9]+)\\:(-?[0-9]+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ColonIntegerPattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__ColonIntegerPattern_12.Instance;
	}

	[GeneratedRegex("(-?[0-9]+)\\:(-?[0-9]+\\.-?[0-9]+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ColonNumberPattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__ColonNumberPattern_13.Instance;
	}

	[GeneratedRegex("(-?[0-9]+)\\:(-?[0-9]+)\\:(-?[0-9]+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex TwoColonIntegerPattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__TwoColonIntegerPattern_14.Instance;
	}

	[GeneratedRegex("(-?[0-9]+)\\:(-?[0-9]+)\\:(-?[0-9]+\\.[0-9]+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex TwoColonNumberPattern()
	{
		return _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__TwoColonNumberPattern_15.Instance;
	}

	public static string TimeSliceToString(TimeSlice time, bool withMilliSeconds = false)
	{
		return TimeSliceToString(time, withMilliSeconds ? TimeComponents.All : (TimeComponents.Hours | TimeComponents.Minutes | TimeComponents.Seconds)) ?? string.Empty;
	}

	public static string TimeSliceToString(TimeSlice time, TimeComponents components)
	{
		bool flag = time < TimeSlice.Zero;
		if (flag)
		{
			time = time.RoundDown(components).Abs();
		}
		bool flag2 = components.HasFlag(TimeComponents.Hours);
		bool num = components.HasFlag(TimeComponents.Minutes);
		bool flag3 = components.HasFlag(TimeComponents.Seconds);
		bool flag4 = components.HasFlag(TimeComponents.Milliseconds);
		string text = (flag2 ? $"{(long)time.TotalHours:D2}" : null);
		string text2 = (num ? $"{(long)(flag2 ? ((double)time.Minutes) : time.TotalMinutes):D2}" : null);
		string text3 = (flag3 ? $"{time.Seconds:D2}" : null);
		string text4 = (flag4 ? $"{time.Milliseconds / 10:D2}" : null);
		string text5 = string.Join(":", valid(new string[3] { text, text2, text3 }));
		string text6 = string.Join(".", valid(new string[2] { text5, text4 }));
		return (flag ? "-" : null) + text6;
		static IEnumerable<string> valid(string?[] values)
		{
			return values.NonNull();
		}
	}

	public static TimeSlice StringToTimeSlice(string? value)
	{
		if (value.NullableIsNullOrEmpty())
		{
			return TimeSlice.Zero;
		}
		Match match = TimeParsers.Select((Regex p) => p.Match(value)).LastOrDefault((Match m) => m.Success);
		bool flag = match != null && !string.IsNullOrEmpty(match.Value) && match.Value[0] == '-';
		TimeSlice timeSlice = TimeSlice.Zero;
		if (match != null)
		{
			switch (match.Groups.Count)
			{
			case 4:
				timeSlice = TimeSlice.FromHours(double.Parse(match.Groups[1].Value)) + TimeSlice.FromMinutes(double.Parse(match.Groups[2].Value)) + TimeSlice.FromSeconds(double.Parse(match.Groups[3].Value));
				break;
			case 3:
				timeSlice = TimeSlice.FromMinutes(double.Parse(match.Groups[1].Value)) + TimeSlice.FromSeconds(double.Parse(match.Groups[2].Value));
				break;
			case 2:
				timeSlice = TimeSlice.FromSeconds(double.Parse(match.Groups[1].Value));
				break;
			}
		}
		if (!flag)
		{
			return timeSlice;
		}
		return timeSlice * -1.0;
	}

	public static string Encode(TimeSlice timeSlice)
	{
		return timeSlice.TotalSeconds.ToString(CultureInfo.InvariantCulture);
	}

	public static TimeSlice Decode(string value)
	{
		return TimeSlice.FromSeconds(double.Parse(value, CultureInfo.InvariantCulture));
	}
}
