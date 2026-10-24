using System;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public record PageSearchField(string Value, ISettingsItemVM Page, bool IsComponent = false, ISettingsSearchPageField? LinkedField = null) : ISettingsSearchPageField
{
	public Guid ID { get; } = Guid.NewGuid();
}
