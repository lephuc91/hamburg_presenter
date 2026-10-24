using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pro.Localization;

public static class CultureInfoExtensions
{
	public static bool TryFindLocalization(this CultureInfo cultureInfo, IReadOnlyCollection<string> availableLanguageIDs, string extension, [NotNullWhen(true)] out string? localizationID, out CultureInfo selectedCulture)
	{
		localizationID = null;
		selectedCulture = cultureInfo;
		string text = availableLanguageIDs.FirstOrDefault((string id) => MemoryExtensions.Equals(MemoryExtensions.AsSpan(cultureInfo.IetfLanguageTag), TrimExtensions(id, extension), StringComparison.Ordinal));
		if (text != null)
		{
			localizationID = appendExtension(text);
			return true;
		}
		if (cultureInfo.Parent != CultureInfo.InvariantCulture)
		{
			return cultureInfo.Parent.TryFindLocalization(availableLanguageIDs, extension, out localizationID, out selectedCulture);
		}
		return false;
		string appendExtension(string id)
		{
			if (!id.Contains(extension))
			{
				return id + "." + extension;
			}
			return id;
		}
	}

	private static ReadOnlySpan<char> TrimExtensions(string id, string extension)
	{
		int num = id.IndexOf(extension);
		int num2 = id.IndexOf('-');
		num2 = ((num2 < 0) ? id.Length : num2);
		int length = Math.Min(num2, num - 1);
		return MemoryExtensions.AsSpan(id).Slice(0, length);
	}
}
