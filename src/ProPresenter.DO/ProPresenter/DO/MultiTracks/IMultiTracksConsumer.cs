using System;
using Pro.Common.Mathematics;
using Pro.Common.OAuth;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.MultiTracks;

public interface IMultiTracksConsumer : IConsumer
{
	event Action SubscriptionAuthorizationUpdated;

	event Action AuthorizationStateUpdated;

	string BeginAuthorization();

	bool TryCompleteAuthorization(string url);

	void GetAccountInfo(Action<MultiTracksAccountInfo?> completedCallback);

	void GetImportedSong(MultiTracksSearchResult searchResult, int linesPerSlide, TemplateSlide templateSlide, Vector2<double> documentSize, string presentationName, Action<PresentationBase> completedCallback, Action<string>? errorCallback);

	void GetImportedSong(MultiTracksSearchResult searchResult, Key baseKey, int linesPerSlide, TemplateSlide templateSlide, Vector2<double> documentSize, string presentationName, Action<PresentationBase> completedCallback, Action<string>? errorCallback);

	void GetSearchResults(string searchTerms, Action<MultiTracksSearchResults> completedCallback, Action<string> errorCallback, int pageNumber = 1, int pageSize = 15);

	void RefreshAuthorization(MultiTracksPresentation presentation, bool consumeCredit, Action<MultiTracksPresentation>? completedCallback = null, Action<string>? errorCallback = null);
}
