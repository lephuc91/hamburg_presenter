using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.DO.Cues;
using ProPresenter.DO.SongSelect;

namespace ProPresenter.ViewModels.QuickSearch;

public interface ISongSelectSearchService : INotifyPropertyChanged
{
	IEnumerable<ISongSelectSearchResult> Items { get; }

	bool IsAuthorized { get; }

	void CheckAvailability();

	void Search(string searchText, Action completedCallback);

	void Import(ISongSelectSearchResult selectedItem);

	void ImportAndLinkToItem(ProPresenterCue target, ISongSelectSearchResult selectedItem);
}
