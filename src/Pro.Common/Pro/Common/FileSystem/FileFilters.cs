namespace Pro.Common.FileSystem;

public static class FileFilters
{
	public static string AudioFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.AudioExtensions);

	public static string AudioOnlyFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(false, FileExtensions.AudioExtensions);

	public static string ImageFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ImageExtensions);

	public static string ImageOnlyFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(false, FileExtensions.ImageExtensions);

	public static string VideoFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.VideoExtensions);

	public static string VideoOnlyFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(false, FileExtensions.VideoExtensions);

	public static string VisualFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ImageExtensions, FileExtensions.VideoExtensions);

	public static string VisualOnlyFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(false, FileExtensions.ImageExtensions, FileExtensions.VideoExtensions);

	public static string TextFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.AllTextExtensions);

	public static string AllTextFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.AllTextExtensions);

	public static string AllPowerPointFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.AllPowerPointExtensions);

	public static string OpenXMLPowerPointFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.OpenXMLPowerPointExtensions);

	public static string PDFFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.PDFExtensions);

	public static string ChordChartFileFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ChordChartExtensions);

	public static string ProPresentationFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ProDocumentExtensions);

	public static string ProPresentationBundleFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ProDocumentBundleExtensions);

	public static string ProPlaylistFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ProPlaylistExtensions);

	public static string ProThemeFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.ProThemeExtensions);

	public static string MediaFileFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.AudioExtensions, FileExtensions.ImageExtensions, FileExtensions.VideoExtensions);

	public static string ImportableFileFilter { get; } = FileExtensionGroupHelper.GenerateFilterGroup(FileExtensions.AllTextExtensions, FileExtensions.ImageExtensions, FileExtensions.VideoExtensions, FileExtensions.AllWordExtensions, FileExtensions.AllPowerPointExtensions, FileExtensions.AllPro4DocumentExtensions, FileExtensions.AllPro4PlaylistExtensions, FileExtensions.AllPro4TemplateExtensions, FileExtensions.AllPro5DocumentExtensions, FileExtensions.AllPro5PlaylistExtensions, FileExtensions.AllPro5TemplateExtensions, FileExtensions.AllPro6DocumentExtensions, FileExtensions.AllPro6PlaylistExtensions, FileExtensions.AllPro6TemplateExtensions, FileExtensions.AllProDocumentExtensions, FileExtensions.ProPlaylistExtensions, FileExtensions.ProThemeExtensions);
}
