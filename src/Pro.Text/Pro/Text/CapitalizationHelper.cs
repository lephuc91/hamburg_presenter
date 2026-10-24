using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Entity;

namespace Pro.Text;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(CapitalizationType), typeof(IGraphics.Types.IText.Types.IAttributes.Types.Capitalization), SourceToDestinationMethodName = "ToEntityCapitalizationType", DestinationToSourceMethodName = "ToCapitalizationType")]
public static class CapitalizationHelper
{
	private static readonly List<string> _allowLowerCase = new List<string>
	{
		"a", "an", "and", "at", "but", "by", "for", "in", "nor", "of",
		"on", "or", "so", "the", "to", "up", "yet", "v", "v.", "vs",
		"vs."
	};

	private static readonly List<string> _containers = new List<string> { "(", "{", "\"", "'", "_", "“", "‘" };

	[GeneratedRegex("(?:[\\.\\?\\!]\\s+|^)([^\\s\\.\\?\\!])")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex SentenceCaseRegex()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SentenceCaseRegex_0.Instance;
	}

	[GeneratedRegex("[-‑–—]")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex HyphenPattern()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__HyphenPattern_1.Instance;
	}

	[GeneratedRegex(".+@.+\\..+.")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex EmailPattern()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__EmailPattern_2.Instance;
	}

	[GeneratedRegex("^(\\/[\\w.]+)+")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex FilePathPattern()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__FilePathPattern_3.Instance;
	}

	[GeneratedRegex("^\\w+\\.\\w{1,3}$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex FilenamePattern()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__FilenamePattern_4.Instance;
	}

	[GeneratedRegex("(?![-‑–—])[a-z]+[A-Z].*")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex InternalCapitalPattern()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__InternalCapitalPattern_5.Instance;
	}

	[GeneratedRegex("[A-Z\\W]+['][s]|[qQ]+&[aA]")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex SpecialWord()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SpecialWord_6.Instance;
	}

	public static string CapitalizeText(this CapitalizationType type, string? text)
	{
		if (text == null)
		{
			return string.Empty;
		}
		switch (type)
		{
		case CapitalizationType.None:
		case CapitalizationType.SmallCaps:
			return text;
		case CapitalizationType.AllCaps:
			return text.ToUpper(CultureInfo.InvariantCulture);
		case CapitalizationType.TitleCase:
			return ToTitleCase(text);
		case CapitalizationType.StartCase:
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower(CultureInfo.InvariantCulture));
		default:
			throw new NotSupportedException();
		}
	}

	private static string ToTitleCase(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		string prevWord = string.Empty;
		return FindWord(text, delegate(string word, bool isFirstOrLast)
		{
			bool flag = !string.IsNullOrEmpty(prevWord) && prevWord.ToCharArray().Last() == ':';
			if (IsEmail(word) || IsUrl(word) || IsFilePath(word) || IsFilename(word) || HasInternalCapital(word) || IsSpecialWord(word))
			{
				return word;
			}
			Match match = HyphenPattern().Match(word);
			if (!match.Success)
			{
				word = (word.Contains("/") ? string.Join("/", word.Split('/').Select(Capitalize)) : (isFirstOrLast ? Capitalize(word) : ((flag || !ShouldAllowLowerCase(word)) ? Capitalize(word) : word.ToLower(CultureInfo.InvariantCulture))));
			}
			else
			{
				List<string> list = new List<string>();
				string[] array = word.Split(match.Value.ToCharArray());
				foreach (string text2 in array)
				{
					if (ShouldAllowLowerCase(text2))
					{
						list.Add(text2);
					}
					else
					{
						list.Add(Capitalize(text2));
					}
				}
				word = string.Join(match.Value, list);
			}
			prevWord = word;
			return word;
		});
	}

	private static string FindWord(string text, Func<string, bool, string> handleWordCallback)
	{
		bool isFirstOrLast = true;
		int startIndex = -1;
		for (int i = 0; i < text.Length; i++)
		{
			if (!char.IsWhiteSpace(text[i]))
			{
				if (startIndex == -1)
				{
					startIndex = i;
				}
			}
			else if (startIndex != -1)
			{
				processWord(i - 1);
				isFirstOrLast = false;
				startIndex = -1;
			}
		}
		isFirstOrLast = true;
		if (startIndex != -1)
		{
			processWord(text.Length - 1);
		}
		return text;
		void processWord(int endIndex)
		{
			string text2 = text.SubstringRange(startIndex, endIndex);
			string value = handleWordCallback(text2, isFirstOrLast);
			text = text.Remove(startIndex, text2.Length).Insert(startIndex, value);
		}
	}

	private static string Capitalize(string word)
	{
		word = word.ToLower(CultureInfo.InvariantCulture);
		if (word.Length == 0)
		{
			return word;
		}
		char c = word[0];
		if (_containers.Contains(c.ToString()))
		{
			if (word.Length == 1)
			{
				return word;
			}
			return c + Capitalize(word.Substring(1));
		}
		return SentenceCaseRegex().Replace(word, (Match s) => s.Value.ToUpper(CultureInfo.InvariantCulture));
	}

	private static bool ShouldAllowLowerCase(string word)
	{
		return _allowLowerCase.Contains(word.ToLower(CultureInfo.InvariantCulture));
	}

	private static bool IsEmail(string word)
	{
		return EmailPattern().IsMatch(word);
	}

	private static bool IsUrl(string word)
	{
		try
		{
			Uri result;
			return Uri.TryCreate(word, UriKind.Absolute, out result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
		}
		catch
		{
			return false;
		}
	}

	private static bool IsFilePath(string word)
	{
		return FilePathPattern().IsMatch(word);
	}

	private static bool IsFilename(string word)
	{
		return FilenamePattern().IsMatch(word);
	}

	private static bool HasInternalCapital(string word)
	{
		return InternalCapitalPattern().IsMatch(word);
	}

	private static bool IsSpecialWord(string word)
	{
		return SpecialWord().IsMatch(word);
	}

	public static IGraphics.Types.IText.Types.IAttributes.Types.Capitalization ToEntityCapitalizationType(this CapitalizationType source)
	{
		return source switch
		{
			CapitalizationType.None => IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.None, 
			CapitalizationType.AllCaps => IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.AllCaps, 
			CapitalizationType.SmallCaps => IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.SmallCaps, 
			CapitalizationType.TitleCase => IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.TitleCase, 
			CapitalizationType.StartCase => IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.StartCase, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static CapitalizationType ToCapitalizationType(this IGraphics.Types.IText.Types.IAttributes.Types.Capitalization source)
	{
		return source switch
		{
			IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.None => CapitalizationType.None, 
			IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.AllCaps => CapitalizationType.AllCaps, 
			IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.SmallCaps => CapitalizationType.SmallCaps, 
			IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.TitleCase => CapitalizationType.TitleCase, 
			IGraphics.Types.IText.Types.IAttributes.Types.Capitalization.StartCase => CapitalizationType.StartCase, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
