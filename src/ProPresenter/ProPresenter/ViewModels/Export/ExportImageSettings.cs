using ProPresenter.DO.Export;

namespace ProPresenter.ViewModels.Export;

internal class ExportImageSettings : IExportImageSettings
{
	public ImageExportExtension ImageExportExtension { get; }

	public string Directory { get; }

	public string ExportName { get; }

	public bool IncludeMedia { get; }

	public ExportImageSettings(ImageExportExtension imageExportExtension, string directory, string exportName, bool includeMedia)
	{
		ImageExportExtension = imageExportExtension;
		Directory = directory;
		ExportName = exportName;
		IncludeMedia = includeMedia;
	}
}
