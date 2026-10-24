namespace ProPresenter.DO.Export;

public interface IExportImageSettings
{
	ImageExportExtension ImageExportExtension { get; }

	string Directory { get; }

	string ExportName { get; }

	bool IncludeMedia { get; }
}
