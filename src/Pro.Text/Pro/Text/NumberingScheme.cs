using System.ComponentModel;

namespace Pro.Text;

public enum NumberingScheme
{
	[Description("1 2 3...")]
	Arabic,
	[Description("01 02 03...")]
	ArabicWithLeadingZero,
	[Description("1st 2nd 3rd...")]
	OrdinalNumber,
	[Description("I II III...")]
	UppercaseRomanNumeral,
	[Description("i ii iii...")]
	LowercaseRomanNumeral,
	[Description("A B C...")]
	UppercaseLetter,
	[Description("a b c...")]
	LowercaseLetter,
	[Description("a б в...")]
	LowercaseRussianAlphabet,
	[Description("A Б В...")]
	UppercaseRussianAlphabet,
	[Description("α β γ...")]
	LowercaseGreekNumerals,
	[Description("Α Β Γ...")]
	UppercaseGreekNumerals
}
