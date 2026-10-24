using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class ClearGroupAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private ClearGroupCollection? _clearGroups;

	private Identification _groupIdentification = Identification.Empty();

	public override ActionType ActionType => ActionType.ClearGroup;

	public Guid GroupID => GroupIdentification.Id;

	public string GroupName => GroupIdentification.Name;

	private Identification GroupIdentification
	{
		get
		{
			return _groupIdentification;
		}
		set
		{
			SetValue("GroupIdentification", ref _groupIdentification, value, (Action<Identification, Identification>?)delegate
			{
				OnPropertyChanged("GroupID");
				OnPropertyChanged("GroupName");
				OnPropertyChanged("Target");
				OnPropertyChanged("IsValid");
				OnDataModified();
			}, (Predicate<Identification>?)null, referenceComparison: false);
		}
	}

	public ClearGroup? Target => _clearGroups?.FirstOrDefaultBy((ClearGroup m) => m.ID == GroupID, (ClearGroup m) => m.Name == GroupName);

	public override bool IsValid => Target != null;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_CLEAR_GROUP_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, ClearGroupAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IClearGroup clearGroup = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IClearGroup;
		if (clearGroup == null)
		{
			clearGroup = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IClearGroup>();
			right.ActionTypeData.Set(clearGroup);
		}
		ObjectBinder<ClearGroupAction, Pro.Entity.IAction.Types.IClearGroupType> clearGroupActionBinder = new ObjectBinder<ClearGroupAction, Pro.Entity.IAction.Types.IClearGroupType>(left, clearGroup.Value);
		clearGroupActionBinder.Bind((ClearGroupAction l) => l.WhenPropertyChanges("GroupIdentification"), (Pro.Entity.IAction.Types.IClearGroupType r) => r.Identification.WhenAnyValueChanges, delegate(ClearGroupAction l, Pro.Entity.IAction.Types.IClearGroupType r)
		{
			r.Identification.Value.ParameterUuid.Set(l.GroupID);
			r.Identification.Value.ParameterName.Set(l.GroupName);
		}, delegate(Pro.Entity.IAction.Types.IClearGroupType r, ClearGroupAction l)
		{
			l.GroupIdentification = l.GroupIdentification with
			{
				Id = r.Identification.Value.ParameterUuid.ToGuidOrEmpty(),
				Name = (r.Identification.Value.ParameterName.Value ?? string.Empty)
			};
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeRightFromLeft(clearGroupActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(clearGroupActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => clearGroupActionBinder);
		return objectBinder;
	}

	public ClearGroupAction()
		: this(DataVault.ClearGroups)
	{
	}

	public ClearGroupAction(ClearGroupCollection clearGroups)
	{
		AssignClearGroups(clearGroups);
	}

	public void AssignClearGroups(ClearGroupCollection clearGroups)
	{
		if (_clearGroups != null)
		{
			return;
		}
		_clearGroups = clearGroups;
		if (clearGroups != null)
		{
			clearGroups.CollectionChanged += ClearGroups_CollectionChanged;
			clearGroups.ForEach(delegate(ClearGroup m)
			{
				m.PropertyChanged += ClearGroup_PropertyChanged;
			});
			LinkProperties("Name", new string[2] { "Target", "IsValid" });
		}
		NotifyPropertyChange();
	}

	private void NotifyPropertyChange()
	{
		OnPropertyChanged("IsValid");
	}

	private void ClearGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClearGroup>().ForEach(delegate(ClearGroup m)
		{
			m.PropertyChanged -= ClearGroup_PropertyChanged;
		});
		e.NewItems?.OfType<ClearGroup>().ForEach(delegate(ClearGroup m)
		{
			m.PropertyChanged += ClearGroup_PropertyChanged;
		});
		NotifyPropertyChange();
	}

	private void ClearGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is ClearGroup clearGroup && clearGroup.ID == GroupID && e.PropertyName == "Name")
		{
			GroupIdentification = GroupIdentification with
			{
				Name = clearGroup.Name
			};
		}
		RaiseLinkedValues(sender, e);
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		_clearGroups.ThrowWhenNull("_clearGroups");
		return CopyProperties(new ClearGroupAction(_clearGroups));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is ClearGroupAction clearGroupAction)
		{
			clearGroupAction.SetIdentifier(GroupID, GroupName);
		}
		return base.CopyProperties(action);
	}

	public void SetIdentifier(Guid id, string name)
	{
		Identification oldValue = GroupIdentification;
		Identification newValue = GroupIdentification with
		{
			Id = id,
			Name = name
		};
		base.UndoStack?.Commit(UndoActionTypes.ActionSetClearGroup.ToAction(), delegate
		{
			GroupIdentification = oldValue;
		}, delegate
		{
			GroupIdentification = newValue;
		}, null, null, autoFinalize: true);
		GroupIdentification = newValue;
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.ClearGroup = new Pro.SerializationInterop.RVProtoData.Action.Types.ClearGroupType
		{
			Identification = new CollectionElementType
			{
				ParameterUuid = GroupID.ToUUID(),
				ParameterName = (GroupName ?? string.Empty)
			}
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		if (data?.ClearGroup != null)
		{
			GroupIdentification = GroupIdentification with
			{
				Id = (data.ClearGroup.Identification?.ParameterUuid.ToGuid() ?? Guid.Empty),
				Name = (data.ClearGroup.Identification?.ParameterName ?? string.Empty)
			};
		}
	}
}
