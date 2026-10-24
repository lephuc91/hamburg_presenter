using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import.Results;

public class MemoryImportResult : IImportResult
{
	private readonly PresentationBase? _presentation;

	public MemoryImportResult(PresentationBase? presentation)
	{
		_presentation = presentation;
	}

	public string GetTargetFilename(IImportRequest request)
	{
		RelativePath relativePath = _presentation?.SourceFile;
		if ((object)relativePath == null)
		{
			return string.Empty;
		}
		return relativePath;
	}

	public void CompleteImport(IImportProcess process, IImportRequest request, string name, bool overwrite, IUiDispatcher dispatcher, string containerId)
	{
		ILibrary library = process.SelectedLibrary;
		if (library == null || _presentation == null)
		{
			return;
		}
		_presentation.Name = name.SanitizeFilename();
		_presentation.UndoStack.Clear();
		dispatcher?.Invoke(delegate
		{
			if (overwrite && library.DoesPresentationExist(_presentation.Name))
			{
				library.Remove(LibraryCollection.FindDocument(library, _presentation.Name));
			}
			DocumentCue documentCue = library.Add(_presentation, userInitiated: true);
			if (process.SelectedPlaylist != null)
			{
				ImportPrompt.AddToPlaylist(documentCue, process.SelectedPlaylist);
			}
		});
	}
}
