using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.DO.Reversibility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public abstract class ActionBase : LinkedNotifyPropertyChangedBase, IAction, ICloneable<IAction>, INotifyPropertyChanged, IDisposable, IHasMediaContainerId
{
	private string _name = string.Empty;

	private bool _isEnabled = true;

	private TimeSlice _delayTime = TimeSlice.Zero;

	private TimeSlice _duration = TimeSlice.Zero;

	private ActionLabel? _label;

	private UndoStack _undoStack = new UndoStack();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public abstract ActionType ActionType { get; }

	public Guid ID { get; protected set; } = Guid.NewGuid();

	public UndoStack UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			OnUndoStackChanged(value);
		}
	}

	public string Name
	{
		get
		{
			if (!string.IsNullOrEmpty(_name))
			{
				return _name;
			}
			return DefaultName;
		}
		set
		{
			SetValue("Name", ref _name, value, OnDataModified, (string s) => CanRename);
		}
	}

	protected virtual bool CanRename => true;

	protected virtual string DefaultName => string.Empty;

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
				UndoStack.Commit(UndoActionTypes.CueEnabled.ToAction(), this, "IsEnabled", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public TimeSlice DelayTime
	{
		get
		{
			return _delayTime;
		}
		set
		{
			SetValue("DelayTime", ref _delayTime, value, OnDataModified);
		}
	}

	public TimeSlice Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			SetValue("Duration", ref _duration, value, delegate(TimeSlice o, TimeSlice n)
			{
				OnDataModified();
				OnDurationChanged(o, n);
			});
		}
	}

	public ActionLabel? Label
	{
		get
		{
			return _label;
		}
		set
		{
			SetValue("Label", ref _label, value, OnLabelChanged);
		}
	}

	public virtual bool IsValid => true;

	public virtual string ContainerId => "";

	public event System.Action? DataModified;

	public static ObjectBinder<IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IAction? left, Pro.Entity.IAction? right, Action<IAction, Pro.Entity.IAction> onEntityActionTypeChanged)
	{
		return new ObjectBinder<IAction, Pro.Entity.IAction>(left, right).Bind((IAction l) => l.WhenPropertyChanges("ID"), (Pro.Entity.IAction r) => r.Uuid.WhenValueChanges, delegate(IAction l, Pro.Entity.IAction r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(Pro.Entity.IAction r, IAction l)
		{
			((ActionBase)l).ID = r.Uuid.Value;
		}).Bind<Unit, Unit>(null, (Pro.Entity.IAction r) => r.Type.WhenValueChanges.ToUnit().Merge(r.ActionTypeData.WhenValueChanges.ToUnit()), delegate(IAction l, Pro.Entity.IAction r)
		{
			r.Type.Set(l.ActionType.ToEntityActionType());
		}, delegate(Pro.Entity.IAction r, IAction l)
		{
			onEntityActionTypeChanged(l, r);
		}).Bind((IAction l) => l.WhenPropertyChanges("Name"), (Pro.Entity.IAction r) => r.Name.WhenValueChanges, delegate(IAction l, Pro.Entity.IAction r)
		{
			r.Name.Set(l.Name);
		}, delegate(Pro.Entity.IAction r, IAction l)
		{
			l.Name = r.Name.Value;
		})
			.Bind((IAction l) => l.WhenPropertyChanges("IsEnabled"), (Pro.Entity.IAction r) => r.IsEnabled.WhenValueChanges, delegate(IAction l, Pro.Entity.IAction r)
			{
				r.IsEnabled.Set(l.IsEnabled);
			}, delegate(Pro.Entity.IAction r, IAction l)
			{
				l.IsEnabled = r.IsEnabled.Value;
			})
			.Bind((IAction l) => l.WhenPropertyChanges("DelayTime"), (Pro.Entity.IAction r) => r.DelayTime.WhenValueChanges, delegate(IAction l, Pro.Entity.IAction r)
			{
				r.DelayTime.Set(l.DelayTime.TotalSeconds);
			}, delegate(Pro.Entity.IAction r, IAction l)
			{
				l.DelayTime = TimeSlice.FromSeconds(r.DelayTime.Value);
			})
			.Bind((IAction l) => l.WhenPropertyChanges("Duration"), (Pro.Entity.IAction r) => r.Duration.WhenValueChanges, delegate(IAction l, Pro.Entity.IAction r)
			{
				r.Duration.Set(l.Duration.TotalSeconds);
			}, delegate(Pro.Entity.IAction r, IAction l)
			{
				l.Duration = TimeSlice.FromSeconds(r.Duration.Value);
			})
			.Bind((IAction l) => l.WhenPropertyChanges("Label"), (Pro.Entity.IAction r) => r.Label.WhenValueChanges, delegate(IAction l, Pro.Entity.IAction r)
			{
				Pro.Entity.IAction.Types.ILabel label = entityFactory.Create<Pro.Entity.IAction.Types.ILabel>();
				if (l.Label != null)
				{
					ObjectBinder<ILabel, Pro.Entity.IAction.Types.ILabel> objectBinder = CreateLabelBinder(l.Label, label);
					objectBinder.InitializeRightFromLeft();
					label.RegisterLinkedDisposable(objectBinder);
				}
				r.Label.Set(label);
			}, delegate(Pro.Entity.IAction r, IAction l)
			{
				ActionLabel label2 = new ActionLabel(r.Label.Value.Text.Value ?? string.Empty, r.Label.Value.Color.Value?.ToColor());
				l.Label = label2;
				ObjectBinder<ILabel, Pro.Entity.IAction.Types.ILabel> objectBinder2 = CreateLabelBinder(l.Label, r.Label.Value);
				objectBinder2.InitializeLeftFromRight();
				r.Label.Value.RegisterLinkedDisposable(objectBinder2);
			}, null, scheduler.Scheduler);
	}

	private static ObjectBinder<ILabel, Pro.Entity.IAction.Types.ILabel> CreateLabelBinder(ActionLabel left, Pro.Entity.IAction.Types.ILabel right)
	{
		return new ObjectBinder<ILabel, Pro.Entity.IAction.Types.ILabel>(left, right).Bind((ILabel l) => l.WhenPropertyChanges("Text"), (Pro.Entity.IAction.Types.ILabel r) => r.Text.WhenValueChanges, delegate(ILabel l, Pro.Entity.IAction.Types.ILabel r)
		{
			r.Text.Set(l.Text);
		}, delegate(Pro.Entity.IAction.Types.ILabel r, ILabel l)
		{
			l.Text = r.Text.Value ?? string.Empty;
		}).Bind((ILabel l) => l.WhenPropertyChanges("Color"), (Pro.Entity.IAction.Types.ILabel r) => r.Color.WhenValueChanges, delegate(ILabel l, Pro.Entity.IAction.Types.ILabel r)
		{
			r.Color.Set(l.Color?.ToEntityColor());
		}, delegate(Pro.Entity.IAction.Types.ILabel r, ILabel l)
		{
			l.Color = r.Color.Value?.ToColor();
		});
	}

	public virtual Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Action
		{
			Type = ActionType.ToProtoActionType(),
			Uuid = ID.ToUUID(),
			Name = (Name ?? string.Empty),
			IsEnabled = IsEnabled,
			DelayTime = DelayTime.TotalSeconds,
			Duration = Duration.TotalSeconds,
			Label = Label?.Serialize()
		};
	}

	public virtual void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		ID = data.Uuid.ToGuid();
		Name = data.Name;
		IsEnabled = data.IsEnabled;
		DelayTime = TimeSlice.FromSeconds(data.DelayTime);
		Duration = TimeSlice.FromSeconds(data.Duration);
		if (data.Label != null)
		{
			Label = new ActionLabel(data.Label.Text ?? string.Empty, data.Label.Color?.ToColor() ?? Colors.Transparent);
		}
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	protected virtual void OnDurationChanged(TimeSlice oldDuration, TimeSlice newDuration)
	{
	}

	public abstract IAction Clone();

	protected virtual T CopyProperties<T>(T action) where T : ActionBase
	{
		action._name = _name;
		action._isEnabled = _isEnabled;
		action._delayTime = _delayTime;
		action._duration = _duration;
		action.Label = _label?.Clone();
		return action;
	}

	public void CopyAction(IAction dest)
	{
		if (dest is ActionBase action)
		{
			UndoStack.StartIgnoring();
			CopyProperties(action);
			UndoStack.StopIgnoring();
		}
	}

	private void Label_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnDataModified();
	}

	private void OnLabelChanged(ActionLabel? oldValue, ActionLabel? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= Label_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += Label_PropertyChanged;
		}
		OnDataModified();
		UndoStack?.Commit(UndoActionTypes.AssignSlideLabel.ToAction(), this, "Label", oldValue, newValue, null, null, autoFinalize: true);
	}

	protected virtual void OnUndoStackChanged(UndoStack undoStack)
	{
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
		}
	}
}
