using System.Windows;
using Microsoft.Win32;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;

namespace Pro.UI.Utility;

public static class DialogHelper
{
	public static bool ShowDialog<T>(T content, string? title, IDialogPositionProvider? positionProvider = null) where T : IDialogContent
	{
		PositionableWindow dialog = new PositionableWindow
		{
			Title = (title ?? " "),
			Content = content,
			Owner = Application.Current.MainWindow,
			WindowStartupLocation = WindowStartupLocation.CenterOwner
		};
		if (positionProvider != null)
		{
			dialog.IsPositionSaved = positionProvider.IsPositionSaved;
			dialog.LastWindowState = positionProvider.LastWindowState;
			dialog.LastWindowRect = positionProvider.LastWindowRect;
			dialog.WindowDimensionsChanged += delegate
			{
				positionProvider.IsPositionSaved = dialog.IsPositionSaved;
				positionProvider.LastWindowState = dialog.LastWindowState;
				positionProvider.LastWindowRect = dialog.LastWindowRect;
			};
		}
		dialog.SizeChanged += delegate
		{
			if (content is FrameworkElement frameworkElement)
			{
				dialog.MinWidth = dialog.ActualWidth - frameworkElement.ActualWidth + frameworkElement.MinWidth;
				dialog.MaxWidth = dialog.ActualWidth - frameworkElement.ActualWidth + frameworkElement.MaxWidth;
				dialog.MinHeight = dialog.ActualHeight - frameworkElement.ActualHeight + frameworkElement.MinHeight;
				dialog.MaxHeight = dialog.ActualHeight - frameworkElement.ActualHeight + frameworkElement.MaxHeight;
			}
		};
		ref T reference = ref content;
		T val = default(T);
		if (val == null)
		{
			val = reference;
			reference = ref val;
		}
		reference.Accept += delegate
		{
			dialog.DialogResult = true;
			dialog.Close();
		};
		ref T reference2 = ref content;
		val = default(T);
		if (val == null)
		{
			val = reference2;
			reference2 = ref val;
		}
		reference2.Cancel += delegate
		{
			dialog.DialogResult = false;
			dialog.Close();
		};
		return dialog.ShowDialog() == true;
	}

	public static bool SelectFolderPath(out string selectedPath)
	{
		selectedPath = string.Empty;
		OpenFolderDialog openFolderDialog = new OpenFolderDialog
		{
			Title = LocalizedStrings.Get("SYNC_PREFERENCES_FOLDER_SELECTION_DIALOG_title"),
			Multiselect = false
		};
		if (openFolderDialog.ShowDialog() == true)
		{
			selectedPath = openFolderDialog.FolderName;
			return true;
		}
		return false;
	}

	public static bool SelectFile(out string selectedFile, string filter)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = filter
		};
		bool valueOrDefault = openFileDialog.ShowDialog() == true;
		selectedFile = (valueOrDefault ? openFileDialog.FileName : string.Empty);
		return valueOrDefault;
	}

	public static bool SaveFile(string fileFilter, string filename, out string selectedFilename, string initialDirectory = "")
	{
		selectedFilename = string.Empty;
		SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Filter = fileFilter,
			FileName = filename,
			InitialDirectory = initialDirectory
		};
		if (saveFileDialog.ShowDialog() == true && !string.IsNullOrEmpty(saveFileDialog.FileName))
		{
			selectedFilename = saveFileDialog.FileName;
			return true;
		}
		return false;
	}
}
