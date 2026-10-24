using Pro.UI.Components;

namespace Pro.UI.Utility;

public interface IFileSelectorService
{
	bool ShowDialog<T>(T content, string? title, IDialogPositionProvider? positionProvider = null) where T : IDialogContent;

	bool SelectFolderPath(out string selectedPath);

	bool SelectFile(out string selectedFile, string filter);

	bool SaveFile(string fileFilter, string filename, string initialDirectory, out string selectedFilename);
}
