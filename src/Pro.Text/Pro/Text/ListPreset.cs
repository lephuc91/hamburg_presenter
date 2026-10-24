using System.ComponentModel;

namespace Pro.Text;

public enum ListPreset
{
	[Description("None")]
	None,
	[Description("-")]
	[ListPresetData(BulletType.Dash, null, null)]
	Dash,
	[Description("●")]
	[ListPresetData(BulletType.Circle, null, null)]
	Circle,
	[Description("■")]
	[ListPresetData(BulletType.Square, null, null)]
	Square,
	[Description("✓")]
	[ListPresetData(BulletType.Checkmark, null, null)]
	Check,
	[Description("1. 2. 3....")]
	[ListPresetData(NumberingScheme.Arabic, null, ".")]
	Arabic,
	[Description("1) 2) 3)...")]
	[ListPresetData(NumberingScheme.Arabic, null, ")")]
	ArabicWithParentheses,
	[Description("A. B. C....")]
	[ListPresetData(NumberingScheme.UppercaseLetter, null, ".")]
	UppercaseLetter,
	[Description("a. b. c....")]
	[ListPresetData(NumberingScheme.LowercaseLetter, null, ".")]
	LowercaseLetter,
	[Description("A) B) C)...")]
	[ListPresetData(NumberingScheme.UppercaseLetter, null, ")")]
	UppercaseLetterWithParentheses,
	[Description("a) b) c)...")]
	[ListPresetData(NumberingScheme.LowercaseLetter, null, ")")]
	LowercaseLetterWithParentheses,
	[Description("I. II. III....")]
	[ListPresetData(NumberingScheme.UppercaseRomanNumeral, null, ".")]
	UppercaseRomanNumeral,
	[Description("i. ii. iii....")]
	[ListPresetData(NumberingScheme.LowercaseRomanNumeral, null, ".")]
	LowercaseRomanNumeral
}
