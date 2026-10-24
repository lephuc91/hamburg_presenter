using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Reversibility;
using Pro.DO.Triggering.CompletionTargets;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public class Cue : LinkedNotifyPropertyChangedBase, ICloneable<Cue>, IIdentifiable, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private Guid _id;

	private string _name = string.Empty;

	private bool _isEnabled = true;

	private CompletionAction _completionAction = CompletionAction.Last;

	private IAction? _actionTarget;

	private CompletionTargetBase _completionTarget = new NoTarget();

	private TimeSlice _triggerTime = TimeSlice.Zero;

	private TimeSlice _completionTime = TimeSlice.Zero;

	private Hotkey? _hotkey;

	private UndoStack? _undoStack;

	public Guid ID
	{
		get
		{
			if (!(_id == Guid.Empty))
			{
				return _id;
			}
			throw new InvalidOperationException("Cue ID empty");
		}
		protected set
		{
			_id = ((value != Guid.Empty) ? value : _id);
		}
	}

	public virtual UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			if (value != null)
			{
				Actions.UndoStack = value;
			}
		}
	}

	public virtual string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.CueName), this, "Name", o, n, null, null, autoFinalize: true);
				OnNameChanged(o, n);
				OnDataModified();
			});
		}
	}

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			SetValue("IsEnabled", ref _isEnabled, value, delegate(bool o, bool n)
			{
				OnIsEnabledChanged(o, n);
				OnDataModified();
			});
		}
	}

	public CompletionAction CompletionAction
	{
		get
		{
			return _completionAction;
		}
		set
		{
			SetValue("CompletionAction", ref _completionAction, value, delegate(CompletionAction o, CompletionAction n)
			{
				if (n != CompletionAction.AfterAction)
				{
					ActionTarget = null;
				}
				OnCompletionActionChanged(o, n);
				OnDataModified();
			});
		}
	}

	public IAction? ActionTarget
	{
		get
		{
			return _actionTarget;
		}
		set
		{
			if (value != null && !Actions.Contains(value))
			{
				throw new InvalidOperationException();
			}
			SetValue<IAction>("ActionTarget", ref _actionTarget, value, delegate(IAction o, IAction n)
			{
				if (n != null)
				{
					CompletionAction = CompletionAction.AfterAction;
				}
				if (o != null && n != null)
				{
					OnActionTargetChanged(o, n);
				}
				OnDataModified();
			});
		}
	}

	public CompletionTargetBase CompletionTarget
	{
		get
		{
			return _completionTarget;
		}
		set
		{
			SetValue("CompletionTarget", ref _completionTarget, value, delegate(CompletionTargetBase o, CompletionTargetBase n)
			{
				OnCompletionTargetChanged(o, n);
				OnDataModified();
			});
		}
	}

	public TimeSlice TriggerTime
	{
		get
		{
			return _triggerTime;
		}
		set
		{
			if (value < TimeSlice.Zero)
			{
				throw new ArgumentOutOfRangeException($"{"TriggerTime"} with value - {value} should not be less than zero");
			}
			SetValue("TriggerTime", ref _triggerTime, value, delegate(TimeSlice o, TimeSlice n)
			{
				OnTriggerTimeChanged(o, n);
				OnDataModified();
			});
		}
	}

	public TimeSlice CompletionTime
	{
		get
		{
			return _completionTime;
		}
		set
		{
			if (value < TimeSlice.Zero)
			{
				throw new ArgumentOutOfRangeException($"{"CompletionTime"} with value - {value} should not be less than zero");
			}
			SetValue("CompletionTime", ref _completionTime, value, OnDataModified);
		}
	}

	public ActionCollection Actions { get; }

	public Hotkey? Hotkey
	{
		get
		{
			return _hotkey;
		}
		set
		{
			SetValue<Hotkey>("Hotkey", ref _hotkey, value, delegate(Hotkey o, Hotkey n)
			{
				UndoStack?.Commit(UndoActionTypes.AssignHotkey.ToAction(), this, "Hotkey", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public string ContainerId { get; protected set; } = "";

	public event Action<Cue>? DataModified;

	public static ObjectBinder<Cue, ICue> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, Cue left, ICue right)
	{
		ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> actionsBinder = ActionCollection.CreateBinder(scheduler, entityFactory, actionBinderFactory, left.Actions, right.Actions);
		ObjectBinder<Cue, ICue> objectBinder = new ObjectBinder<Cue, ICue>(left, right);
		objectBinder.Bind((Cue l) => l.WhenPropertyChanges("ID"), (ICue r) => r.Uuid.WhenValueChanges, delegate(Cue l, ICue r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(ICue r, Cue l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((Cue l) => l.WhenPropertyChanges("Name"), (ICue r) => r.Name.WhenValueChanges, delegate(Cue l, ICue r)
		{
			r.Name.Set(l.Name);
		}, delegate(ICue r, Cue l)
		{
			l.Name = r.Name?.Value ?? string.Empty;
		}).Bind((Cue l) => l.WhenPropertyChanges("CompletionTarget"), (ICue r) => r.CompletionTargetType.WhenValueChanges.ToUnit().Merge(r.CompletionTargetUuid.WhenValueChanges.ToUnit()), delegate(Cue l, ICue r)
		{
			r.CompletionTargetType.Set(l.CompletionTarget.Type.ToEntityCompletionTargetType());
			r.CompletionTargetUuid.Set((l.CompletionTarget as CueTarget)?.ID);
		}, delegate(ICue r, Cue l)
		{
			l.CompletionTarget = CompletionTargetFactory.GenerateCompletionTarget(r);
		})
			.Bind((Cue l) => l.WhenPropertyChanges("CompletionAction"), (ICue r) => r.CompletionActionType.WhenValueChanges, delegate(Cue l, ICue r)
			{
				r.CompletionActionType.Set(l.CompletionAction.ToEntityCompletionActionType());
			}, delegate(ICue r, Cue l)
			{
				l.CompletionAction = r.CompletionActionType.Value.ToCompletionAction();
			})
			.Bind((Cue l) => l.WhenPropertyChanges("ActionTarget"), (ICue r) => r.CompletionActionUuid.WhenValueChanges, delegate(Cue l, ICue r)
			{
				r.CompletionActionUuid.Set(l.ActionTarget?.ID);
			}, delegate(ICue r, Cue l)
			{
				l.ActionTarget = l.Actions.FirstOrDefault((IAction a) => a.ID == r.CompletionActionUuid.ToGuidOrEmpty());
			})
			.Bind((Cue l) => l.WhenPropertyChanges("Hotkey"), (ICue r) => r.HotKey.WhenValueChanges, delegate(Cue l, ICue r)
			{
				IHotKey hotKey = entityFactory.Create<IHotKey>();
				ObjectBinder<Hotkey, IHotKey> objectBinder2 = Pro.DO.Hotkey.CreateBinder(l.Hotkey, hotKey);
				objectBinder2.InitializeRightFromLeft();
				hotKey.RegisterLinkedDisposable(objectBinder2);
				r.HotKey.Set(hotKey);
			}, delegate(ICue r, Cue l)
			{
				ObjectBinder<Hotkey, IHotKey> objectBinder3 = Pro.DO.Hotkey.CreateBinder(l.Hotkey, r.HotKey.Value);
				objectBinder3.InitializeLeftFromRight();
				r.HotKey.Value.RegisterLinkedDisposable(objectBinder3);
			})
			.Bind((Cue l) => l.WhenPropertyChanges("IsEnabled"), (ICue r) => r.IsEnabled.WhenValueChanges, delegate(Cue l, ICue r)
			{
				r.IsEnabled.Set(l.IsEnabled);
			}, delegate(ICue r, Cue l)
			{
				l.IsEnabled = r.IsEnabled.Value;
			})
			.Bind((Cue l) => l.WhenPropertyChanges("CompletionTime"), (ICue r) => r.CompletionTime.WhenValueChanges, delegate(Cue l, ICue r)
			{
				r.CompletionTime.Set(l.CompletionTime.TotalSeconds);
			}, delegate(ICue r, Cue l)
			{
				l.CompletionTime = TimeSlice.FromSeconds(r.CompletionTime.Value);
			})
			.DoOnInitializeRightFromLeft(actionsBinder.InitializeRightFromLeft)
			.DoOnInitializeLeftFromRight(actionsBinder.InitializeLeftFromRight)
			.RegisterChildDisposable(() => actionsBinder);
		return objectBinder;
	}

	public Cue(bool newID = true)
	{
		ID = (newID ? Guid.NewGuid() : Guid.Empty);
		Actions = new ActionCollection(CanRemoveAction);
		Actions.DataModified += OnDataModified;
		Actions.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	protected virtual bool CanRemoveAction(IAction action)
	{
		return true;
	}

	protected virtual void OnNameChanged(string oldName, string newName)
	{
	}

	protected virtual void OnIsEnabledChanged(bool oldValue, bool newValue)
	{
	}

	protected virtual void OnCompletionActionChanged(CompletionAction oldCompletionAction, CompletionAction newCompletionAction)
	{
	}

	protected virtual void OnActionTargetChanged(IAction oldAction, IAction newAction)
	{
	}

	protected virtual void OnCompletionTargetChanged(CompletionTargetBase oldCompletionTarget, CompletionTargetBase newCompletionTarget)
	{
	}

	protected virtual void OnTriggerTimeChanged(TimeSlice oldTime, TimeSlice newTime)
	{
	}

	protected virtual void OnInsertAction(bool userInitiated, IAction action, bool addMediaReferences = false)
	{
	}

	protected virtual void OnRemoveAction(IAction action)
	{
	}

	public void AddAction(IAction action, bool addMediaReferences = false)
	{
		AddActions(new global::_003C_003Ez__ReadOnlySingleElementList<IAction>(action), addMediaReferences);
	}

	public void AddActions(IEnumerable<IAction> actions, bool addMediaReferences = false)
	{
		InsertActions(actions, Actions.Count, addMediaReferences);
	}

	public void InsertAction(IAction action, int index, bool addMediaReferences = false)
	{
		InsertActions(new global::_003C_003Ez__ReadOnlySingleElementList<IAction>(action), index, addMediaReferences);
	}

	public void InsertActions(IEnumerable<IAction> actions, int index, bool addMediaReferences = false)
	{
		using (UndoStack?.Transaction(UndoActionTypes.AddAction.ToAction(), null, null, autoFinalize: true))
		{
			UndoStack undoStack = UndoStack;
			actions = actions.NonNull().ToArray();
			int num = index;
			foreach (IAction action in actions)
			{
				Actions.Insert(action, Actions.ClampIndexExclusive(num++));
				OnInsertAction(userInitiated: true, action, addMediaReferences);
			}
			if (undoStack != null)
			{
				UndoStack?.Commit(delegate
				{
					RemoveActions(actions);
				}, delegate
				{
					InsertActions(actions, index, addMediaReferences: true);
				});
			}
		}
	}

	public void ClearActions()
	{
		RemoveActions(Actions.ToArray());
	}

	public void RemoveAction(IAction action)
	{
		RemoveActions(new global::_003C_003Ez__ReadOnlySingleElementList<IAction>(action));
	}

	public void RemoveActions(IEnumerable<IAction> actions)
	{
		if (!actions.Any())
		{
			return;
		}
		UndoStack?.BeginCommit(UndoActionTypes.RemoveAction.ToAction());
		var originalValues = actions.Select((IAction a) => new
		{
			Action = a,
			Index = Actions.IndexOf(a)
		}).ToArray();
		foreach (IAction action in actions)
		{
			if (Actions.Remove(action))
			{
				OnRemoveAction(action);
			}
		}
		UndoStack?.Commit(delegate
		{
			originalValues.ForEach(v =>
			{
				InsertAction(v.Action, v.Index);
			});
		}, delegate
		{
			RemoveActions(actions);
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public virtual void Deserialize(Pro.SerializationInterop.RVProtoData.Cue data, ApplicationData? applicationData, string containerId)
	{
		ID = data.Uuid.ToGuid();
		UpdateContainerId(containerId);
		Name = data.Name;
		IsEnabled = data.IsEnabled;
		Actions.Deserialize(data, applicationData, containerId);
		CompletionTarget = CompletionTargetFactory.GenerateCompletionTarget(data);
		CompletionAction = data.CompletionActionType.ToCompletionAction();
		if (data.TriggerTime != null)
		{
			TriggerTime = TimeSlice.FromSeconds(data.TriggerTime.Time);
		}
		if (CompletionAction == CompletionAction.AfterTime)
		{
			CompletionTime = TimeSlice.FromSeconds(data.CompletionTime);
		}
		if (data.CompletionActionUuid != null)
		{
			ActionTarget = Actions.FirstOrDefault((IAction a) => a.ID == data.CompletionActionUuid.ToGuid());
		}
		if (data.HotKey != null)
		{
			DeserializeHotkey(data.HotKey.Code.ToKey());
		}
	}

	protected virtual void DeserializeHotkey(Key? key)
	{
	}

	public Pro.SerializationInterop.RVProtoData.Cue Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Cue cue = new Pro.SerializationInterop.RVProtoData.Cue
		{
			Uuid = ID.ToUUID(),
			Name = (Name ?? string.Empty),
			CompletionTargetType = (CompletionTarget?.Type.ToProtoCompletionTargetType() ?? Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next),
			CompletionTargetUuid = ((CompletionTarget as CueTarget)?.ID ?? Guid.Empty).ToUUID(),
			CompletionActionType = CompletionAction.ToProtoCompletionActionType(),
			CompletionActionUuid = (ActionTarget?.ID ?? Guid.Empty).ToUUID(),
			TriggerTime = new Pro.SerializationInterop.RVProtoData.Cue.Types.TimecodeTime
			{
				Time = TriggerTime.TotalSeconds
			},
			CompletionTime = CompletionTime.TotalSeconds,
			HotKey = Hotkey?.Serialize(),
			IsEnabled = IsEnabled
		};
		Actions.Serialize(cue);
		return cue;
	}

	public virtual Cue Clone()
	{
		return CopyProperties(new Cue());
	}

	protected Cue CopyProperties(Cue cue)
	{
		cue._name = _name;
		cue._completionAction = _completionAction;
		cue._actionTarget = _actionTarget;
		cue._completionTarget = _completionTarget;
		cue._triggerTime = _triggerTime;
		cue._isEnabled = _isEnabled;
		cue.UpdateContainerId(ContainerId);
		cue.AddActions(Actions.Select((IAction a) => a.Clone()));
		return cue;
	}

	public virtual void UpdateContainerId(string newContainerId)
	{
		ContainerId = newContainerId;
		Actions.UpdateContainerId(newContainerId);
	}
}
