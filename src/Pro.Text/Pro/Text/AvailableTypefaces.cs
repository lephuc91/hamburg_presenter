using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.FileSystem;
using Pro.Common.Logging;

namespace Pro.Text;

public class AvailableTypefaces
{
	private static readonly string[] SupportedExtensions = new string[4] { ".ttf", ".ttc", ".otf", ".otc" };

	private static readonly string FontRegKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts";

	private static readonly string SystemWideFontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

	private static readonly string LocalUserFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows", "Fonts");

	private static readonly string AdobeCCFontPath;

	private static readonly string PowerPointCloudFontsPath;

	private readonly TypefaceLibrary _library;

	private readonly Dictionary<FontInfo, Font> _fontMap = new Dictionary<FontInfo, Font>();

	public Font[] AllFonts { get; private set; }

	public FontGroup[] FontGroups { get; private set; }

	internal AvailableTypefaces(TypefaceLibrary library)
	{
		_library = library;
		LoadFonts();
	}

	private static bool IsFileSupported(string? filename, bool allowEmptyExtension)
	{
		try
		{
			string extension = Path.GetExtension(filename);
			return (allowEmptyExtension && string.IsNullOrEmpty(extension)) || SupportedExtensions.Contains<string>(Path.GetExtension(filename), StringComparer.OrdinalIgnoreCase);
		}
		catch (ArgumentException)
		{
			Log.Error("Font file " + filename + " could not be loaded.");
		}
		return false;
	}

	private void LoadFonts()
	{
		uint languageId = (uint)CultureInfo.CurrentUICulture.LCID;
		string[] array = getSystemFontFiles(new(RegistryKey, string)[1] { (Registry.CurrentUser.OpenSubKey(FontRegKey), LocalUserFontPath) });
		string[] source = getSystemFontFiles(new(RegistryKey, string)[1] { (Registry.LocalMachine.OpenSubKey(FontRegKey), SystemWideFontPath) });
		HashSet<string> userFontNames = new HashSet<string>((from name in array.Where((string path) => !string.IsNullOrEmpty(path)).Select(Path.GetFileName)
			where !string.IsNullOrEmpty(name)
			select name).Cast<string>(), StringComparer.OrdinalIgnoreCase);
		string[] fontFiles2 = source.Where(delegate(string systemFont)
		{
			string fileName = Path.GetFileName(systemFont);
			if (!userFontNames.Contains(fileName))
			{
				return true;
			}
			Log.Info("Excluding system font '" + systemFont + "' because user version exists");
			return false;
		}).ToArray();
		loadFonts(array, FontSourceType.User);
		loadFonts(fontFiles2, FontSourceType.System);
		loadFonts(getAdobeCCFontFiles(), FontSourceType.AdobeCC);
		loadFonts(getPowerPointCloudFontFiles(), FontSourceType.PowerPoint);
		AllFonts = _fontMap.Values.OrderBy((Font f) => f.Info.DisplayName).ToArray();
		FontGroups = (from f in AllFonts
			group f by f.Info.SystemFamilyName).Collect((IGrouping<string, Font> g) => new FontGroup(g.Key, g.First().Info.DisplayFamilyName, g.ToArray())).ToArray();
		static string[] getAdobeCCFontFiles()
		{
			if (!Directory.Exists(AdobeCCFontPath))
			{
				return Array.Empty<string>();
			}
			List<string> list2 = new List<string>();
			foreach (string item in Directory.EnumerateFiles(AdobeCCFontPath))
			{
				string text5 = item.NormalizePath(isDirectory: false);
				if (IsFileSupported(text5, allowEmptyExtension: true) && !list2.Contains(text5))
				{
					list2.Add(text5);
				}
			}
			return list2.ToArray();
		}
		static string[] getPowerPointCloudFontFiles()
		{
			if (!Directory.Exists(PowerPointCloudFontsPath))
			{
				return Array.Empty<string>();
			}
			List<string> list3 = new List<string>();
			EnumerationOptions enumerationOptions = new EnumerationOptions
			{
				RecurseSubdirectories = true
			};
			foreach (string item2 in Directory.EnumerateFiles(PowerPointCloudFontsPath, "*.*", enumerationOptions))
			{
				string text6 = item2.NormalizePath(isDirectory: false);
				if (IsFileSupported(text6, allowEmptyExtension: false) && !list3.Contains(text6))
				{
					list3.Add(text6);
				}
			}
			return list3.ToArray();
		}
		static string[] getSystemFontFiles((RegistryKey?, string)[] fontLocations)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < fontLocations.Length; i++)
			{
				var (registryKey, text) = fontLocations[i];
				if (registryKey != null)
				{
					string[] valueNames = registryKey.GetValueNames();
					foreach (string name2 in valueNames)
					{
						string text2 = registryKey.GetValue(name2) as string;
						if (IsFileSupported(text2, allowEmptyExtension: false))
						{
							if (!Path.IsPathRooted(text2))
							{
								text2 = Path.Combine(text, text2 ?? string.Empty);
							}
							string text3 = text2.NormalizePath(isDirectory: false);
							if (!list.Contains(text3) && File.Exists(text3))
							{
								list.Add(text3);
							}
						}
					}
					if (Directory.Exists(text))
					{
						foreach (string item3 in Directory.EnumerateFiles(text))
						{
							string text4 = item3.NormalizePath(isDirectory: false);
							if (IsFileSupported(text4, allowEmptyExtension: false) && !list.Contains(text4))
							{
								list.Add(text4);
							}
						}
					}
				}
			}
			return list.ToArray();
		}
		void loadFonts(IEnumerable<string> fontFiles, FontSourceType sourceType)
		{
			foreach (string fontFile in fontFiles)
			{
				int num = 1;
				for (int k = 0; k < num; k++)
				{
					Font font = new Font(_library, fontFile, k, languageId, sourceType);
					if (!font.IsValidFont)
					{
						Log.Warning("Attempted to load Invalid Font " + fontFile);
						font.Dispose();
					}
					else
					{
						num = Math.Max(num, font.FaceCount);
						if (string.IsNullOrWhiteSpace(font.Info.SystemFamilyName) || string.IsNullOrWhiteSpace(font.Info.SystemFaceName))
						{
							font.Dispose();
						}
						else if (!_fontMap.TryAdd(font.Info, font))
						{
							Log.Warning("Duplicate font found: " + font.Info.DisplayName + " from " + fontFile);
							font.Dispose();
						}
					}
				}
			}
		}
	}

	internal Font? GetFont(FontInfo fontInfo)
	{
		if (!_fontMap.TryGetValue(fontInfo, out Font value))
		{
			return null;
		}
		return value;
	}

	public FontGroup? FindFontGroup(Font font)
	{
		return FontGroups?.FirstOrDefault((FontGroup g) => g.Fonts.Contains(font));
	}

	static AvailableTypefaces()
	{
		global::_003C_003Ey__InlineArray6<string> buffer = default(global::_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "Adobe";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "CoreSync";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "plugins";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "livetype";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "r";
		AdobeCCFontPath = Path.Combine(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray6<string>, string>(in buffer, 6));
		global::_003C_003Ey__InlineArray5<string> buffer2 = default(global::_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<string>, string>(ref buffer2, 0) = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<string>, string>(ref buffer2, 1) = "Microsoft";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<string>, string>(ref buffer2, 2) = "FontCache";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<string>, string>(ref buffer2, 3) = "4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<string>, string>(ref buffer2, 4) = "CloudFonts";
		PowerPointCloudFontsPath = Path.Combine(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray5<string>, string>(in buffer2, 5));
	}
}
