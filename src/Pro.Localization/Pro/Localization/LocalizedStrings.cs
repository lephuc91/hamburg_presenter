using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Utility;

namespace Pro.Localization;

public static class LocalizedStrings
{
	private const string LanguageDirectoryExtension = "lproj";

	private const string CocoaStringsExtension = "strings";

	private static Dictionary<string, string> _stringTable = new Dictionary<string, string>();

	private static readonly CultureInfo EnglishCulture = new CultureInfo("en-us");

	private static readonly HashSet<string> _rootPaths = new HashSet<string>();

	public static CultureInfo? LoadedCulture { get; private set; }

	public static bool Load(string rootPath, CultureInfo cultureInfo, out string errorMessage)
	{
		if (cultureInfo == null)
		{
			throw new ArgumentNullException("cultureInfo");
		}
		if (!_rootPaths.Add(rootPath))
		{
			throw new InvalidOperationException("Can't load the same LocalizedStrings table more than once.");
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (!LoadStrings(dictionary, rootPath, EnglishCulture, out errorMessage))
		{
			_stringTable = ((_stringTable.Count == 0) ? dictionary : _stringTable.Concat<KeyValuePair<string, string>>(dictionary).ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value));
			return false;
		}
		if (cultureInfo.TwoLetterISOLanguageName != EnglishCulture.TwoLetterISOLanguageName)
		{
			LoadStrings(dictionary, rootPath, cultureInfo, out errorMessage);
		}
		_stringTable = ((_stringTable.Count == 0) ? dictionary : _stringTable.Concat<KeyValuePair<string, string>>(dictionary).ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value));
		return true;
	}

	internal static void Unload()
	{
		_rootPaths.Clear();
		_stringTable.Clear();
	}

	public static string Get(string? key, params object?[] parameters)
	{
		if (key.NullableIsNullOrEmpty())
		{
			Log.Warning("Could not get value for " + key);
			return string.Join(string.Empty, parameters);
		}
		if (_stringTable.TryGetValue(key, out string value))
		{
			if (parameters != null && parameters.Any())
			{
				return string.Format(value, parameters);
			}
			return value;
		}
		return key;
	}

	public static string Get<E>(string key, params E[] parameters) where E : Enum
	{
		string[] array = parameters.Select(Get).ToArray();
		object[] parameters2 = array;
		return Get(key, parameters2);
	}

	public static string Get<E>(E enumValue) where E : Enum
	{
		LocalizedStringAttribute attribute = enumValue.GetAttribute<E, LocalizedStringAttribute>();
		if (attribute != null)
		{
			return Get(attribute.Key);
		}
		return enumValue.ToString();
	}

	private static bool LoadStrings(Dictionary<string, string> stringTable, string rootPath, CultureInfo cultureInfo, out string errorMessage)
	{
		try
		{
			string[] availableLanguageIDs = Directory.GetDirectories(rootPath).Select(Path.GetFileName).NotNull()
				.ToArray();
			if (!cultureInfo.TryFindLocalization((IReadOnlyCollection<string>)(object)availableLanguageIDs, "lproj", out string localizationID, out CultureInfo selectedCulture) || !CheckLanguageDictionary(localizationID, rootPath, out string languageDictionary))
			{
				errorMessage = "Could not find a localization for " + cultureInfo.Name;
				Log.Error(errorMessage);
				return false;
			}
			LoadedCulture = selectedCulture;
			string[] files = Directory.GetFiles(languageDictionary, "*.strings");
			for (int i = 0; i < files.Length; i++)
			{
				foreach (KeyValuePair<string, string> item in CocoaStringsReader.Read(files[i]))
				{
					item.Deconstruct(out var key, out var value);
					string key2 = key;
					string value2 = value;
					stringTable[key2] = value2;
				}
			}
		}
		catch (Exception ex)
		{
			if (!(ex is DirectoryNotFoundException))
			{
				if (ex is UnauthorizedAccessException)
				{
					errorMessage = "Recommend reboot";
					Log.Error($"{errorMessage}: {ex}");
					return false;
				}
				errorMessage = "Exception occured";
				Log.Error($"{errorMessage}: {ex}");
				return false;
			}
			errorMessage = "Recommend reinstall ProPresenter";
			Log.Error($"{errorMessage}: {ex}");
			return false;
		}
		errorMessage = "";
		return true;
	}

	private static bool CheckLanguageDictionary(string localizationId, string rootPath, out string languageDictionary)
	{
		languageDictionary = Path.Combine(rootPath, localizationId);
		return Directory.Exists(languageDictionary);
	}
}
