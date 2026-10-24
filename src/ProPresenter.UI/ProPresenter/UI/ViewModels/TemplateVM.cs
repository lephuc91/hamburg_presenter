using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.IO;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.Strings;
using Pro.DO.Storage;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Export;
using ProPresenter.DO.Media;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public class TemplateVM : LinkedNotifyPropertyChangedBase, ITemplateVM, INotifyPropertyChanged
{
	private readonly ISlideSelectorStrategy _slideSelectorStrategy;

	private readonly IThemePrompt _themePrompt;

	private readonly Stack<IThemeContainer> _navigationStack = new Stack<IThemeContainer>();

	private readonly IThemeService _themeService;

	private readonly IMessageService _messageService;

	private readonly IExportProcessFactory _exportProcessFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IFlagService _flagService;

	private IEnumerable<RecentlyAppliedTemplateSlideModel> _recentlyAppliedThemes = Enumerable.Empty<RecentlyAppliedTemplateSlideModel>();

	private IThemeContainer? _targetTheme;

	private ThemePickerSettingsModel? _pickerSettings;

	public ThemePickerGroup ContextGroup { get; set; }

	public bool HasUnacknowledgedImportedThemes { get; set; }

	public Theme DefaultTheme => Themes.DefaultTheme;

	public ThemeCollection Themes { get; }

	public ObservableCollection<Theme> RecentThemes { get; } = new ObservableCollection<Theme>();

	public IThemeContainer? ThemeTree => Themes.ThemeTree;

	public IEnumerable<IThemeContainer> RootThemes
	{
		get
		{
			IEnumerable<IThemeContainer> enumerable = ThemeTree?.Children.Where((ThemeContainer t) => t.Children.Empty());
			return enumerable ?? Enumerable.Empty<IThemeContainer>();
		}
	}

	public ViewType ViewType
	{
		get
		{
			return _themeService.GetViewTypeByGroup(ContextGroup);
		}
		private set
		{
			_themeService.SetViewTypeByGroup(ContextGroup, value);
		}
	}

	public IThemeContainer? CurrentThemeContainer
	{
		get
		{
			return _themeService.GetCurrentThemeContainerByGroup(ContextGroup);
		}
		[param: DisallowNull]
		private set
		{
			_themeService.SetCurrentThemeContainerGroupContext(ContextGroup, value);
		}
	}

	public ICommand ToggleMediaActionCommand => new RelayCommand(delegate
	{
		if (PickerSettings != null)
		{
			PickerSettings.MediaActionEnabled = !PickerSettings.MediaActionEnabled;
			OnPropertyChanged("MediaActionEnabled");
		}
	});

	public ICommand NewThemeCommand => new RelayCommand(delegate
	{
		PromptSave(SaveNewThemeCommand);
	});

	public ICommand<Theme> DeleteThemeCommand => new RelayCommand<Theme>(OnDeleteThemeCommand);

	public ICommand<TemplateSlide> DeleteTemplateSlideCommand => new RelayCommand<TemplateSlide>(OnDeleteTemplateSlide);

	public ICommand<Theme> EditThemeCommand => new RelayCommand<Theme>(delegate(Theme g)
	{
		if (g == null && _themeService.Themes.Count == 0)
		{
			PromptSave(new RelayCommand<string>(delegate(string name)
			{
				SaveNewTheme(name);
				ExecuteEditTheme(g);
			}));
		}
		else
		{
			ExecuteEditTheme(g);
		}
	});

	public ICommand ExportThemeCommand => new RelayCommand(OnExportThemeCommand, () => Themes.Any());

	public ICommand AddSelectionToNewThemeCommand => new RelayCommand(delegate
	{
		PromptSave(SaveSlidesToNewThemeCommand);
	});

	public ICommand<Theme> AddSelectionToThemeCommand => new RelayCommand<Theme>(OnAddSelectionToThemeCommand, (Theme t) => t != null);

	private ICommand<string> SaveNewThemeCommand => new RelayCommand<string>(delegate(string n)
	{
		SaveNewTheme(n);
	}, CanSaveNewTheme);

	private ICommand<string> SaveSlidesToNewThemeCommand => new RelayCommand<string>(delegate(string n)
	{
		SaveNewTheme(n, _slideSelectorStrategy.GetSelectedSlideCues());
	}, CanSaveNewTheme);

	public ICommand FetchRecentlyAppliedThemeDataCommand => new AsyncRelayCommand(FetchRecentlyAppliedThemeDataExecutedAsync);

	public ICommand<ThemePickerGroup> FetchThemePickerSettingsCommand => new AsyncRelayCommand<ThemePickerGroup>(FetchThemePickerSettingsExecutedAsync);

	public ICommand ClearRecentlyUsedThemes => new AsyncRelayCommand(ClearRecentlyUsedThemesCommandExecutedAsync);

	public ICommand<Theme> SelectThemeCommand => new AsyncRelayCommand<Theme>(SelectThemeCommandExecuteAsync, (Theme? t) => t != null);

	public ICommand GoBackCommand => new AsyncRelayCommand(GoBackCommandExecuteAsync);

	public ICommand<IThemeContainer> SelectThemeFolderCommand => new AsyncRelayCommand<IThemeContainer>(SelectThemeFolderCommandExecutedAsync, (IThemeContainer? t) => t != null);

	public ICommand ResetViewCommand => new AsyncRelayCommand(ResetViewAsync);

	public ThemePickerSettingsModel? PickerSettings
	{
		get
		{
			return _pickerSettings;
		}
		private set
		{
			SetValue("PickerSettings", ref _pickerSettings, value);
		}
	}

	public ICommand BrowseProContentThemesCommand { get; }

	public event Action<Theme?>? EditTheme;

	private void ExecuteEditTheme(Theme? theme)
	{
		this.EditTheme?.Invoke(theme);
		_messageService?.PublishMessage(new EditThemeTemplateMessage(theme, EditMode.Template));
	}

	public TemplateVM(ThemeCollection themes, ISlideSelectorStrategy slideSelectorStrategy, IThemeService themeService, IThemePrompt themePrompt, IMessageService messageService, IProContentProvider provider, IExportProcessFactory exportProcessFactory, IProPresenterDOFactoryProvider factoryProvider, IFlagService flagService)
	{
		_themeService = themeService;
		_messageService = messageService;
		_exportProcessFactory = exportProcessFactory;
		_factoryProvider = factoryProvider;
		_flagService = flagService;
		Themes = themes;
		_slideSelectorStrategy = slideSelectorStrategy;
		_themePrompt = themePrompt;
		BrowseProContentThemesCommand = provider.BrowseThemesCommand;
		LinkProperties("DefaultTheme", "DefaultTheme");
		LinkProperties("ThemeTree", new string[2] { "ThemeTree", "RootThemes" });
		LinkAction("ThemeTree", delegate
		{
			ResetViewAsync().ExecuteAsync();
		});
		Themes.PropertyChanged += OnThemesPropertyChanged;
		Themes.CollectionChanged += delegate
		{
			OnPropertyChanged("Themes");
		};
		_themeService.ThemeImported += OnNewThemeImported;
		ViewType = ViewType.Main;
		if (Themes.ThemeTree != null)
		{
			CurrentThemeContainer = Themes.ThemeTree;
		}
	}

	private void OnThemesPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName == "Name"))
		{
			RaiseLinkedValues(sender, e);
		}
	}

	private async Task UpdateThemePickerSettings()
	{
		if (PickerSettings != null)
		{
			await _themeService.UpsertThemePickerSettingsAsync(PickerSettings);
			OnPropertyChanged("MediaActionEnabled");
			PublishSettingsUpdated(PickerSettings);
		}
	}

	private async Task FetchThemePickerSettingsExecutedAsync(ThemePickerGroup group)
	{
		if (PickerSettings != null)
		{
			PickerSettings.PropertyChanged -= OnThemePickerSettingsChanged;
		}
		PickerSettings = await _themeService.GetThemePickerSettingsByGroupAsync(group);
		if (PickerSettings != null)
		{
			PickerSettings.PropertyChanged += OnThemePickerSettingsChanged;
			if (ContextGroup == ThemePickerGroup.Messages || ContextGroup == ThemePickerGroup.AudienceLook)
			{
				PickerSettings.MediaActionEnabled = false;
			}
			PublishSettingsUpdated(PickerSettings);
			OnPropertyChanged("PickerSettings");
		}
	}

	private async Task ClearRecentlyUsedThemesCommandExecutedAsync()
	{
		await _themeService.ClearRecentlyAppliedTemplateSlidesAsync();
		await FetchRecentlyAppliedThemeDataExecutedAsync();
	}

	private void OnThemePickerSettingsChanged(object? sender, PropertyChangedEventArgs e)
	{
		UpdateThemePickerSettings().ExecuteAsync();
	}

	private void PublishSettingsUpdated(ThemePickerSettingsModel model)
	{
		_messageService.PublishMessage(new ThemePickerSettingsUpdatedMessage(model));
	}

	private async Task FetchRecentlyAppliedThemeDataExecutedAsync()
	{
		_recentlyAppliedThemes = await _themeService.GetRecentlyAppliedTemplateSlidesAsync(orderbyDate: true, 20);
		await LoadRecentThemes();
		foreach (ImportedThemeModel item in await _themeService.GetAllThemesThatHaventBeenAcknowledgedAsync())
		{
			await _themeService.UpdateUserHasAcknowledgedImportedThemeAsync(item.ThemeName);
		}
		HasUnacknowledgedImportedThemes = false;
		await RefreshView();
	}

	private void OnNewThemeImported(object? sender, ThemeImportedEventArgs e)
	{
		HasUnacknowledgedImportedThemes = true;
		OnPropertyChanged("HasUnacknowledgedImportedThemes");
	}

	private async Task LoadRecentThemes()
	{
		int recentThemeCount = 3;
		RecentThemes.Clear();
		foreach (RecentlyAppliedTemplateSlideModel recentlyAppliedTheme in _recentlyAppliedThemes)
		{
			if (RecentThemes.Count < recentThemeCount)
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

	private void OnAddSelectionToThemeCommand(Theme theme)
	{
		foreach (SlideCue selectedSlideCue in _slideSelectorStrategy.GetSelectedSlideCues())
		{
			TemplateSlide templateSlide = SlideCueToTemplateSlide(selectedSlideCue);
			if (templateSlide != null)
			{
				theme.Add(templateSlide);
				CopyMediaAssetsToThemesAssets(templateSlide, theme);
			}
		}
	}

	private void AddSelectionToNewTheme(string themeName, IEnumerable<SlideCue>? slides = null)
	{
		if (themeName == null)
		{
			return;
		}
		Theme theme = Themes.FirstOrDefault((Theme t) => t.Name.Equals(themeName, StringComparison.OrdinalIgnoreCase));
		bool flag = slides?.Any() ?? false;
		if (theme != null)
		{
			theme.Clear();
			if (flag)
			{
				TemplateSlide[] array = slides.Select(SlideCueToTemplateSlide).NotNull().ToArray();
				foreach (TemplateSlide templateSlide in array)
				{
					theme.Add(templateSlide);
					CopyMediaAssetsToThemesAssets(templateSlide, theme);
				}
			}
			else
			{
				theme.Add();
			}
			theme.Name = themeName;
		}
		else
		{
			string text = null;
			if (_targetTheme != null)
			{
				text = _targetTheme.Children.FirstOrDefault()?.Theme?.Path;
				if (!string.IsNullOrEmpty(text))
				{
					text = Path.Combine(Path.GetDirectoryName(text) ?? string.Empty, themeName);
				}
			}
			if (flag)
			{
				TemplateSlide[] array2 = slides.Select(SlideCueToTemplateSlide).NotNull().ToArray();
				Themes.Add(themeName, array2, text);
				Theme theme2 = Themes.LastOrDefault();
				array2.ForEach(delegate(TemplateSlide t)
				{
					CopyMediaAssetsToThemesAssets(t, theme2);
				});
			}
			else
			{
				Themes.Add(themeName, text);
			}
		}
		OnPropertyChanged("Themes");
	}

	private void CopyMediaAssetsToThemesAssets(TemplateSlide? templateSlide, Theme? theme)
	{
		if (templateSlide == null || theme == null)
		{
			return;
		}
		string assetPath = theme.GetAssetPath();
		if (templateSlide.MediaAction?.FileMedia?.SourceFile?.IsValid != true)
		{
			return;
		}
		RelativePath sourceFile = templateSlide.MediaAction.FileMedia.SourceFile;
		string text = Path.Combine(assetPath, templateSlide.MediaAction.FileMedia.SourceFile.Filename);
		try
		{
			if ((bool)FileHelper.WaitForFileAccess(text, enforceFileExists: false, null))
			{
				File.Copy(sourceFile, text, overwrite: true);
				templateSlide.MediaAction.FileMedia.UpdateSource(userInitiated: false, new RelativePath(text));
			}
		}
		catch (Exception value)
		{
			Log.Error($"Unable to copy file - {sourceFile} to {text} with error -> {value}");
		}
	}

	private TemplateSlide? SlideCueToTemplateSlide(SlideCue cue)
	{
		if (cue.SlideAction?.Slide is CustomSlide slide)
		{
			TemplateSlide templateSlide = new TemplateSlide(_factoryProvider, slide, _flagService);
			MediaAction mediaAction = FindGraphicMediaAction(cue);
			if (mediaAction != null)
			{
				templateSlide.Actions.Add(mediaAction.Clone());
			}
			return templateSlide;
		}
		return null;
	}

	private MediaAction? FindGraphicMediaAction(SlideCue cue)
	{
		return cue.Actions.OfType<MediaAction>().FirstOrDefault((MediaAction action) => action.IsGraphicMedia && action.TriggerLayer == TriggerLayer.Background);
	}

	private void PromptSave(ICommand<string> saveCommand)
	{
		_targetTheme = CurrentThemeContainer;
		_themePrompt.SaveNewTheme(saveCommand);
		_targetTheme = null;
	}

	private bool CanSaveNewTheme(string name)
	{
		List<string> reservedWords;
		List<char> invalidCharacters;
		return IOValidation.Validate(CommonPaths.Themes, name, null, out reservedWords, out invalidCharacters).IsAnyOf(IOValidationError.None, IOValidationError.Exists);
	}

	private void SaveNewTheme(string name, IEnumerable<SlideCue>? slides = null)
	{
		if (Themes.DoesThemeExist(name))
		{
			_themePrompt.ResolveConflict(out var overwrite, out var abort);
			if (abort)
			{
				return;
			}
			if (!overwrite)
			{
				name = name.DuplicateName(Themes, (Theme t) => t.Name);
			}
		}
		AddSelectionToNewTheme(name, slides);
		_messageService.PublishMessage(new EditThemeTemplateMessage(Themes.FirstOrDefault((Theme theme) => theme.Name == name), EditMode.Template));
	}

	private void OnDeleteThemeCommand(Theme theme)
	{
		if (_themePrompt.ConfirmDelete(theme))
		{
			Themes.Remove(theme);
		}
	}

	private void OnDeleteTemplateSlide(TemplateSlide templateSlide)
	{
		if (templateSlide.ParentTheme != null && _themePrompt.ConfirmDelete(templateSlide))
		{
			templateSlide.ParentTheme.Remove(templateSlide);
		}
	}

	private void OnExportThemeCommand()
	{
		if (_themePrompt.Export(out IEnumerable<Theme> themes, out string path))
		{
			_exportProcessFactory.Create(themes, path).StartExport();
		}
	}

	private async Task SelectThemeCommandExecuteAsync(Theme? theme)
	{
		ThemeContainer themeContainer = CurrentThemeContainer?.Children.FirstOrDefault((ThemeContainer c) => c.Theme == theme);
		if (themeContainer != null)
		{
			_navigationStack.Push(CurrentThemeContainer);
			ViewType = ViewType.Detail;
			CurrentThemeContainer = themeContainer;
			await _themeService.UpdateUserHasViewedImportedThemeDetailsAsync(themeContainer.Name);
		}
		else
		{
			ThemeTree.ThrowWhenNull("ThemeTree");
			IThemeContainer themeContainer2 = await _themeService.FindThemeContainerAsync(ThemeTree.Children, theme);
			themeContainer2.ThrowWhenNull("container");
			ViewType = ViewType.Detail;
			CurrentThemeContainer = themeContainer2;
		}
		await RefreshView();
	}

	private async Task GoBackCommandExecuteAsync()
	{
		Themes.ThemeTree.ThrowWhenNull("Themes.ThemeTree");
		IThemeContainer themeContainer = Themes.ThemeTree;
		if (_navigationStack.Count > 0)
		{
			themeContainer = _navigationStack.Peek();
		}
		ViewType = ViewType.Folder;
		if (themeContainer != Themes.ThemeTree && _navigationStack.Count > 1)
		{
			themeContainer = _navigationStack.Pop();
		}
		else
		{
			ViewType = ViewType.Main;
		}
		CurrentThemeContainer = themeContainer;
		await RefreshView();
	}

	private async Task SelectThemeFolderCommandExecutedAsync(IThemeContainer? folder)
	{
		CurrentThemeContainer.ThrowWhenNull("CurrentThemeContainer");
		_navigationStack.Push(CurrentThemeContainer);
		ViewType = ViewType.Folder;
		if (folder != null)
		{
			CurrentThemeContainer = folder;
		}
		await RefreshView();
	}

	private async Task RefreshView()
	{
		await Dispatcher.CurrentDispatcher.InvokeAsync((Action)delegate
		{
			OnPropertyChanged("ViewType");
			OnPropertyChanged("CurrentThemeContainer");
			OnPropertyChanged("HasUnacknowledgedImportedThemes");
		});
	}

	private async Task ResetViewAsync()
	{
		Themes.ThemeTree.ThrowWhenNull("Themes.ThemeTree");
		ViewType = ViewType.Main;
		CurrentThemeContainer = Themes.ThemeTree;
		_navigationStack.Clear();
		_navigationStack.Push(CurrentThemeContainer);
		HasUnacknowledgedImportedThemes = await _themeService.AnyUnacknowledgedImportedThemesExistAsync();
		await RefreshView();
	}
}
