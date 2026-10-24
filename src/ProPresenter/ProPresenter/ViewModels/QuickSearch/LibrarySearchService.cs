using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Library;

namespace ProPresenter.ViewModels.QuickSearch;

public class LibrarySearchService : LinkedNotifyPropertyChangedBase, ILibrarySearchService, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly ILibraryVM _libraryVM;

	private readonly IPresentationVM _presentationVM;

	private readonly IPCOLiveVM _pcoLiveVM;

	private readonly IIndexingService _indexingService;

	private readonly ObservableCollection<DocumentCue> _items = new ObservableCollection<DocumentCue>();

	private string _searchText = string.Empty;

	private Action? _callback;

	public IEnumerable<DocumentCue> Items => _items;

	public bool PlaylistAvailable => _libraryVM.ActivePlaylist is ILibraryPlaylist<ProPresenterCue>;

	public LibrarySearchService(ICoreManager manager, ILibraryVM libraryVM, IPresentationVM presentationVM, IPCOLiveVM pcoLiveVM, IIndexingService indexingService)
	{
		_manager = manager;
		_libraryVM = libraryVM;
		_presentationVM = presentationVM;
		_pcoLiveVM = pcoLiveVM;
		_indexingService = indexingService;
		AddAllPresentations();
		_libraryVM.Libraries.LibraryCollectionChanged += delegate
		{
			UpdateItems();
		};
		_libraryVM.Libraries.CollectionChanged += delegate
		{
			UpdateItems();
		};
		_libraryVM.Libraries.PresentationNameChanged += delegate
		{
			UpdateItems();
		};
		LinkProperties("ActivePlaylist", "PlaylistAvailable");
		_libraryVM.PropertyChanged += base.RaiseLinkedValues;
	}

	private void UpdateItems()
	{
		_items.Clear();
		AddAllPresentations();
		OnPropertyChanged("Items");
	}

	public void Open(DocumentCue documentCue)
	{
		Playlist<ProPresenterCue>? activeLibraryPlaylist = _manager.ActiveLibraryPlaylist;
		if (activeLibraryPlaylist == null || !activeLibraryPlaylist.Contains(documentCue))
		{
			ILibrary? activeLibrary = _manager.ActiveLibrary;
			if (activeLibrary == null || !activeLibrary.Contains(documentCue))
			{
				_manager.ActiveLibrary = _libraryVM.Libraries.FirstOrDefault((ILibrary library) => library.Name == documentCue.LibraryName);
				_manager.ActivePlaylistItem = documentCue;
				return;
			}
		}
		_manager.ActivePlaylistItem = documentCue;
	}

	public void AddToPlaylist(IEnumerable<DocumentCue> documentCues)
	{
		_libraryVM.AddToActivePlaylist(documentCues);
	}

	public void LinkToItem(ProPresenterCue? target, DocumentCue documentCue)
	{
		if (target is PlaceholderCue)
		{
			_presentationVM.LinkDocumentCommand?.Invoke(new LinkCommandParameters(target, documentCue.DocumentAction.Presentation));
		}
		else if (target is PCOCueBase)
		{
			_pcoLiveVM.LinkDocumentCommand?.Invoke(new LinkCommandParameters(target, documentCue.DocumentAction.Presentation));
		}
	}

	public void Search(string searchText, Action completedCallback)
	{
		string searchText2 = searchText;
		_searchText = searchText2;
		_callback = completedCallback;
		_items.Clear();
		if (!string.IsNullOrWhiteSpace(_searchText))
		{
			IEnumerable<DocumentCue> enumerable = _libraryVM.Libraries.SelectMany((ILibrary l) => l);
			if (_indexingService.IsIndexing)
			{
				_items.AddRange(enumerable.Where((DocumentCue l) => l.Name.ToLower().Contains(_searchText.ToLower())));
			}
			else
			{
				AddSearchResults(_libraryVM.Libraries.Search(_searchText, enumerable));
			}
			_callback?.Invoke();
			searchText2 = string.Empty;
			_searchText = searchText2;
			_callback = null;
		}
		else
		{
			AddAllPresentations();
		}
	}

	private void AddAllPresentations()
	{
		_items.AddRange(_libraryVM.Libraries.SelectMany((ILibrary l) => l).ToArray());
	}

	private void AddSearchResults(IEnumerable<DocumentCue> items)
	{
		_items.AddRange(items);
	}
}
