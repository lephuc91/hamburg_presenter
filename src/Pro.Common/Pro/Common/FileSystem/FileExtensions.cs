using System.IO;
using Pro.Common.Utility;

namespace Pro.Common.FileSystem;

public static class FileExtensions
{
	private const string AudioFilesDescription = "Audio Files";

	private const string ImageFilesDescription = "Image Files";

	private const string VideoFilesDescription = "Video Files";

	private const string TextFilesDescription = "Text Files";

	private const string WordFilesDescription = "Word Files";

	private const string PowerPointFilesDescription = "PowerPoint Files";

	private const string PDFFilesDescription = "PDF Files";

	private const string ChordChartFilesDescription = "ChordChart Files";

	private const string Pro4DocumentsDescription = "ProPresenter4 Document Files";

	private const string Pro4PlaylistsDescription = "ProPresenter4 Playlist Files";

	private const string Pro4TemplatesDescription = "ProPresenter4 Template Files";

	private const string Pro5DocumentsDescription = "ProPresenter5 Document Files";

	private const string Pro5PlaylistsDescription = "ProPresenter5 Playlist Files";

	private const string Pro5TemplatesDescription = "ProPresenter5 Template Files";

	private const string Pro6DocumentsDescription = "ProPresenter6 Document Files";

	private const string Pro6PlaylistsDescription = "ProPresenter6 Playlist Files";

	private const string Pro6TemplatesDescription = "ProPresenter6 Template Files";

	private const string Pro6DataDescription = "ProPresenter6 Data Files";

	private const string ProPresentationsDescription = "ProPresenter Presentation Files";

	private const string ProPlaylistsDescription = "ProPresenter Playlist Files";

	private const string ProThemeDescription = "ProPresenter Theme Files";

	public const string TextExtension = ".txt";

	public const string RTFExtension = ".rtf";

	public const string CrashDumpFile = ".crash";

	public const string MiniDumpFile = ".mdmp";

	public const string LogFile = ".log";

	public const string SystemInfoFile = ".systeminfo";

	public const string WordXMLExtension = ".docx";

	public const string PPBinaryExtension = ".ppt";

	public const string PPXMLExtension = ".pptx";

	public const string PPShowBinaryExtension = ".pps";

	public const string PPShowXMLExtension = ".ppsx";

	public const string PDFExtension = ".pdf";

	public const string Pro4DocumentExtension = ".pro4";

	public const string Pro4DocumentBundleExtension = ".pro4x";

	public const string Pro4TemplateExtension = ".pro4Template";

	public const string Pro4TemplateBundleExtension = ".pro4TemplateBundle";

	public const string Pro4PlaylistExtension = ".pro4pl";

	public const string Pro4PlaylistBundleExtension = ".pro4plx";

	public const string Pro5DocumentExtension = ".pro5";

	public const string Pro5DocumentBundleExtension = ".pro5x";

	public const string Pro5TemplateExtension = ".pro5Template";

	public const string Pro5TemplateBundleExtension = ".pro5TemplateBundle";

	public const string Pro5PlaylistExtension = ".pro5pl";

	public const string Pro5PlaylistBundleExtension = ".pro5plx";

	public const string Pro6DocumentExtension = ".pro6";

	public const string Pro6DocumentBundleExtension = ".pro6x";

	public const string Pro6TemplateExtension = ".pro6Template";

	public const string Pro6TemplateBundleExtension = ".pro6TemplateBundle";

	public const string Pro6PlaylistExtension = ".pro6pl";

	public const string Pro6PlaylistBundleExtension = ".pro6plx";

	public const string Pro6DataExtension = ".pro6data";

	public const string PresentationExtension = ".pro";

	public const string CloudFileExtension = ".proCloud";

	public const string ProDocumentBundleExtension = ".proBundle";

	public const string ProThemeExtension = ".proTheme";

	public const string ProPlaylistExtension = ".proPlaylist";

	public const string ProPreferenceExtension = ".proPref";

	public const string ProLocalExtension = ".proLocal";

	public const string TransitionPresetExtension = ".transitionPreset";

	public const string EffectPresetExtension = ".effectPreset";

	public const string SampleContentExtension = ".sampleContent";

	public const string ZipExtension = ".zip";

