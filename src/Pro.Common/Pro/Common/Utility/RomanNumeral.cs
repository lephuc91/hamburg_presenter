using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pro.Common.Utility;

public static class RomanNumeral
{
	private static readonly ReadOnlyDictionary<char, int> RomanParseMap = new ReadOnlyDictionary<char, int>(new Dictionary<char, int>
	{
		{ 'I', 1 },
		{ 'V', 5 },
		{ 'X', 10 },
		{ 'L', 50 },
		{ 'C', 100 },
		{ 'D', 500 },
		{ 'M', 1000 }
	});

	private static readonly ReadOnlyDictionary<int, string> OrderedRomanMap = new ReadOnlyDictionary<int, string>(new Dictionary<int, string>
	{
		{ 1000, "M" },
		{ 900, "CM" },
		{ 500, "D" },
		{ 400, "CD" },
		{ 100, "C" },
		{ 50, "L" },
		{ 40, "XL" },
		{ 10, "X" },
		{ 9, "IX" },
		{ 5, "V" },
		{ 4, "IV" },
		{ 1, "I" }
	});

	public static bool ParseRomanNumeral(string data, out int value)
	{
		value = 0;
		int num = int.MaxValue;
		int num2 = 0;
		string text = data.ToUpperInvariant();
		foreach (char key in text)
		{
			int value2 = 0;
			if (!RomanParseMap.TryGetValue(key, out value2))
			{
				return false;
			}
			value += value2;
			if (value2 <= num)
			{
				num = value2;
				num2 += value2;
			}
			else
			{
				value -= num2 * 2;
				num = value2;
				num2 = value;
			}
		}
		return true;
	}

	public static string ToRomanNumeral(int value)
	{
		if (value == 0)
		{
			return "Nulla";
		}
		string text = string.Empty;
		if (value < 0)
		{
			value *= -1;
			text = "-";
		}
		foreach (KeyValuePair<int, string> item in OrderedRomanMap.OrderByDescending<KeyValuePair<int, string>, int>((KeyValuePair<int, string> rm) => rm.Key))
		{
			while (value >= item.Key)
			{
				text += item.Value;
				value -= item.Key;
			}
		}
		return text;
	}
}
