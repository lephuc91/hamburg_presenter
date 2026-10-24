using System.Collections.Generic;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public interface ISettingsSearchFactory
{
	ISettingsSearchResultItemVM Create(ISettingsSearchPageField searchResult);

	ISettingsSearchPageField CreatePageField(string value, ISettingsItemVM page);

	IEnumerable<ISettingsSearchPageField> GetFields(string key, ISettingsItemVM page, bool isComponent = false, ISettingsSearchPageField? linkedField = null);
}
