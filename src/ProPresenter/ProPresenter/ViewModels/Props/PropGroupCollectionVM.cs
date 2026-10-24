using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Commands;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Props;

public class PropGroupCollectionVM : LinkedNotifyPropertyChangedBase, IPropGroupCollectionVM, ITransitionControl
{
	private readonly ICoreManager _manager;

	private readonly IApp _app;

	private readonly IPropGroupCollection _propGroupCollection;

	private IPropGroupVM? _activeGroup;

	private IPropGroupVM? _selectedGroup;

	private bool _isCollectionPopupOpen;

	private bool _renameNextItem;

	private bool _activeGroupChangingFromCoreManager;

	private readonly DragDropPairedCollection<IPropGroup, IPropGroupVM> _groups;

	public IPropGroupVM? ActiveGroup
	{
		get
		{
			return _activeGroup;
		}
		set
		{
			SetValue("ActiveGroup", ref _activeGroup, value, (Action)delegate
			{
				if (value is IPropGroupVMInternal propGroupVMInternal)
				{
					_app.SelectedPropGroupId = propGroupVMInternal.Source.ID;
					if (!_activeGroupChangingFromCoreManager)
					{
						_manager.ActivePropGroup = propGroupVMInternal.Source;
					}
				}
				else
				{
					_app.SelectedPropGroupId = Guid.Empty;
				}
			}, (Predicate<IPropGroupVM>?)null, referenceComparison: false);
		}
	}

	public IPropGroupVM? SelectedGroup
	{
		get
		{
			return _selectedGroup;
		}
		set
		{
			SetValue("SelectedGroup", ref _selectedGroup, value);
		}
	}

	public Guid CollectionId => (ActiveGroup as IPropGroupVMInternal)?.Source.ID ?? Guid.Empty;

	public PanelViewType ListOrGrid
	{
		get
		{
			return _app.PropsViewPanelType;
		}
		set
		{
			_app.PropsViewPanelType = value;
		}
	}

	public int RowCapacity
	{
		get
		{
			return _app.PropViewRowCapacity;
		}
		set
		{
			_app.PropViewRowCapacity = value;
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _propGroupCollection.SelectedTransition;
		}
		set
		{
			_propGroupCollection.SelectedTransition = value;
			_manager.PropsTransition = value;
		}
	}

	public bool IsCollectionPopupOpen
	{
		get
		{
			return _isCollectionPopupOpen;
		}
		set
		{
			SetValue("IsCollectionPopupOpen", ref _isCollectionPopupOpen, value);
		}
	}

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public ssAPIOutput OutputController { get; }

	public TransitionHandler TransitionHandler { get; set; }

	public IEnumerable<double> AutoClearMenuData { get; } = new List<double> { 5.0, 10.0, 15.0, 20.0, 30.0, 45.0, 60.0 };

	public IDragDropNotifyEnumerableChanged<IPropGroupVM> DragSource => _groups;

	public INotifyEnumerableChanged<IPropGroupVM> PropGroups => _groups;

	public ICommand AddGroupCommand => new RelayCommand(OnAddGroup);

	public ICommand DeleteGroupCommand => new RelayCommand(OnDeleteGroup, () => SelectedGroup != null);

	public ICommand DuplicateGroupCommand => new RelayCommand(OnDuplicateGroup, () => SelectedGroup != null);

	public ICommand CloseCollectionPopupCommand => new RelayCommand(delegate
	{
		IsCollectionPopupOpen = false;
	});

