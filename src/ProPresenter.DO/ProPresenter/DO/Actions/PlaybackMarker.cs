using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public class PlaybackMarker : ObservableObject, IPlaybackMarker, INotifyPropertyChanged, IActionRepository, ICloneable<IPlaybackMarker>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private readonly IActionGateway _validator;

	private ActionCollection _actions = new ActionCollection();

	[ObservableProperty]
	private Guid _iD = Guid.NewGuid();

	[ObservableProperty]
	private TimeSlice _timestamp = TimeSlice.Zero;

	[ObservableProperty]
	private TimeSlice _visualTimestamp;

	[ObservableProperty]
	private System.Windows.Media.Color _color;

	[ObservableProperty]
	private string _name = string.Empty;

	[ObservableProperty]
	private UndoStack? _undoStack;

	public INotifyEnumerableChanged<Pro.DO.Triggering.IAction> Actions => _actions;

	IEnumerable<Pro.DO.Triggering.IAction> IActionRepository.Actions => _actions;

	public string ContainerId { get; private set; } = "";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guid ID
	{
		get
		{
			return _iD;
		}
		set
		{
			if (!EqualityComparer<Guid>.Default.Equals(_iD, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ID);
				_iD = value;
				OnIDChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ID);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSlice Timestamp
	{
		get
		{
			return _timestamp;
		}
		set
		{
			if (!EqualityComparer<TimeSlice>.Default.Equals(_timestamp, value))
			{
				TimeSlice timestamp = _timestamp;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Timestamp);
				_timestamp = value;
				OnTimestampChanged(timestamp, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Timestamp);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSlice VisualTimestamp
	{
		get
		{
			return _visualTimestamp;
		}
		set
		{
			if (!EqualityComparer<TimeSlice>.Default.Equals(_visualTimestamp, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.VisualTimestamp);
				_visualTimestamp = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.VisualTimestamp);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			if (!EqualityComparer<System.Windows.Media.Color>.Default.Equals(_color, value))
			{
				System.Windows.Media.Color color = _color;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Color);
				_color = value;
				OnColorChanged(color, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Color);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				string name = _name;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnNameChanged(name, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			if (!EqualityComparer<Pro.Common.Components.Reversibility.UndoStack>.Default.Equals(_undoStack, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UndoStack);
				_undoStack = value;
				OnUndoStackChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UndoStack);
			}
		}
	}

	public event System.Action? DataModified;

	public event System.Action? TimestampChanged;

	public IReadOnlyObjectBinder<IPlaybackMarker, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> Bind(IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, IEntityFactory entityFactory, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker right)
	{
		ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> actionsBinder = ActionCollection.CreateBinder(scheduler, entityFactory, actionBinderFactory, _actions, right.Actions);
		ObjectBinder<PlaybackMarker, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> objectBinder = new ObjectBinder<PlaybackMarker, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker>(this, right);
		objectBinder.Bind((PlaybackMarker l) => l.WhenPropertyChanges("ID"), (Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r) => r.Uuid.WhenValueChanges, delegate(PlaybackMarker l, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r, PlaybackMarker l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((PlaybackMarker l) => l.WhenPropertyChanges("Name"), (Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r) => r.Name.WhenValueChanges, delegate(PlaybackMarker l, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r)
		{
			r.Name.Set(l.Name);
		}, delegate(Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r, PlaybackMarker l)
		{
			l.Name = r.Name.Value ?? string.Empty;
		}).Bind((PlaybackMarker l) => l.WhenPropertyChanges("Color"), (Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r) => r.Color.WhenValueChanges, delegate(PlaybackMarker l, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r)
		{
			r.Color.Set(l.Color.ToEntityColor());
		}, delegate(Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r, PlaybackMarker l)
		{
			l.Color = r.Color.Value.ToColor();
		})
			.Bind((PlaybackMarker l) => l.WhenPropertyChanges("Timestamp"), (Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r) => r.Time.WhenValueChanges, delegate(PlaybackMarker l, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r)
			{
				r.Time.Set(l.Timestamp.TotalSeconds);
			}, delegate(Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker r, PlaybackMarker l)
			{
				l.Timestamp = TimeSlice.FromSeconds(r.Time.Value);
			})
			.RegisterChildDisposable(() => actionsBinder)
			.DoOnInitializeLeftFromRight(actionsBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(actionsBinder.InitializeRightFromLeft);
		return objectBinder;
	}

	public PlaybackMarker(IActionGateway? actionValidator = null)
	{
		_validator = actionValidator ?? new ActionGateway(_actions);
		_actions.DataModified += OnDataModified;
		_actions.CollectionChanged += delegate(object? _, NotifyCollectionChangedEventArgs args)
		{
			args.NewItems?.OfType<ICanReceiveMediaContainerIdUpdates>().ForEach(delegate(ICanReceiveMediaContainerIdUpdates x)
			{
				x.UpdateContainerId(ContainerId);
			});
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public IPlaybackMarker Clone()
	{
		PlaybackMarker playbackMarker = new PlaybackMarker
		{
			Timestamp = Timestamp,
			Color = Color,
			Name = Name,
			ContainerId = ContainerId
		};
		Actions.CloneItems().ForEach(playbackMarker._actions.Add);
		return playbackMarker;
	}

	public IPlaybackMarker CloneRelativeTo(TimeSlice inPoint, bool preserveID = false)
	{
		IPlaybackMarker playbackMarker = Clone();
		playbackMarker.Timestamp -= inPoint;
		if (preserveID)
		{
			((PlaybackMarker)playbackMarker).ID = ID;
		}
		return playbackMarker;
	}

	public Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker playbackMarker = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker();
		playbackMarker.Uuid = ID.ToUUID();
		playbackMarker.Time = Timestamp.TotalSeconds;
		playbackMarker.Color = Color.ToProtoColor();
		playbackMarker.Name = Name ?? string.Empty;
		playbackMarker.Actions.AddRange(Actions.Select((Pro.DO.Triggering.IAction a) => a.Serialize()));
		return playbackMarker;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker protoMarker, ApplicationData? applicationData)
	{
		ID = protoMarker.Uuid.ToGuid();
		Timestamp = TimeSlice.FromSeconds(protoMarker.Time);
		Name = protoMarker.Name;
		Color = protoMarker.Color.ToColor();
		_actions.Deserialize(protoMarker.Actions, applicationData, ContainerId);
	}

	public bool CanAddAction(object data)
	{
		if (CanReplace(data))
		{
			return _validator.CanAddAction(data);
		}
		return false;
	}

	public bool CanReplace(object data)
	{
		return true;
	}

	public void AddAction(Pro.DO.Triggering.IAction action, bool addMediaReferences = false)
	{
		AddActions(action.ToEnumerable(), addMediaReferences);
	}

	public void AddActions(IEnumerable<Pro.DO.Triggering.IAction> actions, bool addMediaReferences = false)
	{
		InsertActions(actions, _actions.Count, addMediaReferences);
	}

	public void InsertActions(IEnumerable<Pro.DO.Triggering.IAction> actions, int index, bool addMediaReferences = false)
	{
		UndoStack?.BeginCommit(UndoActionTypes.PlaybackMarkerAddAction.ToAction());
		actions = actions.NonNull().ToArray();
		int num = index;
		foreach (Pro.DO.Triggering.IAction action in actions)
		{
			_actions.Insert(action, _actions.ClampIndexExclusive(num++));
			_validator.HandleIncoming(action, out IEnumerable<Pro.DO.Triggering.IAction> replacements);
			RemoveActions(replacements);
		}
		UndoStack?.Commit(delegate
		{
			RemoveActions(actions);
		}, delegate
		{
			InsertActions(actions, index);
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void RemoveAction(Pro.DO.Triggering.IAction action)
	{
		RemoveActions(action.ToEnumerable());
	}

	public void RemoveActions(IEnumerable<Pro.DO.Triggering.IAction> actions)
	{
		if (actions.Empty())
		{
			return;
		}
		UndoStack?.BeginCommit(UndoActionTypes.PlaybackMarkerRemoveAction.ToAction());
		var originalValues = actions.Select((Pro.DO.Triggering.IAction a) => new
		{
			Action = a,
			Index = Actions.IndexOf(a)
		}).ToArray();
		foreach (Pro.DO.Triggering.IAction action in actions)
		{
			if (_actions.Remove(action))
			{
				_validator.HandleOutgoing(action);
			}
		}
		UndoStack?.Commit(delegate
		{
			originalValues.ForEach(v =>
			{
				InsertActions(v.Action.ToEnumerable(), v.Index);
			});
		}, delegate
		{
			RemoveActions(actions);
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public bool CanAssign(object data, Pro.DO.Triggering.IAction? action)
	{
		return this.CanAssignData(data, action);
	}

	public void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
		Actions.OfType<ICanReceiveMediaContainerIdUpdates>().ForEach(delegate(ICanReceiveMediaContainerIdUpdates a)
		{
			a.UpdateContainerId(containerId);
		});
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIDChanged(Guid value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnTimestampChanged(TimeSlice oldValue, TimeSlice newValue)
	{
		VisualTimestamp = newValue;
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MovePlaybackMarker));
		UndoStack?.Commit(this, "Timestamp", oldValue, newValue);
		UndoStack?.Commit(delegate
		{
			this.TimestampChanged?.Invoke();
		}, delegate
		{
			this.TimestampChanged?.Invoke();
		});
		UndoStack?.EndCommit();
		this.TimestampChanged?.Invoke();
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnColorChanged(System.Windows.Media.Color oldValue, System.Windows.Media.Color newValue)
	{
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.PlaybackMarkerColor), this, "Color", oldValue, newValue);
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnNameChanged(string? oldValue, string newValue)
	{
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.PlaybackMarkerName), this, "Name", oldValue, newValue);
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnUndoStackChanged(UndoStack? value)
	{
		if (value != null && _actions.UndoStack != value)
		{
			_actions.UndoStack = value;
		}
	}
}
