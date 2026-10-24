using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class MacroAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private Identification _macroIdentification = Identification.Empty();

	private IMacroSource? _macroSource;

	public override ActionType ActionType => ActionType.Macro;

	public Guid MacroID => MacroIdentification.Id;

	public string MacroName => MacroIdentification.Name;

	public Guid MacroParentCollectionID => MacroIdentification.ParentId;

	public string MacroParentCollectionName => MacroIdentification.ParentName;

	public override bool IsValid => _macroSource?.FindMacro(MacroID, MacroName, MacroParentCollectionID, MacroParentCollectionName) != null;

	public System.Windows.Media.Color? MacroColor => _macroSource?.FindMacro(MacroID, MacroName, MacroParentCollectionID, MacroParentCollectionName)?.Color;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_MACRO_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	private Identification MacroIdentification
	{
		get
		{
			return _macroIdentification;
		}
		set
		{
			SetValue("MacroIdentification", ref _macroIdentification, value, delegate(Identification o, Identification n)
			{
				base.Name = n.Name;
				OnPropertyChanged("MacroID");
				OnPropertyChanged("MacroName");
				OnPropertyChanged("MacroParentCollectionID");
				OnPropertyChanged("MacroParentCollectionName");
				OnPropertyChanged("IsValid");
				OnPropertyChanged("MacroColor");
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler uiScheduler, IEntityFactory entityFactory, MacroAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(uiScheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IMacro macro = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IMacro;
		if (macro == null)
		{
			macro = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IMacro>();
			right.ActionTypeData.Set(macro);
		}
		ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IMacroType> macroActionBinder = CreateBinder(uiScheduler, entityFactory, left, macro.Value);
		objectBinder.DoOnInitializeRightFromLeft(macroActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(macroActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => macroActionBinder);
		return objectBinder;
	}

	public static ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IActionTypeData.IMacro> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, MacroAction left, Pro.Entity.IAction.Types.IActionTypeData.IMacro entityActionData)
	{
		ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IActionTypeData.IMacro> objectBinder = new ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IActionTypeData.IMacro>(left, entityActionData);
		ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IMacroType> macroActionBinder = CreateBinder(scheduler, entityFactory, left, entityActionData.Value);
		objectBinder.RegisterChildDisposable(() => macroActionBinder);
		return objectBinder;
	}

	private static ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IMacroType> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, MacroAction left, Pro.Entity.IAction.Types.IMacroType macro)
	{
		ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IMacroType> objectBinder = new ObjectBinder<MacroAction, Pro.Entity.IAction.Types.IMacroType>(left, macro);
		objectBinder.Bind((MacroAction l) => l.WhenPropertyChanges("MacroIdentification"), (Pro.Entity.IAction.Types.IMacroType r) => r.Identification.WhenAnyValueChanges, delegate(MacroAction l, Pro.Entity.IAction.Types.IMacroType r)
		{
			r.Identification.Value.ParameterUuid.Set(l.MacroID);
			r.Identification.Value.ParameterName.Set(l.MacroName);
			ICollectionElementType collectionElementType = entityFactory.Create<ICollectionElementType>();
			r.Identification.Value.ParentCollection.Set(collectionElementType);
			collectionElementType.ParameterUuid.Set(l.MacroParentCollectionID);
			collectionElementType.ParameterName.Set(l.MacroParentCollectionName);
		}, delegate(Pro.Entity.IAction.Types.IMacroType r, MacroAction l)
		{
			l.MacroIdentification = new Identification(r.Identification.Value.ParameterUuid.ToGuidOrEmpty(), r.Identification.Value.ParameterName.Value ?? string.Empty, (r.Identification.Value.ParentCollection.Value?.ParameterUuid).ToGuidOrEmpty(), r.Identification.Value.ParentCollection.Value?.ParameterName.Value ?? string.Empty);
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public MacroAction()
		: this(DataVault.MacroSource, null)
	{
	}

	public MacroAction(IMacroSource macroSource, Guid? id = null)
	{
		base.ID = id ?? base.ID;
		AssignMacroSource(macroSource);
		LinkProperties("Color", "MacroColor");
		LinkProperties("Name", "IsValid");
	}

	public void AssignMacroSource(IMacroSource macroSource)
	{
		_macroSource = macroSource;
		if (_macroSource != null)
		{
			_macroSource.MacroCollectionsChanged += MacroCollections_Changed;
			_macroSource.MacroPropertyChanged += Macro_PropertyChanged;
		}
		OnPropertyChanged("IsValid");
		OnPropertyChanged("MacroColor");
	}

	private void MacroCollections_Changed(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("IsValid");
		OnPropertyChanged("MacroColor");
	}

	private void Macro_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is ProPresenterMacro proPresenterMacro && proPresenterMacro.ID == MacroID && e.PropertyName == "Name")
		{
			MacroIdentification = MacroIdentification with
			{
				Name = proPresenterMacro.Name
			};
		}
		RaiseLinkedValues(sender, e);
	}

	void IActionDataIdentifier.SetIdentifier(Guid id, string name)
	{
		SetIdentifier(id, name, Guid.Empty, string.Empty);
	}

	public void SetIdentifier(Guid id, string name, Guid parentCollectionID, string parentCollectionName)
	{
		if (!(MacroID == id) || !(MacroName == name) || !(MacroParentCollectionID == parentCollectionID) || !(MacroParentCollectionName == parentCollectionName))
		{
			Guid oldId = MacroID;
			string oldName = MacroName;
			Guid oldParentCollectionID = MacroParentCollectionID;
			string oldParentCollectionName = MacroParentCollectionName;
			base.UndoStack?.Commit(UndoActionTypes.ActionSetMacro.ToAction(), delegate
			{
				set(oldId, oldName, oldParentCollectionID, oldParentCollectionName);
			}, delegate
			{
				set(id, name, parentCollectionID, parentCollectionName);
			}, null, null, autoFinalize: true);
			set(id, name, parentCollectionID, parentCollectionName);
		}
		void set(Guid id, string name, Guid parentCollectionID, string parentCollectionName)
		{
			MacroIdentification = new Identification(id, name, parentCollectionID, parentCollectionName);
		}
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new MacroAction(_macroSource, null));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is MacroAction macroAction)
		{
			macroAction.SetIdentifier(MacroID, MacroName, MacroParentCollectionID, MacroParentCollectionName);
		}
		return base.CopyProperties(action);
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Macro = new Pro.SerializationInterop.RVProtoData.Action.Types.MacroType
		{
			Identification = new CollectionElementType
			{
				ParameterUuid = MacroID.ToUUID(),
				ParameterName = (MacroName ?? string.Empty),
				ParentCollection = new CollectionElementType
				{
					ParameterUuid = MacroParentCollectionID.ToUUID(),
					ParameterName = MacroParentCollectionName
				}
			}
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		if (data?.Macro != null)
		{
			MacroIdentification = new Identification(data.Macro.Identification?.ParameterUuid.ToGuid() ?? Guid.Empty, data.Macro.Identification?.ParameterName ?? string.Empty, data.Macro.Identification?.ParentCollection?.ParameterUuid.ToGuid() ?? Guid.Empty, data.Macro.Identification?.ParentCollection?.ParameterName ?? string.Empty);
		}
	}
}
