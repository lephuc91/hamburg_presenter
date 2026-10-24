using System;
using System.IO;
using Pro.Common.Logging;
using Pro.Common.Win32;

namespace Pro.Common.FileSystem;

public static class PathExtensions
{
	public static string GetPathRelativeTo(this string root, string target)
	{
		Uri uri = new Uri(target);
		return Uri.UnescapeDataString(new Uri(root).MakeRelativeUri(uri).OriginalString);
	}

	public static bool HasExtension(this string filename, string extension)
	{
		return Path.GetExtension(filename).Equals(extension, StringComparison.OrdinalIgnoreCase);
	}

	public static string NormalizePath(this string? path, bool isDirectory = true)
	{
		try
		{
			return OnNormalizePath(path ?? string.Empty, isDirectory);
		}
		catch (Exception ex)
		{
			Log.Error("Failed to normalize path: {0}\n{1}", path, ex);
			throw new AggregateException(ex);
		}
	}

	public static bool TryNormalizePath(this string path, out string normalizedPath, bool isDirectory = true)
	{
		try
		{
			normalizedPath = OnNormalizePath(path, isDirectory);
			return true;
		}
		catch (Exception)
		{
			normalizedPath = path;
			return false;
		}
	}

	private static string OnNormalizePath(string path, bool isDirectory)
	{
		return Path.GetFullPath(new Uri(path, UriKind.Absolute).LocalPath).TrimTrailingSlashes() + (isDirectory ? Path.DirectorySeparatorChar.ToString() : string.Empty);
	}

	public static string TrimTrailingSlashes(this string path)
	{
		return path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
	}

	public static bool IsPathEqual(this string lhs, string rhs)
	{
		lhs.TryNormalizePath(out string normalizedPath);
		rhs.TryNormalizePath(out string normalizedPath2);
		return string.Equals(normalizedPath, normalizedPath2, StringComparison.OrdinalIgnoreCase);
	}

	public static bool PathContains(this string lhs, string rhs)
	{
		lhs.TryNormalizePath(out string normalizedPath);
		rhs.TryNormalizePath(out string normalizedPath2);
		return normalizedPath.Contains(normalizedPath2);
	}

	public static bool IsUNC(this string path)
	{
		return WindowsFunctions.PathIsUNCW(path);
	}

	public static string? GetDirectoryNameWithoutPath(this string path)
	{
		return Path.GetFileName(Path.GetDirectoryName(path));
	}
}
