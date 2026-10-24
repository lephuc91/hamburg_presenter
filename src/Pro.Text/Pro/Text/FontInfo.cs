using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Collections;

namespace Pro.Text;

public record struct FontInfo(string SystemFamilyName, string? SystemFaceName, string DisplayFamilyName, string? DisplayFaceName, string? FullName, string? PSName, FontWeight Weight, FontStretch Stretch, bool IsItalic, bool IsUnicode = true)
{
	public bool IsBold => Weight >= FontWeights.SemiBold;

	public string? DisplayName
	{
		get
		{
			if (string.IsNullOrEmpty(DisplayFamilyName) && string.IsNullOrEmpty(DisplayFaceName))
			{
				if (string.IsNullOrEmpty(FullName))
				{
					return PSName;
				}
				return FullName;
			}
			return (DisplayFamilyName + " " + DisplayFaceName).Trim();
		}
	}

	private const string SystemLanguageTag = "en-US";

	public FontInfo(string SystemFamilyName, string? SystemFaceName, string DisplayFamilyName, string? DisplayFaceName, string? FullName, string? PSName, FontWeight Weight, FontStretch Stretch, bool IsItalic, bool IsUnicode = true)
	{
		this.SystemFamilyName = SystemFamilyName;
		this.SystemFaceName = SystemFaceName;
		this.DisplayFamilyName = DisplayFamilyName;
		this.DisplayFaceName = DisplayFaceName;
		this.FullName = FullName;
		this.PSName = PSName;
		this.Weight = Weight;
		this.Stretch = Stretch;
		this.IsItalic = IsItalic;
		this.IsUnicode = IsUnicode;
	}

	public FontInfo(string familyName)
		: this(familyName, null, null)
	{
	}

	public FontInfo(string familyName, string? faceName, string? psName)
		: this(familyName, faceName, psName, FontWeights.Normal, FontStretches.Normal, isItalic: false)
	{
	}

	public FontInfo(string familyName, string? faceName, string? psName, FontWeight weight, FontStretch stretch, bool isItalic, bool isUnicode = true)
		: this(familyName, faceName, familyName, faceName, null, psName, weight, stretch, isItalic, isUnicode)
	{
	}

	public FontInfo(Typeface typeface)
		: this(GetLanguageSpecificName(typeface.FontFamily.FamilyNames, "en-US", CultureInfo.CurrentUICulture.IetfLanguageTag) ?? string.Empty, GetLanguageSpecificName(typeface.FaceNames, "en-US", CultureInfo.CurrentUICulture.IetfLanguageTag), GetLanguageSpecificName(typeface.FontFamily.FamilyNames, CultureInfo.CurrentUICulture.IetfLanguageTag, "en-US") ?? string.Empty, GetLanguageSpecificName(typeface.FaceNames, CultureInfo.CurrentUICulture.IetfLanguageTag, "en-US"), null, null, typeface.Weight, typeface.Stretch, typeface.Style == FontStyles.Italic || typeface.Style == FontStyles.Oblique)
	{
	}

	private static string? GetLanguageSpecificName(LanguageSpecificStringDictionary names, string primaryLanguageTag, string fallbackLanguageTag)
	{
		if (names.Empty())
		{
			return null;
		}
		return getName(primaryLanguageTag) ?? getName(fallbackLanguageTag) ?? names.FirstOrDefault().Value;
		string getName(string languageTag)
		{
			return names.FirstOrDefault((KeyValuePair<XmlLanguage, string> n) => n.Key.IetfLanguageTag.Equals(languageTag, StringComparison.OrdinalIgnoreCase)).Value;
		}
	}
}
