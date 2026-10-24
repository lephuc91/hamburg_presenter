using System;
using ProPresenter.DO.Cues;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.QuickSearch;

public interface IMultiTracksSearchService
{
	bool IsAuthorized { get; }

	IMultiTracksConsumer Consumer { get; }

	event Action RefreshSearchResults;

	void TryLogin();

	void ToggleAuthorization();

	void Search(string searchText, Action<MultiTracksSearchResults> completedCallback);

	void Import(MultiTracksSearchResult searchResult);

	void ImportAndLinkToItem(ProPresenterCue target, MultiTracksSearchResult searchResult);

	void RetryAuthorization(MultiTracksPresentation presentation);
}
