using Pro.UI.Components;

namespace Pro.UI.Utility;

public class FileSelectorService : IFileSelectorService
{
	public bool SaveFile(string fileFilter, string filename, string initialDirectory, out string selectedFilename)
	{
		return DialogHelper.SaveFile(fileFilter, filename, out selectedFilename, initialDirectory);
	}

	public bool SelectFile(out string selectedFile, string filter)
	{
		return DialogHelper.SelectFile(out selectedFile, filter);
	}

	public bool SelectFolderPath(out string selectedPath)
	{
		return DialogHelper.SelectFolderPath(out selectedPath);
	}

	public bool ShowDialog<T>(T content, string? title, IDialogPositionProvider? positionProvider = null) where T : IDialogContent
	{
		return DialogHelper.ShowDialog(content, title, positionProvider);
	}
}
