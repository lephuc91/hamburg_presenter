using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Components;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages;

public abstract class ChildPageSettingsVMBase : LinkedNotifyPropertyChangedBase, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private ISettingsItemVM? _parent;

	public Guid ID { get; } = Guid.NewGuid();

	public virtual IEnumerable<ISettingsSearchPageField> Fields { get; } = Enumerable.Empty<ISettingsSearchPageField>();

	public virtual ISettingsSearchPageField? PageField { get; }

	public virtual IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public abstract string Name { get; }

	public ISettingsItemVM? Parent => _parent;

	public Brush Background => SettingsListItemConstants.Gray;

	public virtual ImageSource? Icon { get; }

	public virtual bool IsNavigable => true;

	public bool CanExit => true;

	public void SetParent(ISettingsItemVM parent)
	{
		_parent = parent;
	}

	public virtual void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
