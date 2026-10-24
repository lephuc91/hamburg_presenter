using System;
using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;

namespace ProPresenter.DO.Actions;

public class PropAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private IPropTrigger _propTrigger = new PropActionTrigger();

	private IPropSource? _propSource;

	private IPropCue? _propCue;

	private Identification _propIdentification = Identification.Empty();

	public override ActionType ActionType => ActionType.Prop;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public Guid PropID => PropIdentification.Id;

	public string PropName => _propCue?.Name ?? PropIdentification.Name;

	public PropTriggerType PropTriggerType => PropTrigger.TriggerType;

	public Guid PropParentCollectionID => _propCue?.ParentCollectionID ?? PropIdentification.ParentId;

	public string PropParentCollectionName => _propCue?.ParentCollectionName ?? PropIdentification.ParentName;

	public IPropTrigger PropTrigger
	{
		get
		{
			return _propTrigger;
		}
		set
		{
			SetValue("PropTrigger", ref _propTrigger, value, delegate(IPropTrigger o, IPropTrigger n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				OnDataModified();
			});
		}
	}

	public double AutoClearDuration
	{
		get
		{
			if (!AutoClearFollowsPropDuration)
			{
				return (PropTrigger as PropActionTrigger)?.AutoClearDuration.TotalSeconds ?? 0.0;
			}
			return (_propCue?.SlideAction?.AutoClearDuration).GetValueOrDefault();
		}
		set
		{
			if (PropTrigger is PropActionTrigger propActionTrigger)
			{
				base.UndoStack?.BeginCommit();
				base.UndoStack?.Commit(UndoActionTypes.AutoClearTime.ToAction(), this, "AutoClearDuration", AutoClearDuration, TimeSlice.FromSeconds(value));
				propActionTrigger.AutoClearDuration = TimeSlice.FromSeconds(value);
				AutoClearEnabled = value > 0.0;
				base.UndoStack?.EndCommit(null, null, autoFinalize: true);
				OnPropertyChanged("AutoClearDuration");
				OnPropertyChanged("AutoClearFollowsPropDuration");
				OnDataModified();
			}
		}
	}

	public bool AutoClearEnabled
	{
		get
		{
			if (!AutoClearFollowsPropDuration)
			{
				return (PropTrigger as PropActionTrigger)?.AutoClearEnabled ?? false;
			}
			return _propCue?.SlideAction?.AutoClearEnabled == true;
		}
		set
		{
			if (PropTrigger is PropActionTrigger propActionTrigger)
			{
				base.UndoStack?.Commit(UndoActionTypes.AutoClearEnabled.ToAction(), this, "AutoClearEnabled", AutoClearEnabled, value);
				propActionTrigger.AutoClearEnabled = value;
				OnPropertyChanged("AutoClearEnabled");
				OnDataModified();
			}
		}
	}

	public bool AutoClearFollowsPropDuration
	{
		get
		{
			return (PropTrigger as PropActionTrigger)?.AutoClearFollowsPropDuration ?? true;
		}
		set
		{
			if (PropTrigger is PropActionTrigger propActionTrigger)
			{
				base.UndoStack?.Commit(UndoActionTypes.AutoClearFollowsPropDuration.ToAction(), this, "AutoClearFollowsPropDuration", AutoClearFollowsPropDuration, value);
				propActionTrigger.AutoClearFollowsPropDuration = value;
				OnPropertyChanged("AutoClearDuration");
				OnPropertyChanged("AutoClearFollowsPropDuration");
				OnDataModified();
			}
		}
	}

	public double DefaultAutoClearDuration => (_propCue?.SlideAction?.AutoClearDuration).GetValueOrDefault();

	public override bool IsValid => _propSource?.FindProp(PropID, PropName, PropParentCollectionID, PropParentCollectionName) != null;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_PROP_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	private Identification PropIdentification
	{
		get
		{
			return _propIdentification;
		}
		set
		{
			SetValue("PropIdentification", ref _propIdentification, value, (Action<Identification, Identification>?)delegate
			{
				OnPropertyChanged("PropID");
				OnPropertyChanged("PropName");
				OnPropertyChanged("PropParentCollectionID");
				OnPropertyChanged("PropParentCollectionName");
				OnPropertyChanged("IsValid");
				OnDataModified();
			}, (Predicate<Identification>?)null, referenceComparison: false);
		}
	}

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, PropAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IProp prop = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IProp;
		if (prop == null)
		{
			prop = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IProp>();
			right.ActionTypeData.Set(prop);
		}
		ObjectBinder<PropAction, Pro.Entity.IAction.Types.IPropType> propActionBinder = new ObjectBinder<PropAction, Pro.Entity.IAction.Types.IPropType>(left, prop.Value);
		propActionBinder.Bind((PropAction l) => l.WhenPropertyChanges("PropIdentification"), (Pro.Entity.IAction.Types.IPropType r) => r.Identification.WhenAnyValueChanges, delegate(PropAction l, Pro.Entity.IAction.Types.IPropType r)
		{
			r.Identification.Value.ParameterUuid.Set(l.PropID);
			r.Identification.Value.ParameterName.Set(l.PropName);
			ICollectionElementType collectionElementType = entityFactory.Create<ICollectionElementType>();
			r.Identification.Value.ParentCollection.Set(collectionElementType);
			collectionElementType.ParameterUuid.Set(l.PropParentCollectionID);
			collectionElementType.ParameterName.Set(l.PropParentCollectionName);
		}, delegate(Pro.Entity.IAction.Types.IPropType r, PropAction l)
		{
			l.PropIdentification = new Identification(r.Identification.Value.ParameterUuid.ToGuidOrEmpty(), r.Identification.Value.ParameterName.Value ?? string.Empty, (r.Identification.Value.ParentCollection.Value?.ParameterUuid).ToGuidOrEmpty(), r.Identification.Value.ParentCollection.Value?.ParameterName.Value ?? string.Empty);
		}, null, scheduler.Scheduler).Bind((PropAction l) => l.WhenPropertyChanges("PropTrigger"), (Pro.Entity.IAction.Types.IPropType r) => r.TriggerType.WhenValueChanges, delegate(PropAction l, Pro.Entity.IAction.Types.IPropType r)
		{
			if (l.PropTriggerType == PropTriggerType.Clear)
			{
				r.TriggerType.Set(entityFactory.Create<Pro.Entity.IAction.Types.IPropType.Types.ITriggerType.IClear>());
			}
			else
			{
				Pro.Entity.IAction.Types.IPropType.Types.ITriggerType.ITrigger trigger = entityFactory.Create<Pro.Entity.IAction.Types.IPropType.Types.ITriggerType.ITrigger>();
				r.TriggerType.Set(trigger);
				ObjectBinder<PropActionTrigger, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger> objectBinder2 = CreateTriggerBinder((PropActionTrigger)l.PropTrigger, trigger.Value);
				trigger.Value.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
			}
		}, delegate(Pro.Entity.IAction.Types.IPropType r, PropAction l)
		{
			if (r.TriggerType.Value is Pro.Entity.IAction.Types.IPropType.Types.ITriggerType.ITrigger trigger2)
			{
				PropActionTrigger propTrigger = new PropActionTrigger();
				l.PropTrigger = propTrigger;
				ObjectBinder<PropActionTrigger, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger> objectBinder3 = CreateTriggerBinder((PropActionTrigger)l.PropTrigger, trigger2.Value);
				trigger2.Value.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeLeftFromRight();
			}
			else
			{
				l.PropTrigger = new PropActionClear();
			}
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeLeftFromRight(propActionBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(propActionBinder.InitializeRightFromLeft).RegisterChildDisposable(() => propActionBinder);
		return objectBinder;
	}

	private static ObjectBinder<PropActionTrigger, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger> CreateTriggerBinder(PropActionTrigger model, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger entity)
	{
		return new ObjectBinder<PropActionTrigger, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger>(model, entity).Bind((PropActionTrigger l) => l.WhenPropertyChanges("AutoClearEnabled"), (Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r) => r.AutoClearEnabled.WhenValueChanges, delegate(PropActionTrigger l, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r)
		{
			r.AutoClearEnabled.Set(l.AutoClearEnabled);
		}, delegate(Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r, PropActionTrigger l)
		{
			l.AutoClearEnabled = r.AutoClearEnabled.Value;
		}).Bind((PropActionTrigger l) => l.WhenPropertyChanges("AutoClearDuration"), (Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r) => r.AutoClearDuration.WhenValueChanges, delegate(PropActionTrigger l, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r)
		{
			r.AutoClearDuration.Set(l.AutoClearDuration.TotalSeconds);
		}, delegate(Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r, PropActionTrigger l)
		{
			l.AutoClearDuration = TimeSlice.FromSeconds(r.AutoClearDuration.Value);
		}).Bind((PropActionTrigger l) => l.WhenPropertyChanges("AutoClearFollowsPropDuration"), (Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r) => r.AutoClearFollowsPropDuration.WhenValueChanges, delegate(PropActionTrigger l, Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r)
		{
			r.AutoClearFollowsPropDuration.Set(l.AutoClearFollowsPropDuration);
		}, delegate(Pro.Entity.IAction.Types.IPropType.Types.IPropTrigger r, PropActionTrigger l)
		{
			l.AutoClearFollowsPropDuration = r.AutoClearFollowsPropDuration.Value;
		});
	}

	public void ChangeTriggerType(PropTriggerType propTriggerType)
	{
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Trigger));
		PropTriggerType oldPropTriggerType = PropTriggerType;
		PropTrigger = propTriggerType switch
		{
			PropTriggerType.Trigger => new PropActionTrigger(), 
			PropTriggerType.Clear => new PropActionClear(), 
			_ => new PropActionTrigger(), 
		};
		if (propTriggerType == PropTriggerType.Trigger)
		{
			AutoClearDuration = DefaultAutoClearDuration;
			AutoClearEnabled = _propCue?.SlideAction?.AutoClearEnabled == true;
			AutoClearFollowsPropDuration = true;
		}
		base.UndoStack?.Commit(delegate
		{
			ChangeTriggerType(oldPropTriggerType);
		}, delegate
		{
			ChangeTriggerType(propTriggerType);
		});
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
		OnPropertyChanged("PropTriggerType");
		OnPropertyChanged("AutoClearDuration");
		OnPropertyChanged("AutoClearEnabled");
		OnPropertyChanged("AutoClearFollowsPropDuration");
		OnDataModified();
	}

	public PropAction()
		: this(DataVault.PropSource)
	{
	}

	public PropAction(IPropSource? propSource)
	{
		AssignPropSource(propSource);
		LinkProperties("Name", "IsValid");
		LinkProperties("AutoClearDuration", "DefaultAutoClearDuration");
		LinkProperties("AutoClearEnabled", "AutoClearEnabled");
		LinkProperties("AutoClearEnabled", "AutoClearEnabled");
		LinkProperties("AutoClearDuration", "AutoClearDuration");
		LinkProperties("AutoClearFollowsPropDuration", "AutoClearFollowsPropDuration");
		LinkProperties("TriggerType", "PropTriggerType");
	}

	public void AssignPropSource(IPropSource? propSource)
	{
		if (_propSource != null)
		{
			_propSource.PropPropertyChanged -= Prop_PropertyChanged;
		}
		_propSource = propSource;
		if (_propSource != null)
		{
			_propSource.PropPropertyChanged += Prop_PropertyChanged;
		}
		OnPropCueChanged();
	}

	private void Prop_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is IPropCue propCue && propCue.ID == PropID && e.PropertyName == "Name")
		{
			PropIdentification = PropIdentification with
			{
				Name = propCue.Name,
				ParentId = propCue.ParentCollectionID,
				ParentName = propCue.ParentCollectionName
			};
			if (AutoClearFollowsPropDuration)
			{
				AutoClearDuration = propCue.SlideAction?.AutoClearDuration ?? 0.0;
			}
		}
		RaiseLinkedValues(sender, e);
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new PropAction(_propSource));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is PropAction propAction)
		{
			propAction.SetIdentifier(PropID, PropName, Guid.Empty, string.Empty, ProPresenter.DO.Props.PropTrigger.Trigger);
			propAction.PropTrigger = _propTrigger.Clone();
		}
		return base.CopyProperties(action);
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Prop = new Pro.SerializationInterop.RVProtoData.Action.Types.PropType
		{
			Identification = new CollectionElementType
			{
				ParameterUuid = PropID.ToUUID(),
				ParameterName = (PropName ?? string.Empty),
				ParentCollection = new CollectionElementType
				{
					ParameterUuid = PropParentCollectionID.ToUUID(),
					ParameterName = (PropParentCollectionName ?? string.Empty)
				}
			}
		};
		_propTrigger.Serialize(action);
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (data != null && data.Prop != null)
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.PropType prop = data.Prop;
			PropTrigger = prop.TriggerTypeCase switch
			{
				Pro.SerializationInterop.RVProtoData.Action.Types.PropType.TriggerTypeOneofCase.Trigger => new PropActionTrigger(), 
				Pro.SerializationInterop.RVProtoData.Action.Types.PropType.TriggerTypeOneofCase.Clear => new PropActionClear(), 
				_ => new PropActionTrigger(), 
			};
			PropTrigger.Deserialize(data);
			PropIdentification = new Identification(prop.Identification.ParameterUuid?.ToGuid() ?? Guid.Empty, prop.Identification.ParameterName, prop.Identification.ParentCollection?.ParameterUuid?.ToGuid() ?? Guid.Empty, prop.Identification.ParentCollection?.ParameterName ?? string.Empty);
			OnPropCueChanged();
		}
	}

	void IActionDataIdentifier.SetIdentifier(Guid id, string name)
	{
		SetIdentifier(id, name, Guid.Empty, string.Empty, ProPresenter.DO.Props.PropTrigger.Trigger);
	}

	public void SetIdentifier(Guid id, string name, Guid parentCollectionID, string parentCollectionName, PropTrigger? propTrigger = ProPresenter.DO.Props.PropTrigger.Trigger)
	{
		Guid oldID = PropID;
		string oldName = PropName;
		Guid oldParentCollectionID = PropParentCollectionID;
		string oldParentCollectionName = PropParentCollectionName;
		PropTrigger oldPropTrigger = ((PropTriggerType == PropTriggerType.Clear) ? ProPresenter.DO.Props.PropTrigger.Clear : ProPresenter.DO.Props.PropTrigger.Trigger);
		base.UndoStack?.Commit(UndoActionTypes.ActionSetProp.ToAction(), delegate
		{
			set(oldID, oldName, oldParentCollectionID, oldParentCollectionName, oldPropTrigger);
		}, delegate
		{
			set(id, name, parentCollectionID, parentCollectionName, propTrigger);
		}, null, null, autoFinalize: true);
		set(id, name, parentCollectionID, parentCollectionName, propTrigger);
		void set(Guid id, string name, Guid parentCollectionID, string parentCollectionName, PropTrigger? propTrigger)
		{
			PropIdentification = new Identification(id, name, parentCollectionID, parentCollectionName);
			if (propTrigger.HasValue && propTrigger == ProPresenter.DO.Props.PropTrigger.Clear)
			{
				ChangeTriggerType(PropTriggerType.Clear);
			}
			OnPropertyChanged("PropName");
			OnPropCueChanged();
		}
	}

	private void OnPropCueChanged()
	{
		if (_propCue != null)
		{
			_propCue.PropertyChanged -= base.RaiseLinkedValues;
			if (_propCue.SlideAction != null)
			{
				_propCue.SlideAction.PropertyChanged -= base.RaiseLinkedValues;
			}
		}
		_propCue = _propSource?.FindProp(PropIdentification.Id, PropIdentification.Name, PropIdentification.ParentId, PropIdentification.ParentName);
		if (_propCue != null)
		{
			_propCue.PropertyChanged += base.RaiseLinkedValues;
			if (_propCue.SlideAction != null)
			{
				_propCue.SlideAction.PropertyChanged += base.RaiseLinkedValues;
			}
			if (AutoClearFollowsPropDuration)
			{
				AutoClearDuration = _propCue.SlideAction?.AutoClearDuration ?? 0.0;
			}
		}
	}
}
