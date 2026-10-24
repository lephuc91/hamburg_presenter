using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.DO.Cues;

namespace ProPresenter.ViewModels.QuickSearch;

public interface ILibrarySearchService : INotifyPropertyChanged
{
	IEnumerable<DocumentCue> Items { get; }

	bool PlaylistAvailable { get; }

	void Open(DocumentCue documentCue);

	void Search(string searchText, Action completedCallback);

	void AddToPlaylist(IEnumerable<DocumentCue> documentCues);

	void LinkToItem(ProPresenterCue? target, DocumentCue documentCue);
}
