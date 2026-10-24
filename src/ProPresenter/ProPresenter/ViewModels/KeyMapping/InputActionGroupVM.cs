using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.InputActions;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.ViewModels.KeyMapping;

namespace ProPresenter.ViewModels.KeyMapping;

public class InputActionGroupVM : LinkedNotifyPropertyChangedBase, IInputActionGroupVM, INotifyPropertyChanged
{
	private bool _isExpanded = true;

	private readonly PairedCollection<InputAction, IInputActionItemVM> _inputActions;

	private readonly FilteredObservableCollection<IInputActionItemVM> _filteredInputActions;

	private readonly PairedCollection<InputActionGroupBase, IInputActionGroupVM> _children;

	private FilterType _filterType;

	private string _filterText = string.Empty;

	private bool _filterCustomized;

	private bool _filterConflicts;

	public bool IsExpanded
	{
		get
		{
			return _isExpanded;
		}
		set
		{
			SetValue("IsExpanded", ref _isExpanded, value);
		}
	}

	public string Label => Group.Label;

	public INotifyEnumerableChanged<IInputActionItemVM> InputActions => _inputActions;

	public INotifyEnumerableChanged<IInputActionItemVM> FilteredInputActions => _filteredInputActions;

	public INotifyEnumerableChanged<IInputActionGroupVM> Children => _children;

	public InputActionGroupBase Group { get; }

	public bool HasFilteredActions
	{
		get
		{
			if (!FilteredInputActions.Any())
			{
				return Children.Any((IInputActionGroupVM c) => c.HasFilteredActions);
			}
			return true;
		}
	}

	public InputActionGroupVM(InputActionGroupBase group, IInputActionGroupVMFactory factory)
	{
		Group = group;
		_inputActions = new PairedCollection<InputAction, IInputActionItemVM>(Group, factory.Create);
		_filteredInputActions = new FilteredObservableCollection<IInputActionItemVM>(_inputActions, FilterItem);
		_children = new PairedCollection<InputActionGroupBase, IInputActionGroupVM>(group.Children, factory.Create);
		LinkProperties("Label", "Label");
		LinkProperties("HasFilteredActions", "HasFilteredActions");
		Group.PropertyChanged += base.RaiseLinkedValues;
		_filteredInputActions.CollectionChanged += delegate
		{
			OnPropertyChanged("HasFilteredActions");
		};
		_children.CollectionChanged += Children_CollectionChanged;
		_children.ForEach(delegate(IInputActionGroupVM i)
		{
			i.PropertyChanged += base.RaiseLinkedValues;
		});
	}

	public void ApplyFilter(FilterType filterType, bool filterCustomized, bool filterConflicts, string filterText)
	{
		_filterType = filterType;
		_filterText = filterText;
		_filterCustomized = filterCustomized;
		_filterConflicts = filterConflicts;
		_filteredInputActions.Refresh();
		foreach (IInputActionGroupVM child in _children)
		{
			child.ApplyFilter(filterType, filterCustomized, filterConflicts, filterText);
		}
		OnPropertyChanged("HasFilteredActions");
	}

	private void Children_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IInputActionGroupVM>().ForEach(delegate(IInputActionGroupVM i)
		{
			i.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<IInputActionGroupVM>().ForEach(delegate(IInputActionGroupVM i)
		{
			i.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("HasFilteredActions");
	}

	private bool FilterItem(IInputActionItemVM itemVM)
	{
		bool flag = false;
		switch (_filterType)
		{
		case FilterType.All:
			flag = true;
			break;
		case FilterType.Menu:
			flag = itemVM.Type == InputActionType.MenuItem;
			break;
		case FilterType.Show:
			flag = itemVM.Type.IsAnyOf(InputActionType.ClearGroup, InputActionType.GroupLabel, InputActionType.Macro, InputActionType.Prop);
			break;
		case FilterType.Unused:
			flag = (object)itemVM.KeyboardGesture == null;
			break;
		}
		if (_filterCustomized)
		{
			flag = flag && itemVM.IsCustomized;
		}
		if (_filterConflicts)
		{
			flag = flag && itemVM.HasConflicts;
		}
		if (!string.IsNullOrEmpty(_filterText))
		{
			flag = flag && (itemVM.Label.Contains(_filterText, StringComparison.OrdinalIgnoreCase) || itemVM.KeyboardGestureText.Contains(_filterText, StringComparison.OrdinalIgnoreCase));
		}
		return flag;
	}
}
