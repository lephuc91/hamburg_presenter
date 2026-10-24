using System.IO;
using System.Windows;
using Pro.Common.FileSystem;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.DO.Export;

public static class ExportHelper
{
	private static readonly string TempExportDirectory;

	static ExportHelper()
	{
		TempExportDirectory = Path.Combine(CommonPaths.Temp, "Export");
		FileHelper.DeleteDirectory(TempExportDirectory);
		Directory.CreateDirectory(TempExportDirectory);
	}

	public static string GetTempFile(string extension)
	{
		return FileHelper.GetTempFile(TempExportDirectory, extension);
	}

	public static string GetTempDirectory()
	{
		return FileHelper.GetTempDirectory(TempExportDirectory);
	}

	public static (ConflictResolveResult result, bool applyToAll) ResolveConflict(string name, string folder)
	{
		ConflictResolveResult item = ConflictResolveResult.NewVersion;
		CheckboxDialogContent checkboxDialogContent = new CheckboxDialogContent();
		checkboxDialogContent.Message = LocalizedStrings.Get("FILE_CONFLICT_label", new object[1] { Path.Combine(folder, name) });
		checkboxDialogContent.CheckboxText = LocalizedStrings.Get("FILE_CONFLICT_APPLY_TO_ALL_title");
		CheckboxDialogContent checkboxDialogContent2 = checkboxDialogContent;
		FileExistsResult buttons = FileExistsResult.AddNewVersion | FileExistsResult.WriteOver | FileExistsResult.Cancel;
		FileExistsResult? fileExistsResult = MessageDialogService.ShowDialog(LocalizedStrings.Get("FILE_CONFLICT_title"), (DependencyObject)(object)checkboxDialogContent2, buttons, FileExistsResult.WriteOver);
		bool @checked = checkboxDialogContent2.Checked;
		if (fileExistsResult.HasValue)
		{
			switch (fileExistsResult.Value)
			{
			case FileExistsResult.AddNewVersion:
				item = ConflictResolveResult.NewVersion;
				break;
			case FileExistsResult.WriteOver:
				item = ConflictResolveResult.Overwrite;
				break;
			}
		}
		else
		{
			item = ConflictResolveResult.Abort;
		}
		return (result: item, applyToAll: @checked);
	}
}
