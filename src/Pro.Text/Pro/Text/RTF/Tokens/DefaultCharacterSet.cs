using System;

namespace Pro.Text.RTF.Tokens;

public class DefaultCharacterSet : TokenBase
{
	public enum CharacterSet
	{
		ANSI,
		Mac,
		PCA,
		PC
	}

	internal const string MatchPattern = "(ansi|mac|pca|pc)";

	public override TokenType TokenType => TokenType.DefaultCharacterSet;

	public CharacterSet DefaultSet { get; set; }

	protected override void ParseRawValue(string value, string[] additionalValues)
	{
		switch (value)
		{
		case "ansi":
			DefaultSet = CharacterSet.ANSI;
			break;
		case "mac":
			DefaultSet = CharacterSet.Mac;
			break;
		case "pca":
			DefaultSet = CharacterSet.PCA;
			break;
		case "pc":
			DefaultSet = CharacterSet.PC;
			break;
		default:
			throw new NotSupportedException();
		}
	}

	protected internal override string ToRawValue()
	{
		return DefaultSet switch
		{
			CharacterSet.ANSI => "ansi", 
			CharacterSet.Mac => "mac", 
			CharacterSet.PCA => "pca", 
			CharacterSet.PC => "pc", 
			_ => throw new NotSupportedException(), 
		};
	}
}