	public static FileExtensionGroup AudioExtensions { get; } = new FileExtensionGroup("Audio Files", ".ra", ".ram", ".au", ".caf", ".aac", ".aif", ".aiff", ".iff", ".m4a", ".mid", ".midi", ".mp3", ".mpa", ".wav", ".mp4", ".wma");

	public static FileExtensionGroup ImageExtensions { get; } = new FileExtensionGroup("Image Files", ".gif", ".jpg", ".jpeg", ".png", ".bmp", ".dib", ".tif", ".tiff", ".wmf", ".ras", ".eps", ".pcx", ".pcd", ".tga", ".psd", ".heic");

	public static FileExtensionGroup VideoExtensions { get; } = new FileExtensionGroup("Video Files", ".avi", ".mpg", ".mpeg", ".mov", ".qt", ".wmv", ".mp4", ".mxf", ".flv", ".m4v", ".dv", ".3gp", ".3g2", ".3gp2", ".m2v", ".mv4");

	public static FileExtensionGroup ChordChartExtensions { get; } = new FileExtensionGroup("ChordChart Files", ".pdf", ".gif", ".jpg", ".jpeg", ".png", ".bmp", ".dib", ".tif", ".wmf", ".ras", ".eps", ".pcx", ".pcd", ".tga");

	public static FileExtensionGroup TextExtensions { get; } = new FileExtensionGroup("Text Files", ".txt");

	public static FileExtensionGroup RTFExtensions { get; } = new FileExtensionGroup("Text Files", ".rtf");

	public static FileExtensionGroup AllTextExtensions { get; } = new FileExtensionGroup("Text Files", ".txt", ".rtf");

	public static FileExtensionGroup WordXMLExtensions { get; } = new FileExtensionGroup("Word Files", ".docx");

	public static FileExtensionGroup AllWordExtensions { get; } = new FileExtensionGroup("Word Files", ".docx");

	public static FileExtensionGroup AllPowerPointExtensions { get; } = new FileExtensionGroup("PowerPoint Files", ".ppt", ".pptx", ".pps", ".ppsx");

	public static FileExtensionGroup OpenXMLPowerPointExtensions { get; } = new FileExtensionGroup("PowerPoint Files", ".pptx");

	public static FileExtensionGroup PDFExtensions { get; } = new FileExtensionGroup("PDF Files", ".pdf");

	public static FileExtensionGroup Pro4DocumentExtensions { get; } = new FileExtensionGroup("ProPresenter4 Document Files", ".pro4");

	public static FileExtensionGroup Pro4DocumentBundleExtensions { get; } = new FileExtensionGroup("ProPresenter4 Document Files", ".pro4x");

	public static FileExtensionGroup AllPro4DocumentExtensions { get; } = new FileExtensionGroup("ProPresenter4 Document Files", ".pro4", ".pro4x");

	public static FileExtensionGroup Pro4PlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter4 Playlist Files", ".pro4pl");

	public static FileExtensionGroup Pro4PlaylistBundleExtensions { get; } = new FileExtensionGroup("ProPresenter4 Playlist Files", ".pro4plx");

	public static FileExtensionGroup AllPro4PlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter4 Playlist Files", ".pro4pl", ".pro4plx");

	public static FileExtensionGroup Pro4TemplateExtensions { get; } = new FileExtensionGroup("ProPresenter4 Template Files", ".pro4Template");

	public static FileExtensionGroup Pro4TemplateBundleExtensions { get; } = new FileExtensionGroup("ProPresenter4 Template Files", ".pro4TemplateBundle");

	public static FileExtensionGroup AllPro4TemplateExtensions { get; } = new FileExtensionGroup("ProPresenter4 Template Files", ".pro4Template", ".pro4TemplateBundle");

	public static FileExtensionGroup Pro5DocumentExtensions { get; } = new FileExtensionGroup("ProPresenter5 Document Files", ".pro5");

	public static FileExtensionGroup Pro5DocumentBundleExtensions { get; } = new FileExtensionGroup("ProPresenter5 Document Files", ".pro5x");

	public static FileExtensionGroup AllPro5DocumentExtensions { get; } = new FileExtensionGroup("ProPresenter5 Document Files", ".pro5", ".pro5x");

