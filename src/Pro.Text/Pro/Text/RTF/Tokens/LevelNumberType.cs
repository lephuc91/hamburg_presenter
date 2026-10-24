namespace Pro.Text.RTF.Tokens;

public class LevelNumberType : TokenBase
{
	public enum NumberType
	{
		Arabic = 0,
		UppercaseRomanNumeral = 1,
		LowercaseRomanNumeral = 2,
		UppercaseLetter = 3,
		LowercaseLetter = 4,
		OrdinalNumber = 5,
		CardinalTextNumber = 6,
		OrdinalTextNumber = 7,
		KanjiNumberingWithoutDigit = 10,
		KanjiNumberingWithDigit = 11,
		PhoneticKatakanaCharactersAIUEO = 12,
		PhoneticKatakanaCharactersIROHA = 13,
		DoubleByteCharacter = 14,
		SingleByteCharacter = 15,
		KanjiNumbering3 = 16,
		KanjiNumbering4 = 17,
		CircleNumbering = 18,
		DoubleByteArabicNumbering = 19,
		PhoneticDoubleByteKatakanaCharactersAIUEO = 20,
		PhoneticDoubleByteKatakanaCharactersIROHA = 21,
		ArabicWithLeadingZero = 22,
		Bullet = 23,
		KoreanNumbering2 = 24,
		KoreanNumbering1 = 25,
		ChineseNumbering1 = 26,
		ChineseNumbering2 = 27,
		ChineseNumbering3 = 28,
		ChineseNumbering4 = 29,
		ChineseZodiacNumbering1 = 30,
		ChineseZodiacNumbering2 = 31,
		ChineseZodiacNumbering3 = 32,
		TaiwaneseDoubleByteNumbering1 = 33,
		TaiwaneseDoubleByteNumbering2 = 34,
		TaiwaneseDoubleByteNumbering3 = 35,
		TaiwaneseDoubleByteNumbering4 = 36,
		ChineseDoubleByteNumbering1 = 37,
		ChineseDoubleByteNumbering2 = 38,
		ChineseDoubleByteNumbering3 = 39,
		ChineseDoubleByteNumbering4 = 40,
		KoreanDoubleByteNumbering1 = 41,
		KoreanDoubleByteNumbering2 = 42,
		KoreanDoubleByteNumbering3 = 43,
		KoreanDoubleByteNumbering4 = 44,
		HebrewNonStandardDecimal = 45,
		ArabicAlifBaTah = 46,
		HebrewBiblicalStandard = 47,
		ArabicAbjadStyle = 48,
		HindiVowels = 49,
		HindiConsonants = 50,
		HindiNumbers = 51,
		HindiDescriptive = 52,
		ThaiLetters = 53,
		ThaiNumbers = 54,
		ThaiDescriptive = 55,
		VietnameseDescriptive = 56,
		PageNumberFormat = 57,
		LowercaseRussianAlphabet = 58,
		UppercaseRussianAlphabet = 59,
		LowercaseGreekNumerals = 60,
		UppercaseGreekNumerals = 61,
		TwoLeadingZeros = 62,
		ThreeLeadingZeros = 63,
		FourLeadingZeros = 64,
		LowerCaseTurkishAlphabet = 65,
		UpperCaseTurkishAlphabet = 66,
		LowerCaseBulgarianAlphabet = 67,
		UpperCaseBulgarianAlphabet = 68,
		NoNumber = 255
	}

	internal const string MatchPattern = "levelnfc(n|)([0-9]+)";

	public override TokenType TokenType => TokenType.LevelNumberType;

	public bool IsImportant { get; set; }

	public NumberType Numbering { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		IsImportant = value == "n";
		Numbering = (NumberType)int.Parse(additionalValues[0]);
	}

	protected internal override string ToRawValue()
	{
		return string.Format("levelnfc{0}{1}", IsImportant ? "n" : string.Empty, ((int)Numbering).ToString());
	}
}
