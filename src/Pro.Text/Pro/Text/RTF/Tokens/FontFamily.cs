using System;

namespace Pro.Text.RTF.Tokens;

public class FontFamily : TokenBase
{
	public enum FamilyType
	{
		Unknown,
		Roman,
		Swiss,
		Modern,
		Script,
		Decorative,
		Technical,
		Bidirectional
	}

	internal const string MatchPattern = "f(nil|roman|swiss|modern|script|decor|tech|bidi)";

	public override TokenType TokenType => TokenType.FontFamily;

	public FamilyType Family { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		Family = ParseFamilyType(value);
	}

	protected internal override string ToRawValue()
	{
		return $"f{GetFamilyTypeValue()}";
	}

	private FamilyType ParseFamilyType(string value)
	{
		return value.ToLowerInvariant() switch
		{
			"nil" => FamilyType.Unknown, 
			"roman" => FamilyType.Roman, 
			"swiss" => FamilyType.Swiss, 
			"modern" => FamilyType.Modern, 
			"script" => FamilyType.Script, 
			"decor" => FamilyType.Decorative, 
			"tech" => FamilyType.Technical, 
			"bidi" => FamilyType.Bidirectional, 
			_ => throw new NotSupportedException("Unknown family type"), 
		};
	}

	private string GetFamilyTypeValue()
	{
		return Family switch
		{
			FamilyType.Unknown => "nil", 
			FamilyType.Roman => "roman", 
			FamilyType.Swiss => "swiss", 
			FamilyType.Modern => "modern", 
			FamilyType.Script => "script", 
			FamilyType.Decorative => "decor", 
			FamilyType.Technical => "tech", 
			FamilyType.Bidirectional => "bidi", 
			_ => throw new NotSupportedException("Unknown family type"), 
		};
	}
}
