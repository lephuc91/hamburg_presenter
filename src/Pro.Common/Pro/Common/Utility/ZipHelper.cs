using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Pro.Common.FileSystem;
using Pro.Common.Utility.Zip;

namespace Pro.Common.Utility;

public static class ZipHelper
{
	internal static readonly Encoding FilenameEncoding = Encoding.UTF8;

	public static void UnzipFile(this string filename, string? destination, IUnzipPathStrategy? unzipPathStrategy = null)
	{
		new ZipArchive(filename).UnzipFile(destination, unzipPathStrategy);
	}

	public static void UnzipFile(this IZipArchive archive, string? destination, IUnzipPathStrategy? unzipPathStrategy = null)
	{
		archive.ExtractEntries(delegate(IZipEntry entry)
		{
			string text = entry.Filename.SanitizeFilePath("_");
			string text2 = unzipPathStrategy?.GetFilename(text) ?? text;
			entry.Extract((destination == null) ? text2 : Path.Combine(destination, text2));
		});
	}

	public static void ZipFolder(string sourceDirectoryName, string destinationArchiveFileName)
	{
		ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, CompressionLevel.Optimal, includeBaseDirectory: false, FilenameEncoding);
	}

	public static void ZipFolderExcluding(string sourceDirectoryName, string destinationArchiveFileName, IEnumerable<string> excludedFolders)
	{
		List<string> source = excludedFolders.Select((string f) => Path.GetFullPath(Path.Combine(sourceDirectoryName, f.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)).ToList();
		IEnumerable<string> enumerable = Directory.EnumerateFiles(sourceDirectoryName, "*", SearchOption.AllDirectories);
		using System.IO.Compression.ZipArchive destination = ZipFile.Open(destinationArchiveFileName, ZipArchiveMode.Create, FilenameEncoding);
		foreach (string item in enumerable)
		{
			string directoryName = Path.GetDirectoryName(item);
			string normalizedFileDir = directoryName.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			if (!source.Any((string ex) => normalizedFileDir.Equals(ex, StringComparison.OrdinalIgnoreCase) || normalizedFileDir.StartsWith(ex + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)))
			{
				string relativePath = Path.GetRelativePath(sourceDirectoryName, item);
				destination.CreateEntryFromFile(item, relativePath, CompressionLevel.Optimal);
			}
		}
	}
}
