using System;

namespace ProPresenter.UI.ViewModels.Settings.Search;

public interface ISettingsSearchPageField
{
	Guid ID { get; }

	string Value { get; }

	ISettingsItemVM Page { get; }

	bool IsComponent { get; }

	ISettingsSearchPageField? LinkedField { get; }
}
