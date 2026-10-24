using System.Collections.Generic;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public interface ISettingsSearchEngine
{
	IEnumerable<ISettingsSearchPageField> Search(string searchTerm);

	void IndexPages(IEnumerable<ISettingsSearchPage> pages);
}
