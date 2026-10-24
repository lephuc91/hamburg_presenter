using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.ViewModels.KeyMapping;
using ProPresenter.ViewModels.KeyMapping;

namespace ProPresenter.ViewModels.Preferences;

public class KeyMappingVM : LinkedNotifyPropertyChangedBase, IKeyMappingVM, INotifyPropertyChanged
{
	private FilterType _filterType = FilterType.Show;

	private bool _filterCustomized;

	private bool _filterConflicts;

	private string _filterText = string.Empty;

	private readonly IKeyGesturePrompt _prompt;

	private readonly PairedCollection<InputActionGroupBase, IInputActionGroupVM> _inputActionGroups;

	private IInputActionItemVM? _selectedItem;

	private readonly IInputActions _inputActions;

	public FilterType FilterType
	{
		get
		{
			return _filterType;
		}
		private set
		{
			SetValue("FilterType", ref _filterType, value, FilterCommands);
		}
	}

	public bool FilterCustomized
	{
		get
		{
			return _filterCustomized;
		}
		set
		{
			SetValue("FilterCustomized", ref _filterCustomized, value, FilterCommands);
		}
	}

	public bool FilterConflicts
	{
		get
		{
			return _filterConflicts;
		}
		set
		{
			SetValue("FilterConflicts", ref _filterConflicts, value, FilterCommands);
		}
	}

	public string FilterText
	{
		get
		{
			return _filterText;
		}
		set
		{
			SetValue("FilterText", ref _filterText, value, FilterCommands);
		}
	}

	public INotifyEnumerableChanged<IInputActionGroupVM> InputActionGroups => _inputActionGroups;

	public IInputActionItemVM? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			SetValue("SelectedItem", ref _selectedItem, value);
		}
	}

	public string ConflictButtonContent
	{
		get
		{
			int num = _inputActions.SelectMany((InputActionGroupBase g) => g).OfType<InputAction>().Count((InputAction i) => i.HasConflicts);
			if (num <= 0)
			{
				return LocalizedStrings.Get("KEYMAPPING_PREFERENCES_FILTER_CONFLICTS_title");
			}
			return LocalizedStrings.Get("KEYMAPPING_PREFERENCES_FILTER_CONFLICTS_NUMBER_title", new object[1] { num });
		}
	}

	public ICommand<FilterType> SetFilterTypeCommand => new RelayCommand<FilterType>(OnSetFilterTypeCommand);

	public ICommand ResetAllCommand => new RelayCommand(OnResetAllCommand);

	public ICommand ShowConflictsCommand => new RelayCommand(delegate
	{
		FilterConflicts = true;
	});

	public KeyMappingVM(IKeyGesturePrompt prompt, IInputActionGroupVMFactory factory, IInputActions inputActions)
	{
		_prompt = prompt;
		_inputActions = inputActions;
		_inputActionGroups = new PairedCollection<InputActionGroupBase, IInputActionGroupVM>(inputActions, factory.Create);
		LinkProperties("HasConflicts", "ConflictButtonContent");
		inputActions.ForEach(delegate(InputActionGroupBase g)
		{
			g.CollectionChanged += Group_CollectionChanged;
		});
		inputActions.ForEach(delegate(InputActionGroupBase g)
		{
			g.OfType<InputAction>().ForEach(delegate(InputAction i)
			{
				i.PropertyChanged += base.RaiseLinkedValues;
			});
		});
		FilterCommands();
	}

	private void Group_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<InputAction>().ForEach(delegate(InputAction i)
		{
			i.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<InputAction>().ForEach(delegate(InputAction i)
		{
			i.PropertyChanged += base.RaiseLinkedValues;
		});
		FilterCommands();
		OnPropertyChanged("ConflictButtonContent");
	}

	private void FilterCommands()
	{
		_inputActionGroups.ForEach(delegate(IInputActionGroupVM i)
		{
			i.ApplyFilter(FilterType, FilterCustomized, FilterConflicts, FilterText);
		});
	}

	private void OnSetFilterTypeCommand(FilterType filterType)
	{
		FilterType = filterType;
	}

	private void OnResetAllCommand()
	{
		if (_prompt.ShowResetAllConfirmation())
		{
			_inputActions.ResetAll();
		}
	}
}
