using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Logging;
using Pro.Text;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Import;

public class FontDetector : IFontDetector
{
	private readonly TypefaceLibrary _typefaceLibrary;

	private readonly FontInfo[] _availableSystemFonts;

	public FontDetector(TypefaceLibrary typefaceLibrary)
	{
		_typefaceLibrary = typefaceLibrary;
		_availableSystemFonts = LoadAvailableSystemFonts();
	}

	public IReadOnlyCollection<MissingFontInfo> DetectMissingFonts(params IPresentation[] presentations)
	{
		Dictionary<FontInfo, MissingFontInfo> dictionary = new Dictionary<FontInfo, MissingFontInfo>();
		foreach (IPresentation presentation in presentations)
		{
			ProcessPresentationFonts(presentation, dictionary);
		}
		return dictionary.Values;
	}

	public FontInfo? SuggestReplacement(FontInfo missingFont)
	{
		try
		{
			FontInfo value = _availableSystemFonts.FirstOrDefault((FontInfo f) => string.Equals(f.SystemFamilyName, "Arial", StringComparison.OrdinalIgnoreCase));
			if (value.SystemFamilyName != null)
			{
				return value;
			}
			return (_availableSystemFonts.Length != 0) ? new FontInfo?(_availableSystemFonts[0]) : ((FontInfo?)null);
		}
		catch (Exception ex)
		{
			Log.Error("Error suggesting replacement for font '" + missingFont.SystemFamilyName + "': " + ex.Message, ex);
			return null;
		}
	}

	public bool IsFontAvailable(FontInfo fontInfo)
	{
		try
		{
			_typefaceLibrary.FindFont(fontInfo, out var isFallbackFont);
			return !isFallbackFont;
		}
		catch (Exception ex)
		{
			Log.Warning("Error checking font availability for '" + fontInfo.SystemFamilyName + "': " + ex.Message, ex);
			return false;
		}
	}

	public IReadOnlyCollection<FontInfo> GetAvailableSystemFonts()
	{
		return (IReadOnlyCollection<FontInfo>)(object)_availableSystemFonts;
	}

	private void ProcessPresentationFonts(IPresentation presentation, Dictionary<FontInfo, MissingFontInfo> missingFontsMap)
	{
		Dictionary<FontInfo, int> presentationMissingFonts = new Dictionary<FontInfo, int>();
		foreach (ClosedBezierPath allTextElement in presentation.GetAllTextElements())
		{
			foreach (RunSettings allRunSetting in allTextElement.GetAllRunSettings())
			{
				CheckRunSettingsForMissingFonts(allRunSetting, presentationMissingFonts);
			}
		}
		AggregateMissingFonts(presentation, presentationMissingFonts, missingFontsMap);
	}

	private void CheckRunSettingsForMissingFonts(RunSettings runSettings, Dictionary<FontInfo, int> presentationMissingFonts)
	{
		if (!runSettings.OriginalFont.HasValue)
		{
			return;
		}
		if (runSettings.IsFontMissing)
		{
			FontInfo value = runSettings.OriginalFont.Value;
			if (!IsFontAvailable(value))
			{
				IncrementFontUsageCount(presentationMissingFonts, value);
			}
		}
		else if (!IsFontAvailable(runSettings.Font))
		{
			IncrementFontUsageCount(presentationMissingFonts, runSettings.OriginalFont.Value);
		}
	}

	private static void IncrementFontUsageCount(Dictionary<FontInfo, int> fontUsageMap, FontInfo font)
	{
		fontUsageMap[font] = fontUsageMap.GetValueOrDefault(font, 0) + 1;
	}

	private void AggregateMissingFonts(IPresentation presentation, Dictionary<FontInfo, int> presentationMissingFonts, Dictionary<FontInfo, MissingFontInfo> missingFontsMap)
	{
		foreach (KeyValuePair<FontInfo, int> presentationMissingFont in presentationMissingFonts)
		{
			presentationMissingFont.Deconstruct(out var key, out var value);
			FontInfo fontInfo = key;
			int num = value;
			FontInfo? suggestedReplacement = SuggestReplacement(fontInfo);
			MissingFontInfo value2 = new MissingFontInfo(fontInfo, suggestedReplacement, presentation.Name, num);
			if (missingFontsMap.TryGetValue(fontInfo, out MissingFontInfo value3))
			{
				MissingFontInfo value4 = new MissingFontInfo(fontInfo, suggestedReplacement, value3.PresentationOrThemeName + ", " + presentation.Name, value3.UsageCount + num);
				missingFontsMap[fontInfo] = value4;
			}
			else
			{
				missingFontsMap[fontInfo] = value2;
			}
		}
	}

	private FontInfo[] LoadAvailableSystemFonts()
	{
		try
		{
			if (_typefaceLibrary.AvailableTypefaces?.AllFonts == null)
			{
				Log.Warning("No typefaces available from TypefaceLibrary");
				return Array.Empty<FontInfo>();
			}
			return _typefaceLibrary.AvailableTypefaces.AllFonts.Select((Font font) => font.Info).ToArray();
		}
		catch (Exception ex)
		{
			Log.Error("Error loading available system fonts: " + ex.Message, ex);
			return Array.Empty<FontInfo>();
		}
	}
}
