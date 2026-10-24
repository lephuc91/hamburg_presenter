using System;
using System.Collections.Generic;

namespace ProPresenter.UI.ViewModels.Settings.Search;

public interface ISettingsSearchPage
{
	Guid ID { get; }

	ISettingsSearchPageField? PageField { get; }

	IEnumerable<ISettingsSearchPageField> Fields { get; }

	IEnumerable<ISettingsSearchPage> SubPages { get; }
}
