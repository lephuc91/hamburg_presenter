using System;
using System.Linq;
using Pro.Common.Integers;
using Pro.Common.Mathematics;
using Pro.Common.Utility;

namespace Pro.Text;

public static class NumberingProvider
{
	private static readonly string[] EnglishLowercaseAlphabet = new string[26]
	{
		"a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
		"k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
		"u", "v", "w", "x", "y", "z"
	};

	private static readonly string[] EnglishUppercaseAlphabet = new string[26]
	{
		"A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
		"K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
		"U", "V", "W", "X", "Y", "Z"
	};

	private static readonly string[] GreekLowercaseAlphabet = new string[24]
	{
		"α", "β", "γ", "δ", "ε", "ζ", "η", "θ", "ι", "κ",
		"λ", "μ", "ν", "ξ", "ο", "π", "ρ", "σ", "τ", "υ",
		"φ", "χ", "ψ", "ω"
	};

	private static readonly string[] GreekUppercaseAlphabet = new string[24]
	{
		"Α", "Β", "Γ", "Δ", "Ε", "Ζ", "Η", "Θ", "Ι", "Κ",
		"Λ", "Μ", "Ν", "Ξ", "Ο", "Π", "Ρ", "Σ", "Τ", "Υ",
		"Φ", "Χ", "Ψ", "Ω"
	};

	private static readonly string[] RussianLowercaseAlphabet = new string[33]
	{
		"а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и",
		"й", "к", "л", "м", "н", "о", "п", "р", "с", "т",
		"у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь",
		"э", "ю", "я"
	};

	private static readonly string[] RussianUppercaseAlphabet = new string[33]
	{
		"А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И",
		"Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т",
		"У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь",
		"Э", "Ю", "Я"
	};

	public static string GetNumberString(int number, NumberingScheme scheme)
	{
		return scheme switch
		{
			NumberingScheme.Arabic => number.ToString(), 
			NumberingScheme.ArabicWithLeadingZero => number.ToString("00"), 
			NumberingScheme.OrdinalNumber => number + number.GetOrdinal(), 
			NumberingScheme.UppercaseRomanNumeral => RomanNumeral.ToRomanNumeral(number).ToUpperInvariant(), 
			NumberingScheme.LowercaseRomanNumeral => RomanNumeral.ToRomanNumeral(number).ToLowerInvariant(), 
			NumberingScheme.UppercaseLetter => GetAlphaString(number, EnglishUppercaseAlphabet), 
			NumberingScheme.LowercaseLetter => GetAlphaString(number, EnglishLowercaseAlphabet), 
			NumberingScheme.LowercaseRussianAlphabet => GetAlphaString(number, RussianLowercaseAlphabet), 
			NumberingScheme.UppercaseRussianAlphabet => GetAlphaString(number, RussianUppercaseAlphabet), 
			NumberingScheme.LowercaseGreekNumerals => GetAlphaString(number, GreekLowercaseAlphabet), 
			NumberingScheme.UppercaseGreekNumerals => GetAlphaString(number, GreekUppercaseAlphabet), 
			_ => throw new NotSupportedException(), 
		};
	}

	private static string GetAlphaString(int number, string[] alphabet)
	{
		int count = (int)Math.Ceiling((double)number.Abs() / (double)alphabet.Length);
		int num = (number - 1).Mod(alphabet.Length);
		return string.Concat(Enumerable.Repeat(alphabet[num], count));
	}
}
