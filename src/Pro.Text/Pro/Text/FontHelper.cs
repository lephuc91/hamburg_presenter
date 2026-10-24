using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Pro.Text;

public static class FontHelper
{
	public static Font? FindFont(FontGroup? fontGroup, bool isBold, bool isItalic)
	{
		if (fontGroup == null)
		{
			return null;
		}
		if (!isBold)
		{
			if (!isItalic)
			{
				return (from f in fontGroup.Fonts
					where !f.Info.IsBold && !f.Info.IsItalic
					orderby f.Info.Weight.ToOpenTypeWeight()
					select f).FirstOrDefault();
			}
			return (from f in fontGroup.Fonts
				where !f.Info.IsBold && f.Info.IsItalic
				orderby f.Info.Weight.ToOpenTypeWeight()
				select f).FirstOrDefault();
		}
		if (!isItalic)
		{
			return (from f in fontGroup.Fonts
				where f.Info.IsBold && !f.Info.IsItalic
				orderby Math.Abs(f.Info.Weight.ToOpenTypeWeight() - FontWeights.Bold.ToOpenTypeWeight())
				select f).FirstOrDefault();
		}
		return (from f in fontGroup.Fonts
			where f.Info.IsBold && f.Info.IsItalic
			orderby Math.Abs(f.Info.Weight.ToOpenTypeWeight() - FontWeights.Bold.ToOpenTypeWeight())
			select f).FirstOrDefault();
	}

	public static bool IsBoldAvailable(this FontInfo info)
	{
		return info.GetFontGroup().IsBoldAvailable();
	}

	public static bool IsBoldAvailable(this FontGroup? group)
	{
		if (group == null)
		{
			return false;
		}
		IEnumerable<FontWeight> source = group.Fonts.Select((Font f) => f.Info.Weight);
		if (source.Any((FontWeight f) => f < FontWeights.SemiBold))
		{
			return source.Any((FontWeight f) => f >= FontWeights.SemiBold);
		}
		return false;
	}

	public static bool IsItalicAvailable(this FontInfo info)
	{
		return info.GetFontGroup().IsItalicAvailable();
	}

	public static bool IsItalicAvailable(this FontGroup? group)
	{
		return group?.Fonts.Any((Font f) => f.Info.IsItalic) ?? false;
	}

	public static FontInfo ToggleBold(this FontInfo currentFontInfo)
	{
		FontGroup fontGroup = currentFontInfo.GetFontGroup();
		if (fontGroup == null)
		{
			return currentFontInfo;
		}
		bool isBold = currentFontInfo.IsBold;
		bool isItalic = currentFontInfo.IsItalic;
		return (FindFont(fontGroup, !isBold, isItalic) ?? FindFont(fontGroup, !isBold, isItalic: false) ?? fontGroup.Fonts[0]).Info;
	}

	public static FontInfo ToggleItalic(this FontInfo currentFontInfo)
	{
		FontGroup fontGroup = currentFontInfo.GetFontGroup();
		if (fontGroup == null)
		{
			return currentFontInfo;
		}
		bool isBold = currentFontInfo.IsBold;
		bool isItalic = currentFontInfo.IsItalic;
		return (FindFont(fontGroup, isBold, !isItalic) ?? FindFont(fontGroup, isBold: false, !isItalic) ?? fontGroup.Fonts[0]).Info;
	}

	public static FontGroup? GetFontGroup(this FontInfo fontInfo)
	{
		return fontInfo.GetFont().GetFontGroup();
	}

	public static FontInfo GetStyledFontVariant(this FontInfo fontInfo)
	{
		return FindFont(fontInfo.GetFontGroup(), fontInfo.IsBold, fontInfo.IsItalic)?.Info ?? fontInfo;
	}

	private static Font GetFont(this FontInfo info)
	{
		return SharedTypefaceLibrary.Library.FindFont(info);
	}

	private static FontGroup? GetFontGroup(this Font font)
	{
		return SharedTypefaceLibrary.Library.AvailableTypefaces.FindFontGroup(font);
	}
}
