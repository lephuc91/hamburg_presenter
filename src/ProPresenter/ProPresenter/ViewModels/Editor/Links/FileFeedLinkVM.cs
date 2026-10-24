using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Win32;
using Pro.Common.Components.Reversibility;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Editor;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.SlideEditor.Inspectors.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class FileFeedLinkVM : LinkedTextObjectVMBase, IFileFeedLinkVM, INotifyPropertyChanged
{
	private readonly Lazy<PreviewFile> _preview;

	public RelativePath SourceFile
	{
		get
		{
			return FileFeedLinkedObject?.SourceFile ?? new RelativePath();
		}
		set
		{
			UpdateSourceFile(value);
		}
	}

	public ICommand OpenFileLocationCommand => new RelayCommand(OnOpenFileLocationCommand, () => SourceFile?.IsValid ?? false);

	public ICommand AddFileSourceCommand => new RelayCommand(OnAddFileSourceCommand);

	public ICommand OpenFileCommand => new RelayCommand(OnOpenFileCommand, () => SourceFile?.IsValid ?? false);

	private FileFeedLinkedObject? FileFeedLinkedObject => base.LinkedTextObject as FileFeedLinkedObject;

	private string FileFeedText
	{
		get
		{
			if (FileFeedLinkedObject == null)
			{
				return string.Empty;
			}
			return FileFeedLinkedObject.GetFileText();
		}
	}

	public FileFeedLinkVM(ObservableCollection<ICanvasElement> selectedElements)
		: base(selectedElements)
	{
		_preview = new Lazy<PreviewFile>(() => new PreviewFile());
	}

	protected override void NotifyPropertyChanges()
	{
		OnPropertyChanged("SourceFile");
	}

	private void UpdateSourceFile(RelativePath sourceFile)
	{
		base.UndoStack?.BeginCommit(UndoActionTypes.TickerSourceFilePath.ToAction());
		foreach (TextLink textLink in base.TextLinks)
		{
			if (textLink.LinkedObject is FileFeedLinkedObject fileFeedLinkedObject)
			{
				fileFeedLinkedObject.SourceFile = sourceFile;
				continue;
			}
			textLink.LinkedObject = new FileFeedLinkedObject
			{
				SourceFile = sourceFile
			};
		}
		base.UndoStack?.EndCommit(null, delegate
		{
			OnPropertyChanged("SourceFile");
		}, autoFinalize: true);
		OnPropertyChanged("SourceFile");
	}

	private void OnOpenFileLocationCommand()
	{
		RelativePath sourceFile = SourceFile;
		if ((object)sourceFile != null && sourceFile.IsValid)
		{
			ProcessHelper.ShowFileInExplorer(SourceFile);
		}
	}

	private void OnAddFileSourceCommand()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = FileFilters.AllTextFilter
		};
		if (openFileDialog.ShowDialog() == true)
		{
			SourceFile = (RelativePath)openFileDialog.FileName;
		}
	}

	private void OnOpenFileCommand()
	{
		RelativePath sourceFile = SourceFile;
		if ((object)sourceFile != null && sourceFile.IsValid)
		{
			try
			{
				_preview.Value.ViewContent(SourceFile.Filename, FileFeedText);
				return;
			}
			catch
			{
				MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("EDITOR_PRESENTATION_TEXT_INSPECTOR_LINKED_FILE_OPEN_ERROR_message", new object[1] { SourceFile?.Name ?? string.Empty }), DefaultButtons.OK, DefaultButtons.OK);
				return;
			}
		}
		MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("EDITOR_PRESENTATION_TEXT_INSPECTOR_LINKED_FILE_DELETED_ERROR_message", new object[1] { SourceFile?.Name ?? string.Empty }), DefaultButtons.OK, DefaultButtons.OK);
	}
}
