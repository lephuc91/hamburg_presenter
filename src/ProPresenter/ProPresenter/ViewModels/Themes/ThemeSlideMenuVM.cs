using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels.Themes;

namespace ProPresenter.ViewModels.Themes;

public class ThemeSlideMenuVM : LinkedNotifyPropertyChangedBase, IThemeSlideMenuVM
{
	private readonly IThemeService _themeService;

	private readonly IMessageService _messageService;

	private IEnumerable<RecentlyAppliedTemplateSlideModel> _recentlyAppliedThemes = Enumerable.Empty<RecentlyAppliedTemplateSlideModel>();

	private bool _mediaActionEnabled;

	private ThemePickerSettingsModel? _themeSettings;

	public IThemeCollection Themes => _themeService.Themes;

	public ThemeContainer? ThemeTree => _themeService.Themes.ThemeTree;

	public ObservableCollection<Theme> RecentThemes { get; private set; }

	public bool MediaActionEnabled
	{
		get
		{
			return _mediaActionEnabled;
		}
		set
		{
			SetValue("MediaActionEnabled", ref _mediaActionEnabled, value, (Action)delegate
			{
				UpdateThemeSettingsAsync().ExecuteAsync();
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	public ICommand FetchRecentlyAppliedThemeDataCommand => new AsyncRelayCommand(FetchDataExecutedAsync);

	public ICommand FetchMediaActionEnabledCommand => new AsyncRelayCommand<ThemePickerGroup>(FetchMediaActionEnabledCommandExecutedAsync);

	public ThemeSlideMenuVM(IThemeService themeService, IMessageService messageService)
	{
		_themeService = themeService;
		_messageService = messageService;
		RecentThemes = new ObservableCollection<Theme>();
		LinkProperties("ThemeTree", "ThemeTree");
		_themeService.Themes.PropertyChanged += base.RaiseLinkedValues;
	}

	private async Task FetchDataExecutedAsync()
	{
		_recentlyAppliedThemes = await _themeService.GetRecentlyAppliedTemplateSlidesAsync(orderbyDate: true, 20);
		await LoadRecentThemes();
	}

	private async Task FetchMediaActionEnabledCommandExecutedAsync(ThemePickerGroup contextGroup)
	{
		MediaActionEnabled = (_themeSettings = await _themeService.GetThemePickerSettingsByGroupAsync(contextGroup))?.MediaActionEnabled ?? false;
	}

	private async Task UpdateThemeSettingsAsync()
	{
		if (_themeSettings != null)
		{
			_themeSettings.MediaActionEnabled = MediaActionEnabled;
			await _themeService.UpsertThemePickerSettingsAsync(_themeSettings);
			_messageService.PublishMessage(new ThemePickerSettingsUpdatedMessage(_themeSettings));
		}
	}

	private async Task LoadRecentThemes()
	{
		RecentThemes.Clear();
		foreach (RecentlyAppliedTemplateSlideModel recentlyAppliedTheme in _recentlyAppliedThemes)
		{
			if (RecentThemes.Count < 2)
			{
				ThemeTree.ThrowWhenNull("ThemeTree");
				Theme theme = await _themeService.FindThemeByTemplateSlideIdAsync(ThemeTree.Children, recentlyAppliedTheme.TemplateSlideId);
				if (theme != null && !RecentThemes.Contains(theme))
				{
					RecentThemes.Add(theme);
				}
				continue;
			}
			break;
		}
	}
}
