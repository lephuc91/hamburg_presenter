using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.Controller;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Devices;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Pages.Import;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration;
using ProPresenter.UI.ViewModels.Settings.Pages.Screens;
using ProPresenter.UI.ViewModels.Settings.Pages.Sync;
using ProPresenter.UI.ViewModels.Settings.Pages.Updates;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings;

public class SettingsVM : ObservableObject, ISettingsVM, INotifyPropertyChanged
{
	private bool _ignoreActivePageChanged;

	private readonly ICoreManager _coreManager;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("ActiveItem", "OnSearchResultSelected")]
	private readonly ISettingsSearchVM _searchVM;

	[ObservableProperty]
	private ISettingsListItem? _selectedItem;

	[ObservableProperty]
	private ISettingsListItem? _activeItem;

	[ObservableProperty]
	private ISettingsItemVM? _activePage;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ISettingsItemVM>? selectActivePageCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<CreateRenderViewParameters>? loadPreviewCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<DestroyRenderViewParameters>? unloadPreviewCommand;

	public ISettingsNavigationVM NavigationVM { get; }

	public IEnumerable<ISettingsListItem> Items { get; }

	public ISettingsSearchVM SearchVM => _searchVM;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ISettingsListItem? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			if (!EqualityComparer<ISettingsListItem>.Default.Equals(_selectedItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedItem);
				_selectedItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ISettingsListItem? ActiveItem
	{
		get
		{
			return _activeItem;
		}
		set
		{
			if (!EqualityComparer<ISettingsListItem>.Default.Equals(_activeItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ActiveItem);
				_activeItem = value;
				OnActiveItemChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ActiveItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ISettingsItemVM? ActivePage
	{
		get
		{
			return _activePage;
		}
		set
		{
			if (!EqualityComparer<ISettingsItemVM>.Default.Equals(_activePage, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ActivePage);
				_activePage = value;
				OnActivePageChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ActivePage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ISettingsItemVM> SelectActivePageCommand => selectActivePageCommand ?? (selectActivePageCommand = new RelayCommand<ISettingsItemVM>(SelectActivePage));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<CreateRenderViewParameters> LoadPreviewCommand => loadPreviewCommand ?? (loadPreviewCommand = new RelayCommand<CreateRenderViewParameters>(LoadPreview));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<DestroyRenderViewParameters> UnloadPreviewCommand => unloadPreviewCommand ?? (unloadPreviewCommand = new RelayCommand<DestroyRenderViewParameters>(UnloadPreview));

	public SettingsVM(IEnumerable<ISettingsListItem> items, ISettingsSearchVM searchVM, ISettingsNavigationVM navigationVM, ICoreManager coreManager, IMessageService messageService)
	{
		Items = items;
		_searchVM = searchVM;
		NavigationVM = navigationVM;
		_coreManager = coreManager;
		ActiveItem = items.FirstOrDefault((ISettingsListItem i) => i is ISettingsItemVM);
		NavigationVM.NavigateItem += NavigationVM_Navigate;
		messageService.SubscribeToMessage<MainWindowContentRenderedMessage>(delegate
		{
			LoadPreviewCommand.Execute(new CreateRenderViewParameters(RenderViewType.InputPreferenceTab, IntPtr.Zero));
		});
		messageService.SubscribeToMessage<MainWindowClosingMessage>(delegate
		{
			UnloadPreviewCommand.Execute(new DestroyRenderViewParameters(IntPtr.Zero));
		});
		AddPropertyLinks();
	}

	[RelayCommand]
	private void SelectActivePage(ISettingsItemVM settingsItemVM)
	{
		if (!_ignoreActivePageChanged)
		{
			ActivePage = settingsItemVM;
		}
	}

	[RelayCommand]
	private void LoadPreview(CreateRenderViewParameters parameters)
	{
		_coreManager.CreateRenderView(parameters);
	}

	[RelayCommand]
	private void UnloadPreview(DestroyRenderViewParameters parameters)
	{
		_coreManager.DestroyRenderView(parameters);
	}

	private void NavigationVM_Navigate(ISettingsItemVM page)
	{
		_ignoreActivePageChanged = true;
		SetPage(page);
		_ignoreActivePageChanged = false;
	}

	private void SetPage(ISettingsItemVM? page)
	{
		if (page?.Parent == null)
		{
			SelectedItem = page;
			ActiveItem = page;
		}
		else if (page.Parent != null && page.Parent != ActiveItem)
		{
			SelectedItem = page.Parent;
			ActiveItem = page.Parent;
		}
		ActivePage = page;
	}

	public void SetActivePage(SettingsPage page)
	{
		SetPage(page switch
		{
			SettingsPage.ProContent => Items.OfType<IRegistrationMainPageVM>().FirstOrDefault(), 
			SettingsPage.Account => Items.OfType<IRegistrationMainPageVM>().FirstOrDefault(), 
			SettingsPage.General => Items.OfType<IGeneralSettingsVM>().FirstOrDefault(), 
			SettingsPage.Updates => Items.OfType<IUpdatesSettingsVM>().FirstOrDefault(), 
			SettingsPage.Screens => Items.OfType<IScreenSettingsVM>().FirstOrDefault(), 
			SettingsPage.Network => Items.OfType<INetworkSettingsVM>().FirstOrDefault(), 
			SettingsPage.Input => Items.OfType<IInputsSettingsVM>().FirstOrDefault(), 
			SettingsPage.Devices => Items.OfType<IDevicesSettingsVM>().FirstOrDefault(), 
			SettingsPage.Media => Items.OfType<IMediaSettingsVM>().FirstOrDefault(), 
			SettingsPage.Audio => Items.OfType<IAudioSettingsVM>().FirstOrDefault(), 
			SettingsPage.Import => Items.OfType<IImportSettingsVM>().FirstOrDefault(), 
			SettingsPage.Integrations => Items.OfType<IIntegrationsSettingsVM>().FirstOrDefault(), 
			SettingsPage.Resi => Items.OfType<IIntegrationsSettingsVM>().FirstOrDefault()?.Resi, 
			SettingsPage.Services => Items.OfType<IIntegrationsSettingsVM>().FirstOrDefault(), 
			SettingsPage.Groups => Items.OfType<IGroupsSettingsVM>().FirstOrDefault(), 
			SettingsPage.SlideLabels => Items.OfType<ILabelsSettingsVM>().FirstOrDefault(), 
			SettingsPage.Sync => Items.OfType<ISyncSettingsVM>().FirstOrDefault(), 
			SettingsPage.Advanced => Items.OfType<IRegistrationMainPageVM>().FirstOrDefault(), 
			_ => Items.OfType<IRegistrationMainPageVM>().FirstOrDefault(), 
		});
	}

	public void ToggleInputStatus(bool enable)
	{
		_coreManager.ToggleInputStatus(enable);
	}

	private void OnSearchResultSelected()
	{
		if (_searchVM.ActiveItem?.Item != null)
		{
			ISettingsItemVM item = _searchVM.ActiveItem.Item;
			SetPage(item);
			NavigationVM.UpdateActivePage(item);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnActiveItemChanged(ISettingsListItem? value)
	{
		if (value is ISettingsItemVM settingsItemVM)
		{
			SelectActivePage(settingsItemVM);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnActivePageChanged(ISettingsItemVM? value)
	{
		if (!_ignoreActivePageChanged)
		{
			NavigationVM.UpdateActivePage(value);
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _searchVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveItem")
		{
			OnSearchResultSelected();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_searchVM.PropertyChanged += _searchVM_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_searchVM.PropertyChanged -= _searchVM_PropertyChanged;
	}
}
