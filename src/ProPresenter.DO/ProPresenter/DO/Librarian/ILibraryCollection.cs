using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Storage;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Librarian;

public interface ILibraryCollection : IReadOnlyCollection<ILibrary>, IEnumerable<ILibrary>, IEnumerable, INotifyEnumerableChanged<ILibrary>, INotifyCollectionChanged, INotifyPropertyChanged, IDocumentProvider
{
	bool IsLibraryOperationInProgress { get; }

	UndoStack UndoStack { get; }

	event Action<ILibrary, NotifyCollectionChangedEventArgs> LibraryCollectionChanged;

	event Action<ILibrary> LibraryNameChanged;

	event Action<string> LocationChanged;

	event Action<IPresentation> PresentationNameChanged;

	ILibrary Add(string name);

	void CommitAllInWriteQueue();

	DocumentCue? FindDocument(RelativePath? path);

	DocumentCue? FindDocument(RelativePath? path, out ILibrary? library);

	DocumentCue? FindDocument(string libraryName, string cueName, out ILibrary? library);

	ILibrary? FindLibrary(string libraryName);

	int IndexOf(IDocumentCue item);

	void MoveTo(ILibrary targetLibrary, IEnumerable<DocumentCue> cues, ref bool overwrite, ref bool isCopying);

	void MoveTo(ILibrary? sourceLibrary, ILibrary targetLibrary, IEnumerable<DocumentCue> cues, ref bool overwrite, ref bool isCopying);

	void Remove(ILibrary library, bool moveToRecycleBin = true);

	void ResolveDirectories();

	IEnumerable<DocumentCue> Search(string term, IEnumerable<DocumentCue> libraries);
}
