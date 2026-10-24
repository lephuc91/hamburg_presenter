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
using Pro.DO.Label;
using Pro.Localization.Services;
using Pro.UI.Themes;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Labels;

public class LabelsSettingsVM : ObservableObject, ILabelsSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IDragDropCollection<ILabelItemVM>
{
	private readonly PairedCollection<ActionLabel, ILabelItemVM> _labels;

	private readonly IProPresenterResourceService _resourceService;

	private readonly ILocalization _localization;

	[ObservableProperty]
	private ILabelItemVM? _selectedLabel;

	[ObservableProperty]
	private bool _renameNextItem;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addLabelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? removeLabelCommand;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public INotifyEnumerableChanged<ILabelItemVM> Labels => _labels;

	public ObservableCollection<ILabelItemVM> SelectedLabels { get; } = new ObservableCollection<ILabelItemVM>();

	public ISettingsItemVM? Parent => null;

	public string Name { get; }

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(_resourceService.SlideLabels.UndoStack);
	});

	public Brush? Background => SettingsListItemConstants.Cyan;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsLabels);

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ILabelItemVM? SelectedLabel
	{
		get
		{
			return _selectedLabel;
		}
		set
		{
			if (!EqualityComparer<ILabelItemVM>.Default.Equals(_selectedLabel, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedLabel);
				_selectedLabel = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedLabel);
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
	public IRelayCommand AddLabelCommand => addLabelCommand ?? (addLabelCommand = new RelayCommand(AddLabel));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RemoveLabelCommand => removeLabelCommand ?? (removeLabelCommand = new RelayCommand(RemoveLabel, CanRemoveLabel));

	public event Action<UndoStack>? StackChanged;

	public LabelsSettingsVM(IProPresenterResourceService resourceService, ILocalization localization, ILabelItemVMFactory factory, ISettingsSearchFactory settingsSearchFactory)
	{
		Name = localization.Get("SETTINGS_LABELS_PAGE_title");
		_resourceService = resourceService;
		_localization = localization;
		_labels = new PairedCollection<ActionLabel, ILabelItemVM>(resourceService.SlideLabels, factory.Create);
		SelectedLabels.CollectionChanged += delegate
		{
			RemoveLabelCommand.NotifyCanExecuteChanged();
		};
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_LABELS_PAGE_title", this, isComponent: false, PageField);
	}

	[RelayCommand]
	private void AddLabel()
	{
		RenameNextItem = true;
		int index = _labels.Count;
		if (SelectedLabel != null)
		{
			int num = ((IEnumerable<ILabelItemVM>)Labels).IndexOf<ILabelItemVM>(SelectedLabel);
			if (num != -1)
			{
				index = num + 1;
			}
		}
		ActionLabel actionLabel = new ActionLabel(_localization.Get("SETTINGS_LABELS_DEFAULT_NEW_LABEL_NAME_title"));
		_resourceService.SlideLabels.Insert(index, actionLabel);
		SelectItem(actionLabel);
	}

	[RelayCommand(CanExecute = "CanRemoveLabel")]
	private void RemoveLabel()
	{
		IEnumerable<ActionLabel> slideLables = from i in SelectedLabels.OfType<ILabelItemVMInternal>()
			select i.Label;
		_resourceService.SlideLabels.RemoveRange(slideLables);
	}

	private bool CanRemoveLabel()
	{
		return SelectedLabels.Any();
	}

	private void SelectItem(ActionLabel label)
	{
		SelectedLabels.Clear();
		SelectedLabel = Labels.OfType<ILabelItemVMInternal>().FirstOrDefault((ILabelItemVMInternal i) => i.Label == label);
		if (SelectedLabel != null)
		{
			SelectedLabels.Add(SelectedLabel);
		}
	}

	public void DraggedFrom(IEnumerable<ILabelItemVM> items)
	{
	}

	public void DroppedInto(IEnumerable<ILabelItemVM> items, int index, bool isCopy)
	{
		IEnumerable<ActionLabel> items2 = from i in items.OfType<ILabelItemVMInternal>()
			select i.Label;
		_resourceService.SlideLabels.DroppedInto(items2, index, isCopy);
	}

	public int IndexOf(ILabelItemVM item)
	{
		if (item is ILabelItemVMInternal labelItemVMInternal)
		{
			return _resourceService.SlideLabels.IndexOf(labelItemVMInternal.Label);
		}
		return -1;
	}

	public void MoveTo(IEnumerable<ILabelItemVM> items, int index)
	{
		IEnumerable<ActionLabel> items2 = from i in items.OfType<ILabelItemVMInternal>()
			select i.Label;
		_resourceService.SlideLabels.MoveTo(items2, index);
	}

	public void PromptUnableToExit()
	{
		throw new NotImplementedException();
	}
}
