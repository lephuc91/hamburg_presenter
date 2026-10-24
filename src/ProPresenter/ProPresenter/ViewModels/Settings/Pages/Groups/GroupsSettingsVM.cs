using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.DO.Label;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.DO;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Groups;

public class GroupsSettingsVM : ObservableObject, IGroupsSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDragDropCollection<IGroupLabelItemVM>
{
	private readonly PairedCollection<GroupLabel, IGroupLabelItemVM> _groups;

	private readonly IProPresenterResourceService _resourceService;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	[ObservableProperty]
	private IGroupLabelItemVM? _selectedGroupLabel;

	[ObservableProperty]
	private bool _renameNextItem;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addGroupLabelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? removeGroupLabelCommand;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public INotifyEnumerableChanged<IGroupLabelItemVM> GroupLabels => _groups;

	public ObservableCollection<IGroupLabelItemVM> SelectedGroups { get; } = new ObservableCollection<IGroupLabelItemVM>();

	public ISettingsItemVM? Parent => null;

	public string Name { get; }

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpGroups));
	});

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(_resourceService.GroupLabels.UndoStack);
	});

	public Brush? Background => SettingsListItemConstants.Cyan;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsGroups);

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IGroupLabelItemVM? SelectedGroupLabel
	{
		get
		{
			return _selectedGroupLabel;
		}
		set
		{
			if (!EqualityComparer<IGroupLabelItemVM>.Default.Equals(_selectedGroupLabel, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedGroupLabel);
				_selectedGroupLabel = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedGroupLabel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_renameNextItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RenameNextItem);
				_renameNextItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RenameNextItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddGroupLabelCommand => addGroupLabelCommand ?? (addGroupLabelCommand = new RelayCommand(AddGroupLabel));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RemoveGroupLabelCommand => removeGroupLabelCommand ?? (removeGroupLabelCommand = new RelayCommand(RemoveGroupLabel, CanRemoveGroups));

	public event Action<UndoStack>? StackChanged;

	public GroupsSettingsVM(IProPresenterResourceService resourceService, ILocalization localization, IGroupLabelItemVMFactory factory, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory)
	{
		Name = localization.Get("SETTINGS_GROUPS_PAGE_title");
		_resourceService = resourceService;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_groups = new PairedCollection<GroupLabel, IGroupLabelItemVM>(resourceService.GroupLabels, factory.Create);
		SelectedGroups.CollectionChanged += delegate
		{
			RemoveGroupLabelCommand.NotifyCanExecuteChanged();
		};
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_GROUPS_PAGE_title", this, isComponent: false, PageField);
	}

	[RelayCommand]
	private void AddGroupLabel()
	{
		RenameNextItem = true;
		int index = _groups.Count;
		if (SelectedGroupLabel != null)
		{
			int num = ((IEnumerable<IGroupLabelItemVM>)GroupLabels).IndexOf<IGroupLabelItemVM>(SelectedGroupLabel);
			if (num != -1)
			{
				index = num + 1;
			}
		}
		GroupLabel groupLabel = new GroupLabel(_localization.Get("SETTINGS_GROUPS_DEFAULT_NEW_GROUP_NAME_title"));
		_resourceService.GroupLabels.Insert(index, groupLabel);
		SelectItem(groupLabel);
	}

	[RelayCommand(CanExecute = "CanRemoveGroups")]
	private void RemoveGroupLabel()
	{
		IEnumerable<GroupLabel> groupLabels = from i in SelectedGroups.OfType<IGroupLabelItemVMInternal>()
			select i.Label;
		_resourceService.GroupLabels.RemoveRange(groupLabels);
	}

	private bool CanRemoveGroups()
	{
		return SelectedGroups.Any();
	}

	private void SelectItem(GroupLabel group)
	{
		SelectedGroups.Clear();
		SelectedGroupLabel = GroupLabels.OfType<IGroupLabelItemVMInternal>().FirstOrDefault((IGroupLabelItemVMInternal i) => i.Label == group);
		if (SelectedGroupLabel != null)
		{
			SelectedGroups.Add(SelectedGroupLabel);
		}
	}

	public void DraggedFrom(IEnumerable<IGroupLabelItemVM> items)
	{
	}

	public void DroppedInto(IEnumerable<IGroupLabelItemVM> items, int index, bool isCopy)
	{
		IEnumerable<GroupLabel> items2 = from i in items.OfType<IGroupLabelItemVMInternal>()
			select i.Label;
		_resourceService.GroupLabels.DroppedInto(items2, index, isCopy);
	}

	public int IndexOf(IGroupLabelItemVM item)
	{
		if (item is IGroupLabelItemVMInternal groupLabelItemVMInternal)
		{
			return _resourceService.GroupLabels.IndexOf(groupLabelItemVMInternal.Label);
		}
		return -1;
	}

	public void MoveTo(IEnumerable<IGroupLabelItemVM> items, int index)
	{
		IEnumerable<GroupLabel> items2 = from i in items.OfType<IGroupLabelItemVMInternal>()
			select i.Label;
		_resourceService.GroupLabels.MoveTo(items2, index);
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
