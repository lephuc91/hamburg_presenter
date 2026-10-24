using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public class SettingsSearchResultItemVM : ObservableObject, ISettingsSearchResultItemVM
{
	private readonly ISettingsSearchPageField _field;

	public string Name => _field.Value;

	public ISettingsItemVM Item => _field.Page;

	public Brush? Background
	{
		get
		{
			if (!_field.IsComponent)
			{
				return _field.Page.Background;
			}
			return null;
		}
	}

	public ImageSource? Icon
	{
		get
		{
			if (!_field.IsComponent)
			{
				return _field.Page.Icon;
			}
			return null;
		}
	}

	public Thickness NameIndent
	{
		get
		{
			if (!(Item is IRegistrationMainPageVM) || !_field.IsComponent)
			{
				return new Thickness(8.0, 0.0, 0.0, 0.0);
			}
			return new Thickness(18.0, 0.0, 0.0, 0.0);
		}
	}

	public bool IsRegistration
	{
		get
		{
			if (Item is IRegistrationMainPageVM)
			{
				return !_field.IsComponent;
			}
			return false;
		}
	}

	public SettingsSearchResultItemVM(ISettingsSearchPageField field)
	{
		_field = field;
	}
}
