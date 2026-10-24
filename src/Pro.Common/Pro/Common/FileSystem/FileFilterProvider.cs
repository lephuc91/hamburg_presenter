namespace Pro.Common.FileSystem;

public class FileFilterProvider : IFileFilterProvider
{
	public string AudioFilter => FileFilters.AudioFilter;

	public string AudioOnlyFilter => FileFilters.AudioOnlyFilter;

	public string ImageFilter => FileFilters.ImageFilter;

	public string ImageOnlyFilter => FileFilters.ImageOnlyFilter;

	public string VideoFilter => FileFilters.VideoFilter;

	public string VideoOnlyFilter => FileFilters.VideoOnlyFilter;

	public string VisualFilter => FileFilters.VisualFilter;

	public string VisualOnlyFilter => FileFilters.VisualOnlyFilter;

	public string TextFilter => FileFilters.TextFilter;

	public string AllTextFilter => FileFilters.AllTextFilter;

	public string AllPowerPointFilter => FileFilters.AllPowerPointFilter;

	public string PDFFilter => FileFilters.PDFFilter;

	public string ChordChartFileFilter => FileFilters.ChordChartFileFilter;

	public string ProPresentationFilter => FileFilters.ProPresentationFilter;

	public string ProPresentationBundleFilter => FileFilters.ProPresentationBundleFilter;

	public string ProPlaylistFilter => FileFilters.ProPlaylistFilter;

	public string ProThemeFilter => FileFilters.ProThemeFilter;

	public string MediaFileFilter => FileFilters.MediaFileFilter;

	public string ImportableFileFilter => FileFilters.ImportableFileFilter;

	public string CustomizeFilextension(FileExtensionGroup group, bool allowAllTypes, params string[] extensions)
	{
		FileExtensionGroup fileExtensionGroup = group.Customize(extensions);
		return FileExtensionGroupHelper.GenerateFilterGroup(allowAllTypes, fileExtensionGroup);
	}
}
