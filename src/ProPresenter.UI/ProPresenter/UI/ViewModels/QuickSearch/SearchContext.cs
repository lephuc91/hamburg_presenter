using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.QuickSearch;

public class SearchContext
{
	public enum SearchMode
	{
		Standard,
		Linking
	}

	public SearchMode Mode { get; }

	public ProPresenterCue? Target { get; }

	public SearchContext(ProPresenterCue? target = null)
	{
		Mode = ((target != null) ? SearchMode.Linking : SearchMode.Standard);
		Target = target;
	}
}