	public static FileExtensionGroup Pro5PlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter5 Playlist Files", ".pro5pl");

	public static FileExtensionGroup Pro5PlaylistBundleExtensions { get; } = new FileExtensionGroup("ProPresenter5 Playlist Files", ".pro5plx");

	public static FileExtensionGroup AllPro5PlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter5 Playlist Files", ".pro5pl", ".pro5plx");

	public static FileExtensionGroup Pro5TemplateExtensions { get; } = new FileExtensionGroup("ProPresenter5 Template Files", ".pro5Template");

	public static FileExtensionGroup Pro5TemplateBundleExtensions { get; } = new FileExtensionGroup("ProPresenter5 Template Files", ".pro5TemplateBundle");

	public static FileExtensionGroup AllPro5TemplateExtensions { get; } = new FileExtensionGroup("ProPresenter5 Template Files", ".pro5Template", ".pro5TemplateBundle");

	public static FileExtensionGroup Pro6DocumentExtensions { get; } = new FileExtensionGroup("ProPresenter6 Document Files", ".pro6");

	public static FileExtensionGroup Pro6DocumentBundleExtensions { get; } = new FileExtensionGroup("ProPresenter6 Document Files", ".pro6x");

	public static FileExtensionGroup AllPro6DocumentExtensions { get; } = new FileExtensionGroup("ProPresenter6 Document Files", ".pro6", ".pro6x");

	public static FileExtensionGroup Pro6PlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter6 Playlist Files", ".pro6pl");

	public static FileExtensionGroup Pro6PlaylistBundleExtensions { get; } = new FileExtensionGroup("ProPresenter6 Playlist Files", ".pro6plx");

	public static FileExtensionGroup Pro6DataExtensions { get; } = new FileExtensionGroup("ProPresenter6 Data Files", ".pro6data");

	public static FileExtensionGroup AllPro6PlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter6 Playlist Files", ".pro6pl", ".pro6plx");

	public static FileExtensionGroup Pro6TemplateExtensions { get; } = new FileExtensionGroup("ProPresenter6 Template Files", ".pro6Template");

	public static FileExtensionGroup Pro6TemplateBundleExtensions { get; } = new FileExtensionGroup("ProPresenter6 Template Files", ".pro6TemplateBundle");

	public static FileExtensionGroup AllPro6TemplateExtensions { get; } = new FileExtensionGroup("ProPresenter6 Template Files", ".pro6Template", ".pro6TemplateBundle");

	public static FileExtensionGroup ProDocumentExtensions { get; } = new FileExtensionGroup("ProPresenter Presentation Files", ".pro");

	public static FileExtensionGroup ProDocumentBundleExtensions { get; } = new FileExtensionGroup("ProPresenter Presentation Files", ".proBundle");

	public static FileExtensionGroup AllProDocumentExtensions { get; } = new FileExtensionGroup("ProPresenter Presentation Files", ".pro", ".proBundle");

	public static FileExtensionGroup ProPlaylistExtensions { get; } = new FileExtensionGroup("ProPresenter Playlist Files", ".proPlaylist");

	public static FileExtensionGroup ProThemeExtensions { get; } = new FileExtensionGroup("ProPresenter Theme Files", ".proTheme");

	public static FileExtensionGroup Pro { get; } = new FileExtensionGroup("ProPresenter Theme Files", ".proTheme");

	public static FileExtensionGroup SampleContentExtensions { get; } = new FileExtensionGroup("This is a place holder extension when downloading sample content for media bin.", ".sampleContent");

	public static FileExtensionGroup ZipExtensions { get; } = new FileExtensionGroup("", ".zip");

	public static long? FileModifiedTimestamp(this FileInfo file)
	{
		if (file.Exists)
		{
			file.Refresh();
			return file.LastWriteTimeUtc.ToUnixTimestamp();
		}
		return null;
	}

	public static bool IsEmpty(this FileStream fileStream)
	{
		FileInfo fileInfo = new FileInfo(fileStream.Name);
		if (fileInfo.Length == 0L)
		{
			return true;
		}
		if (fileInfo.Length < 6)
		{
			return File.ReadAllText(fileStream.Name).Length == 0;
		}
		return false;
	}
}
