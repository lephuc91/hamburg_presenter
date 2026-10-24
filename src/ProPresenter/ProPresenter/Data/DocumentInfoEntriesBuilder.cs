using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.FileSystem;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.Data;

public static class DocumentInfoEntriesBuilder
{
	public static IReadOnlyList<DocumentInfoEntry> Build(IEnumerable<DocumentInfoSource> sources, IFileSystem fileSystem, ICommonPathsWrapper paths)
	{
		Dictionary<string, string> dictionary = null;
		List<DocumentInfoEntry> list = new List<DocumentInfoEntry>();
		foreach (DocumentInfoSource source in sources)
		{
			string text = source.Kind;
			string text2 = source.FileName;
			if (text == null || text2 == null)
			{
				string key = source.Id.FormatCrdtFileNameId();
				try
				{
					if (dictionary == null)
					{
						try
						{
							dictionary = BuildCloudFileIndex(fileSystem, paths);
						}
						catch
						{
							dictionary = new Dictionary<string, string>();
						}
					}
					dictionary.TryGetValue(key, out var value);
					if (value != null && value.TryParseFilenameAndIdFromCrdtFile(out string baseFilename, out Guid? _))
					{
						string directoryName = fileSystem.Path.GetDirectoryName(value);
						string text3 = ((directoryName != null) ? fileSystem.Path.GetRelativePath(paths.Base, directoryName) : null);
						if (text == null)
						{
							text = DeriveKind(baseFilename, text3, fileSystem, paths);
						}
						if (text2 == null)
						{
							if (text3 != null && text3.StartsWith(paths.ThemesPostfix + fileSystem.Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
							{
								string text4 = text3;
								int num = paths.ThemesPostfix.Length + 1;
								text2 = text4.Substring(num, text4.Length - num);
							}
							else if (directoryName != null)
							{
								string text5 = fileSystem.Directory.EnumerateFiles(directoryName, baseFilename + ".*").FirstOrDefault((string f) => !f.EndsWith(".proCloud", StringComparison.OrdinalIgnoreCase) && !f.EndsWith(".proLocal", StringComparison.OrdinalIgnoreCase));
								text2 = ((text5 != null) ? fileSystem.Path.GetFileName(text5) : baseFilename);
							}
							else
							{
								text2 = baseFilename;
							}
						}
					}
				}
				catch
				{
				}
			}
			list.Add(new DocumentInfoEntry(source.Id, text, text2, source.SentToCore, source.LastSentVersion, source.CurrentVersionVector));
		}
		return list;
	}

	private static Dictionary<string, string> BuildCloudFileIndex(IFileSystem fileSystem, ICommonPathsWrapper paths)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		foreach (string item in fileSystem.Directory.EnumerateFiles(paths.Base, "*.proCloud", SearchOption.AllDirectories))
		{
			if (item.TryParseFilenameAndIdFromCrdtFile(out string _, out Guid? id))
			{
				string key = id.Value.FormatCrdtFileNameId();
				dictionary.TryAdd(key, item);
			}
		}
		return dictionary;
	}

	public static string DeriveKind(string baseFileName, string? relativeDirectory, IFileSystem fileSystem, ICommonPathsWrapper paths)
	{
		string[] source = new string[5]
		{
			paths.ConfigurationPostfix,
			paths.PlaylistPostfix,
			paths.TemplatesPostfix,
			fileSystem.Path.Combine(paths.PlaylistPostfix, paths.TemplatesPostfix),
			paths.LibraryPostfix
		};
		char reference;
		if (relativeDirectory != null && source.Any((string f) => relativeDirectory.Equals(f, StringComparison.OrdinalIgnoreCase)))
		{
			reference = char.ToLowerInvariant(baseFileName[0]);
			return string.Concat(new ReadOnlySpan<char>(in reference), baseFileName.Substring(1, baseFileName.Length - 1));
		}
		if (relativeDirectory != null)
		{
			string? text = relativeDirectory;
			ReadOnlySpan<char> readOnlySpan = paths.LibraryPostfix;
			reference = fileSystem.Path.DirectorySeparatorChar;
			if (text.StartsWith(string.Concat(readOnlySpan, new ReadOnlySpan<char>(in reference)), StringComparison.OrdinalIgnoreCase))
			{
				return "presentation";
			}
		}
		if (relativeDirectory != null)
		{
			if (!relativeDirectory.Equals(paths.ThemesPostfix, StringComparison.OrdinalIgnoreCase))
			{
				string? text2 = relativeDirectory;
				ReadOnlySpan<char> readOnlySpan2 = paths.ThemesPostfix;
				reference = fileSystem.Path.DirectorySeparatorChar;
				if (!text2.StartsWith(string.Concat(readOnlySpan2, new ReadOnlySpan<char>(in reference)), StringComparison.OrdinalIgnoreCase))
				{
					goto IL_0130;
				}
			}
			return "theme";
		}
		goto IL_0130;
		IL_0130:
		return relativeDirectory ?? baseFileName;
	}
}
