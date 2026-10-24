using System.Diagnostics.CodeAnalysis;

namespace Pro.Common.FileSystem;

public static class FilenameExtensions
{
	public static bool IsAudioFile([NotNullWhen(true)] this string? filename)
	{
		return FileExtensions.AudioExtensions.DoesMatch(filename);
	}

	public static bool IsImageFile([NotNullWhen(true)] this string? filename)
	{
		return FileExtensions.ImageExtensions.DoesMatch(filename);
	}

	public static bool IsVideoFile([NotNullWhen(true)] this string? filename)
	{
		return FileExtensions.VideoExtensions.DoesMatch(filename);
	}

	public static bool IsVisualMediaFile([NotNullWhen(true)] this string? filename)
	{
		if (!filename.IsImageFile())
		{
			return filename.IsVideoFile();
		}
		return true;
	}

	public static bool IsMediaFile([NotNullWhen(true)] this string? filename)
	{
		if (!filename.IsVisualMediaFile())
		{
			return filename.IsAudioFile();
		}
		return true;
	}

	public static bool IsTextFile(this string filename)
	{
		return FileExtensions.TextExtensions.DoesMatch(filename);
	}

	public static bool IsRTFFile(this string filename)
	{
		return FileExtensions.RTFExtensions.DoesMatch(filename);
	}

	public static bool IsWordXMLFile(this string filename)
	{
		return FileExtensions.WordXMLExtensions.DoesMatch(filename);
	}

	public static bool IsPowerPointFile(this string filename)
	{
		return FileExtensions.AllPowerPointExtensions.DoesMatch(filename);
	}

	public static bool IsOpenXmlPowerPointFile(this string filename)
	{
		return FileExtensions.OpenXMLPowerPointExtensions.DoesMatch(filename);
	}

	public static bool IsPDFFile(this string? filename)
	{
		return FileExtensions.PDFExtensions.DoesMatch(filename);
	}

	public static bool IsChordChartFile(this string filename)
	{
		return FileExtensions.ChordChartExtensions.DoesMatch(filename);
	}

	public static bool IsPro4DocumentFile(this string filename)
	{
		return FileExtensions.Pro4DocumentExtensions.DoesMatch(filename);
	}

	public static bool IsPro4DocumentBundleFile(this string filename)
	{
		return FileExtensions.Pro4DocumentBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro4PlaylistFile(this string filename)
	{
		return FileExtensions.Pro4PlaylistExtensions.DoesMatch(filename);
	}

	public static bool IsPro4PlaylistBundleFile(this string filename)
	{
		return FileExtensions.Pro4PlaylistBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro4TemplateFile(this string filename)
	{
		return FileExtensions.Pro4TemplateExtensions.DoesMatch(filename);
	}

	public static bool IsPro4TemplateBundleFile(this string filename)
	{
		return FileExtensions.Pro4TemplateBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro5DocumentFile(this string filename)
	{
		return FileExtensions.Pro5DocumentExtensions.DoesMatch(filename);
	}

	public static bool IsPro5DocumentBundleFile(this string filename)
	{
		return FileExtensions.Pro5DocumentBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro5PlaylistFile(this string filename)
	{
		return FileExtensions.Pro5PlaylistExtensions.DoesMatch(filename);
	}

	public static bool IsPro5PlaylistBundleFile(this string filename)
	{
		return FileExtensions.Pro5PlaylistBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro5TemplateFile(this string filename)
	{
		return FileExtensions.Pro5TemplateExtensions.DoesMatch(filename);
	}

	public static bool IsPro5TemplateBundleFile(this string filename)
	{
		return FileExtensions.Pro5TemplateBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro6DocumentFile(this string filename)
	{
		return FileExtensions.Pro6DocumentExtensions.DoesMatch(filename);
	}

	public static bool IsPro6DocumentBundleFile(this string filename)
	{
		return FileExtensions.Pro6DocumentBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro6PlaylistFile(this string filename)
	{
		return FileExtensions.Pro6PlaylistExtensions.DoesMatch(filename);
	}

	public static bool IsPro6PlaylistBundleFile(this string filename)
	{
		return FileExtensions.Pro6PlaylistBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro6TemplateFile(this string filename)
	{
		return FileExtensions.Pro6TemplateExtensions.DoesMatch(filename);
	}

	public static bool IsPro6TemplateBundleFile(this string filename)
	{
		return FileExtensions.Pro6TemplateBundleExtensions.DoesMatch(filename);
	}

	public static bool IsPro6DataFile(this string filename)
	{
		return FileExtensions.Pro6DataExtensions.DoesMatch(filename);
	}

	public static bool IsProThemeFile(this string filename)
	{
		return FileExtensions.ProThemeExtensions.DoesMatch(filename);
	}

	public static bool IsProPresentationFile([NotNullWhen(true)] this string? filename)
	{
		return FileExtensions.ProDocumentExtensions.DoesMatch(filename);
	}

	public static bool IsProBundleFile(this string filename)
	{
		return FileExtensions.ProDocumentBundleExtensions.DoesMatch(filename);
	}

	public static bool IsProPlaylistFile(this string filename)
	{
		return FileExtensions.ProPlaylistExtensions.DoesMatch(filename);
	}

	public static bool IsProDocumentFile(this string filename)
	{
		if (!filename.IsPro4DocumentFile() && !filename.IsPro5DocumentFile() && !filename.IsPro6DocumentFile())
		{
			return filename.IsProPresentationFile();
		}
		return true;
	}

	public static bool IsDocumentBundleFile(this string filename)
	{
		if (!filename.IsPro4DocumentBundleFile() && !filename.IsPro5DocumentBundleFile() && !filename.IsPro6DocumentBundleFile())
		{
			return filename.IsProBundleFile();
		}
		return true;
	}

	public static bool IsPlaylistBundleFile(this string filename)
	{
		if (!filename.IsPro4PlaylistBundleFile() && !filename.IsPro5PlaylistBundleFile() && !filename.IsPro6PlaylistBundleFile())
		{
			return filename.IsProPlaylistFile();
		}
		return true;
	}

	public static bool IsBundleFile(this string filename)
	{
		if (!filename.IsDocumentBundleFile() && !filename.IsPlaylistBundleFile())
		{
			return FileExtensions.SampleContentExtensions.DoesMatch(filename);
		}
		return true;
	}

	public static bool IsZipFile(this string filename)
	{
		return FileExtensions.ZipExtensions.DoesMatch(filename);
	}
}
