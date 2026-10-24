namespace Pro.Common.FileSystem;

public interface IFileFilterProvider
{
	string AudioFilter { get; }

	string AudioOnlyFilter { get; }

	string ImageFilter { get; }

	string ImageOnlyFilter { get; }

	string VideoFilter { get; }

	string VideoOnlyFilter { get; }

	string VisualFilter { get; }

	string VisualOnlyFilter { get; }

	string TextFilter { get; }

	string AllTextFilter { get; }

	string AllPowerPointFilter { get; }

	string PDFFilter { get; }

	string ChordChartFileFilter { get; }

	string ProPresentationFilter { get; }

	string ProPresentationBundleFilter { get; }

	string ProPlaylistFilter { get; }

	string ProThemeFilter { get; }

	string MediaFileFilter { get; }

	string ImportableFileFilter { get; }

	string CustomizeFilextension(FileExtensionGroup group, bool allowAllTypes, params string[] extensions);
}