	public ICommand<ShowSource> EditPropsCommand => new RelayCommand<ShowSource>(EditPropsCommandExecuted);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(_propGroupCollection.UndoStack);
	});

	public event Action<UndoStack>? StackChanged;

	public event Action<IPropGroupVM, IPropCueVM?>? EditProps;

	public PropGroupCollectionVM(ICoreManager manager, ssAPIOutput outputController, IApp app, IPropGroupCollectionFactoryVM propGroupCollectionFactoryVM, IProPresenterResourceService proPresenterResourceService)
	{
		PropGroupCollectionVM propGroupCollectionVM = this;
		_app = app;
		_manager = manager;
		OutputController = outputController;
		_propGroupCollection = proPresenterResourceService.PropGroupCollection;
		_groups = new DragDropPairedCollection<IPropGroup, IPropGroupVM>(_propGroupCollection, (IPropGroup g) => propGroupCollectionFactoryVM.CreatePropGroupVM(g, propGroupCollectionVM));
		TransitionHandler = new TransitionHandler(proPresenterResourceService.Transitions);
		if (_propGroupCollection.SelectedTransition == null && TransitionHandler.Set.CutTransition != null)
		{
			_propGroupCollection.SelectedTransition = TransitionHandler.Set.CutTransition.Preset.Parameters;
		}
		TransitionHandler.ActivateTransition(SelectedTransition);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
		LinkProperties("PropViewRowCapacity", "RowCapacity");
		LinkProperties("SelectedTransition", "SelectedTransition");
		_app.PropertyChanged += base.RaiseLinkedValues;
		_propGroupCollection.PropertyChanged += base.RaiseLinkedValues;
		_propGroupCollection.TargetDirectoryChanged += SetDefaultActiveGroup;
		_manager.PropertyChanged += base.RaiseLinkedValues;
		_manager.PropsTransition = SelectedTransition;
		SetDefaultActiveGroup();
		if (manager != null)
		{
			manager.PropertyChanged += Manager_PropertyChanged;
		}
	}

	private void SetDefaultActiveGroup()
	{
		if (_groups.Count == 0)
		{
			ActiveGroup = null;
			return;
		}
		if (_app.SelectedPropGroupId != Guid.Empty)
		{
			ActiveGroup = PropGroups.FirstOrDefault((IPropGroupVM m) => ((IPropGroupVMInternal)m).Source.ID == _app.SelectedPropGroupId);
		}
		if (ActiveGroup == null)
		{
			IPropGroupVM propGroupVM2 = (ActiveGroup = _groups[0]);
		}
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
		PropsTransitionEvent.Publish();
	}

	private void OnAddGroup()
	{
		RenameNextItem = true;
		IPropGroup newGroup = _propGroupCollection.AddGroup();
		SelectedGroup = PropGroups.OfType<IPropGroupVMInternal>().FirstOrDefault((IPropGroupVMInternal g) => g.Source.Equals(newGroup));
		ActiveGroup = SelectedGroup;
	}

	private void OnDeleteGroup()
	{
		if (SelectedGroup != null)
		{
			IPropGroup source = ((IPropGroupVMInternal)SelectedGroup).Source;
			int index = _groups.IndexOf(source);
			bool flag = ActiveGroup == SelectedGroup && ActiveGroup != null;
			_propGroupCollection.RemoveGroup(source);
			if (!_propGroupCollection.Any())
			{
				_propGroupCollection.AddDefault();
				flag = true;
			}
			SelectedGroup = _groups.ElementAtOrDefault(index) ?? _groups.FirstOrDefault();
			if (flag)
			{
				ActiveGroup = SelectedGroup;
			}
		}
	}

	private void OnDuplicateGroup()
	{
		if (SelectedGroup != null)
		{
			IPropGroup group = ((IPropGroupVMInternal)SelectedGroup).Source.Clone();
			int num = _groups.IndexOf(((IPropGroupVMInternal)SelectedGroup).Source);
			num = ((num < 0) ? _groups.Count() : num);
			_propGroupCollection.InsertGroup(group, num);
		}
	}

	public void OnEditProps(IPropGroupVM groupVM, IPropCueVM? cueVM)
	{
		this.EditProps?.Invoke(groupVM, cueVM ?? groupVM.PropCues.FirstOrDefault());
	}

	private void EditPropsCommandExecuted(ShowSource source)
	{
		if (SelectedGroup == null)
		{
			IPropGroupVM propGroupVM2 = (SelectedGroup = _groups[0]);
		}
		if (ActiveGroup != null && !ActiveGroup.PropCues.Any())
		{
			((IPropGroupVMInternal)ActiveGroup).Source.AddProp();
		}
		OnEditProps(SelectedGroup, SelectedGroup.SelectedCue);
		switch (source)
		{
		case ShowSource.Toolbar:
			MainViewPropsEditorEvent.Publish(MainViewSource.Toolbar);
			break;
		case ShowSource.LowerRight:
			MainViewPropsEditorEvent.Publish(MainViewSource.LowerRight);
			break;
		}
	}

	private void Manager_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActivePropGroup")
		{
			_activeGroupChangingFromCoreManager = true;
			ActiveGroup = PropGroups.FirstOrDefault((IPropGroupVM g) => ((IPropGroupVMInternal)g).Source == _manager.ActivePropGroup);
			_activeGroupChangingFromCoreManager = false;
		}
	}
}
