using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.Entity;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public interface ILibrary : IImmutableObservableCollection<DocumentCue>, IReadOnlyList<DocumentCue>, IEnumerable<DocumentCue>, IEnumerable, IReadOnlyCollection<DocumentCue>, INotifyEnumerableChanged<DocumentCue>, INotifyCollectionChanged, IDragDropCollection<ProPresenterCue>, ICutPasteCollection<ProPresenterCue>, ICutCollection<ProPresenterCue>, IIdentifiable, INotifyPropertyChanged
{
	RelativePath Location { get; }

	UndoStack? UndoStack { get; set; }

	IList<DocumentCue> SortedItems { get; }

	event Action<Cue>? CueUpdated;

	event Action<ILibrary, DocumentCue>? PresentationRemovedBySync;

	void Add(DocumentCue cue, bool userInitiated);

	void Add(IEnumerable<DocumentCue> cues, bool userInitiated);

	DocumentCue Add(ProPresenter.DO.Presentation.IPresentation presentation, bool userInitiated);

	ObjectBinder<Library, Pro.Entity.ILibrary> Bind(Pro.Entity.ILibrary entity);

	void CommitAllInWriteQueue();

	bool DoesPresentationExist(string? name);

	IPresentationLoadData? GetPresentationLoadData(ProPresenter.DO.Presentation.IPresentation presentation);

	void Remove(IEnumerable<DocumentCue?> cues);

	void Remove(DocumentCue? cue);

	void SanitizeMediaFillMediaIDs();
}
