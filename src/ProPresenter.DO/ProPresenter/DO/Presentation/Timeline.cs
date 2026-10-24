using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Presentation;

public class Timeline : ImmutableObservableCollection<TimelineItemInfo>, IActionRepository
{
	private readonly IApp _app;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private TimeSlice _duration = TimeSlice.FromSeconds(300.0);

	private bool _isSetToLoop;

	private TimeSlice _timecodeOffset;

	private bool _isTimecodeEnabled;

	public TimeSlice Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			if (value <= TimeSlice.Zero)
			{
				value = TimeSlice.FromSeconds(300.0);
			}
			SetValue("Duration", ref _duration, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack.Commit(UndoActionTypes.TimelineDuration.ToAction(), this, "Duration", o, n);
				OnDataModified();
			});
		}
	}

	public bool IsSetToLoop
	{
		get
		{
			return _isSetToLoop;
		}
		set
		{
			SetValue("IsSetToLoop", ref _isSetToLoop, value, delegate(bool o, bool n)
			{
				UndoStack.Commit(UndoActionTypes.TimelineSetToLoop.ToAction(), this, "IsSetToLoop", o, n);
				OnDataModified();
			});
		}
	}

	public bool IsTimecodeEnabled
	{
		get
		{
			return _isTimecodeEnabled;
		}
		set
		{
			SetValue("IsTimecodeEnabled", ref _isTimecodeEnabled, value, (Action<bool, bool>?)delegate
			{
				OnDataModified();
			});
		}
	}

	public TimeSlice TimecodeOffset
	{
		get
		{
			return _timecodeOffset;
		}
		set
		{
			SetValue("TimecodeOffset", ref _timecodeOffset, value, OnDataModified);
		}
	}

	public PresentationBase Presentation { get; }

	public UndoStack UndoStack => Presentation.UndoStack;

	public IEnumerable<Pro.DO.Triggering.IAction> Actions => (from i in base.Collection
		where i.Item.TimelineItemType == TimelineItemType.Actions
		select i.Item as Pro.DO.Triggering.IAction).NonNull();

	public event Action<Timeline>? DataModified;

	public ObjectBinder<Timeline, Pro.Entity.IPresentation.Types.ITimeline> Bind(IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, Pro.Entity.IPresentation.Types.ITimeline right)
	{
		ObjectBinder<Timeline, Pro.Entity.IPresentation.Types.ITimeline> objectBinder = new ObjectBinder<Timeline, Pro.Entity.IPresentation.Types.ITimeline>(this, right);
		objectBinder.Bind((Timeline l) => l.WhenPropertyChanges("Duration"), (Pro.Entity.IPresentation.Types.ITimeline r) => r.Duration.WhenValueChanges, delegate(Timeline l, Pro.Entity.IPresentation.Types.ITimeline r)
		{
			r.Duration.Set(l.Duration.TotalSeconds);
		}, delegate(Pro.Entity.IPresentation.Types.ITimeline r, Timeline l)
		{
			l.Duration = TimeSlice.FromSeconds(r.Duration.Value);
		}).Bind((Timeline l) => l.WhenPropertyChanges("IsSetToLoop"), (Pro.Entity.IPresentation.Types.ITimeline r) => r.Loop.WhenValueChanges, delegate(Timeline l, Pro.Entity.IPresentation.Types.ITimeline r)
		{
			r.Loop.Set(l.IsSetToLoop);
		}, delegate(Pro.Entity.IPresentation.Types.ITimeline r, Timeline l)
		{
			l.IsSetToLoop = r.Loop.Value;
		}).Bind((Timeline l) => l.WhenPropertyChanges("IsTimecodeEnabled"), (Pro.Entity.IPresentation.Types.ITimeline r) => r.TimecodeEnable.WhenValueChanges, delegate(Timeline l, Pro.Entity.IPresentation.Types.ITimeline r)
		{
			r.TimecodeEnable.Set(l.IsTimecodeEnabled);
		}, delegate(Pro.Entity.IPresentation.Types.ITimeline r, Timeline l)
		{
			l.IsTimecodeEnabled = r.TimecodeEnable.Value;
		})
			.Bind((Timeline l) => l.WhenPropertyChanges("TimecodeOffset"), (Pro.Entity.IPresentation.Types.ITimeline r) => r.TimecodeOffset.WhenValueChanges, delegate(Timeline l, Pro.Entity.IPresentation.Types.ITimeline r)
			{
				r.TimecodeOffset.Set(l.TimecodeOffset.TotalSeconds);
			}, delegate(Pro.Entity.IPresentation.Types.ITimeline r, Timeline l)
			{
				l.TimecodeOffset = TimeSlice.FromSeconds(r.TimecodeOffset.Value);
			})
			.Bind((Timeline l) => l.WhenCollectionChanges(), (Pro.Entity.IPresentation.Types.ITimeline r) => r.CuesV2.WhenCollectionChanges, delegate(Timeline l, Pro.Entity.IPresentation.Types.ITimeline r)
			{
				r.CuesV2.SynchronizeFrom(l, AreTimelineItemEqual, delegate(TimelineItemInfo m)
				{
					Pro.Entity.IPresentation.Types.ITimeline.Types.ICue cue = CreateTimelineItemEntity(entityFactory, actionBinderFactory, m);
					ObjectBinder<TimelineItemInfo, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue> objectBinder2 = m.Bind(cue);
					objectBinder2.InitializeRightFromLeft();
					cue.RegisterLinkedDisposable(objectBinder2);
					return cue;
				});
			}, delegate(Pro.Entity.IPresentation.Types.ITimeline r, Timeline l)
			{
				r.CuesV2.Items.SynchronizeTo(l.Collection, (Pro.Entity.IPresentation.Types.ITimeline.Types.ICue e, TimelineItemInfo m) => AreTimelineItemEqual(m, e), delegate(Pro.Entity.IPresentation.Types.ITimeline.Types.ICue e, int i)
				{
					ObjectBinder<TimelineItemInfo, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue> objectBinder3 = CreateTimelineItem(l, actionBinderFactory, e).Bind(e);
					objectBinder3.InitializeLeftFromRight();
					e.RegisterLinkedDisposable(objectBinder3);
				}, l.Collection.Move, delegate(int i)
				{
					TimelineItemInfo timelineItemInfo = l.Collection.ElementAtOrDefault(i);
					if (timelineItemInfo != null)
					{
						l.RemoveItem(timelineItemInfo);
					}
				});
			});
		return objectBinder;
	}

	private static Pro.Entity.IPresentation.Types.ITimeline.Types.ICue CreateTimelineItemEntity(IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, TimelineItemInfo l)
	{
		Pro.Entity.IPresentation.Types.ITimeline.Types.ICue cue = entityFactory.Create<Pro.Entity.IPresentation.Types.ITimeline.Types.ICue>();
		switch (l.Item.TimelineItemType)
		{
		case TimelineItemType.Slide:
		{
			Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId cueId = entityFactory.Create<Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId>();
			cueId.Set(l.Item.ID);
			cue.TriggerInfo.Set(cueId);
			break;
		}
		case TimelineItemType.VisualMedia:
		case TimelineItemType.AudioMedia:
		case TimelineItemType.Actions:
			if (l.Item is Pro.DO.Triggering.IAction left)
			{
				Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction action = entityFactory.Create<Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction>();
				Pro.Entity.IAction action2 = entityFactory.Create<Pro.Entity.IAction>();
				action.Set(action2);
				IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> readOnlyObjectBinder = actionBinderFactory.CreateBinder(left, action2);
				readOnlyObjectBinder.InitializeRightFromLeft();
				action.RegisterLinkedDisposable(readOnlyObjectBinder);
				cue.TriggerInfo.Set(action);
			}
			break;
		}
		return cue;
	}

	private static TimelineItemInfo CreateTimelineItem(Timeline timeline, IActionBinderFactory actionBinderFactory, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue entity)
	{
		Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo value = entity.TriggerInfo.Value;
		Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId cueTrigger = value as Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId;
		if (cueTrigger != null)
		{
			SlideCue slideCue = timeline.Presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).FirstOrDefault((SlideCue s) => s.ID == cueTrigger.Value);
			if (slideCue != null)
			{
				return timeline.AddItem(slideCue, TimeSlice.FromSeconds(entity.TriggerTime.Value), entity.Name.Value);
			}
		}
		else if (entity.TriggerInfo.Value is Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction action)
		{
			Pro.DO.Triggering.IAction action2 = actionBinderFactory.CreateAction(action.Value, timeline.Presentation.ContainerId);
			action2.UndoStack = timeline.UndoStack;
			if (action2 is MediaAction mediaAction)
			{
				mediaAction.UpdatePropertiesForTimeline();
			}
			if (string.IsNullOrEmpty(action2.Name))
			{
				action2.Name = entity.Name.Value;
			}
			IReadOnlyObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> readOnlyObjectBinder = actionBinderFactory.CreateBinder(action2, action.Value);
			readOnlyObjectBinder.InitializeLeftFromRight();
			action.RegisterLinkedDisposable(readOnlyObjectBinder);
			if (action2 is ITimelineItem item)
			{
				return timeline.AddItem(item, TimeSlice.FromSeconds(entity.TriggerTime.Value), entity.Name.Value);
			}
		}
		throw new InvalidOperationException($"Unknown type {entity.TriggerInfo.Value.GetType()}");
	}

	private static bool AreTimelineItemEqual(TimelineItemInfo model, Pro.Entity.IPresentation.Types.ITimeline.Types.ICue entity)
	{
		if (entity.TriggerInfo.Value is Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.ICueId cueId)
		{
			return cueId.Value == model.Item.ID;
		}
		if (entity.TriggerInfo.Value is Pro.Entity.IPresentation.Types.ITimeline.Types.ICue.Types.ITriggerInfo.IAction action)
		{
			return action.Value.Uuid.Value == model.Item.ID;
		}
		return false;
	}

	public Timeline(PresentationBase presentation, IApp app, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		Presentation = presentation;
		_app = app;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
	}

	public Timeline(Timeline other, PresentationBase presentation)
		: this(presentation, other._app, other._mediaFactory, other._transitionDescriptions)
	{
		_duration = other.Duration;
		_isSetToLoop = other.IsSetToLoop;
	}

	public void AddItem(TimelineItemInfo item)
	{
		if (item.Item.TimelineItemType != 0 || Presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).Contains(item.Item))
		{
			item.DataModified += OnDataModified;
			OnInsert(item);
		}
	}

	public TimelineItemInfo AddItem(ITimelineItem item, TimeSlice slideTime, string? name)
	{
		TimelineItemInfo itemInfo = new TimelineItemInfo(item, slideTime, name ?? string.Empty, this);
		UndoStack.Commit(UndoActionTypes.TimelineAddItem.ToAction(), delegate
		{
			RemoveItem(itemInfo);
		}, delegate
		{
			AddItem(itemInfo);
		}, null, null, autoFinalize: true);
		AddItem(itemInfo);
		return itemInfo;
	}

	private void AddItems(IEnumerable<TimelineItemInfo> items)
	{
		items.ForEach(AddItem);
	}

	public void InsertItems(IEnumerable<TimelineItemInfo> items, int index)
	{
		items.ForEach(delegate(TimelineItemInfo i)
		{
			OnInsert(i, index++);
		});
	}

	private void OnInsert(TimelineItemInfo item, int index = -1)
	{
		index = ((index == -1) ? base.Collection.Count : index);
		base.Collection.Insert(index, item);
		OnDataModified();
	}

	private void RemoveItem(TimelineItemInfo item)
	{
		if (base.Collection.Contains(item))
		{
			item.DataModified -= OnDataModified;
			base.Collection.Remove(item);
			OnDataModified();
		}
	}

	public void RemoveItems(IEnumerable<TimelineItemInfo> items)
	{
		TimelineItemInfo[] itemsToDelete = items.ToArray();
		UndoStack.Commit(UndoActionTypes.TimelineRemoteItem.ToAction(), delegate
		{
			itemsToDelete.ForEach(AddItem);
		}, delegate
		{
			itemsToDelete.ForEach(RemoveItem);
		}, null, null, autoFinalize: true);
		items.ForEach(RemoveItem);
	}

	public void RemoveItems(IEnumerable<ITimelineItem> slides)
	{
		TimelineItemInfo[] toRemove = base.Items.Where((TimelineItemInfo i) => slides.Contains(i.Item)).ToArray();
		UndoStack undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.Commit(delegate
			{
				AddItems(toRemove);
			}, delegate
			{
				RemoveItems(toRemove);
			});
		}
		RemoveItems(toRemove);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline timeline = new Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline
		{
			Duration = Duration.TotalSeconds,
			Loop = IsSetToLoop,
			TimecodeEnable = IsTimecodeEnabled,
			TimecodeOffset = TimecodeOffset.TotalSeconds
		};
		foreach (TimelineItemInfo item in base.Items)
		{
			Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue cue = new Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue
			{
				TriggerTime = item.SlideTime.TotalSeconds,
				Name = (item.Name ?? string.Empty)
			};
			switch (item.Item.TimelineItemType)
			{
			case TimelineItemType.Slide:
				cue.CueId = item.ID.ToUUID();
				break;
			case TimelineItemType.VisualMedia:
			case TimelineItemType.AudioMedia:
			case TimelineItemType.Actions:
				if (item.Item is Pro.DO.Triggering.IAction action)
				{
					cue.Action = action.Serialize();
				}
				break;
			}
			timeline.CuesV2.Add(cue);
			if (item.Item.TimelineItemType.IsAnyOf(TimelineItemType.Slide, TimelineItemType.VisualMedia))
			{
				timeline.Cues.Add(cue);
			}
		}
		timeline.AudioAction = base.Items.Select((TimelineItemInfo i) => i.Item).OfType<MediaAction>().FirstOrDefault((MediaAction m) => m.IsAudioMedia)?.Serialize();
		return timeline;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline data, ApplicationData? applicationData, string containerId)
	{
		if (data == null)
		{
			return;
		}
		UndoStack?.StartIgnoring();
		Duration = ((data.Duration == 0.0) ? Duration : TimeSlice.FromSeconds(data.Duration));
		IsSetToLoop = data.Loop;
		IsTimecodeEnabled = data.TimecodeEnable;
		TimecodeOffset = TimeSlice.FromSeconds(data.TimecodeOffset);
		base.Items.Clear();
		IEnumerable<Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue> enumerable = Array.Empty<Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue>();
		if (!data.CuesV2.Empty())
		{
			enumerable = data.CuesV2;
		}
		else if (!data.Cues.Empty() || data.AudioAction != null)
		{
			enumerable = data.Cues;
			if (data.AudioAction != null)
			{
				MediaAction mediaAction = MediaAction.ConstructMediaAction(data.AudioAction, _app, _mediaFactory, _transitionDescriptions, containerId);
				mediaAction.Deserialize(data.AudioAction, applicationData, containerId);
				mediaAction.UpdatePropertiesForTimeline();
				AddItem(mediaAction, TimeSlice.Zero, mediaAction.Name);
			}
		}
		if (enumerable != null && enumerable.Any())
		{
			IEnumerable<SlideCue> source = Presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues);
			foreach (Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue protoTimelineCue in enumerable)
			{
				switch (protoTimelineCue.TriggerInfoCase)
				{
				case Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue.TriggerInfoOneofCase.CueId:
				{
					SlideCue slideCue = source.FirstOrDefault((SlideCue s) => s.ID == protoTimelineCue.CueId.ToGuid());
					if (slideCue != null && slideCue.Type == CueType.Slide)
					{
						AddItem(slideCue, TimeSlice.FromSeconds(protoTimelineCue.TriggerTime), protoTimelineCue.Name);
					}
					break;
				}
				case Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline.Types.Cue.TriggerInfoOneofCase.Action:
					if (protoTimelineCue.Action != null)
					{
						Pro.DO.Triggering.IAction action = protoTimelineCue.Action.Type.ToActionType().ConstructAction(protoTimelineCue.Action, containerId);
						if (UndoStack != null)
						{
							action.UndoStack = UndoStack;
						}
						action.Deserialize(protoTimelineCue.Action, new ApplicationData(ApplicationType.ProPresenter), containerId);
						if (action is MediaAction mediaAction2)
						{
							mediaAction2.UpdatePropertiesForTimeline();
						}
						if (string.IsNullOrEmpty(action.Name))
						{
							action.Name = protoTimelineCue.Name;
						}
						if (action is ITimelineItem item)
						{
							AddItem(item, TimeSlice.FromSeconds(protoTimelineCue.TriggerTime), protoTimelineCue.Name);
						}
					}
					break;
				}
			}
		}
		UndoStack?.StopIgnoring();
	}

	public bool CanAddAction(object data)
	{
		return true;
	}

	public bool CanReplace(object data)
	{
		return true;
	}

	public void AddAction(Pro.DO.Triggering.IAction action, bool addMediaReferences = false)
	{
		if (action is ITimelineItem item)
		{
			AddItem(item, TimeSlice.Zero, action.Name);
		}
	}

	public void RemoveAction(Pro.DO.Triggering.IAction action)
	{
		TimelineItemInfo timelineItemInfo = base.Collection.FirstOrDefault((TimelineItemInfo i) => i.Item is Pro.DO.Triggering.IAction action2 && action2 == action);
		if (timelineItemInfo != null)
		{
			RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<TimelineItemInfo>(timelineItemInfo));
		}
	}

	public void RemoveActions(IEnumerable<Pro.DO.Triggering.IAction> actions)
	{
		TimelineItemInfo[] items = actions.Select((Pro.DO.Triggering.IAction a) => base.Collection.FirstOrDefault((TimelineItemInfo i) => i.Item is Pro.DO.Triggering.IAction action && action == a)).NonNull().ToArray();
		RemoveItems(items);
	}

	public bool CanAssign(object data, Pro.DO.Triggering.IAction? action)
	{
		return this.CanAssignData(data, action);
	}

	public void InsertActions(IEnumerable<Pro.DO.Triggering.IAction> actions, int index, bool addMediaReferences = false)
	{
		TimelineItemInfo[] items = (from a in actions.OfType<ITimelineItem>()
			select new TimelineItemInfo(a, TimeSlice.Zero, a.Name, this)).ToArray();
		InsertItems(items, index);
	}
}
