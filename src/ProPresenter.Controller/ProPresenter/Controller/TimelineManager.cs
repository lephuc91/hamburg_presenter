using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.MessageService;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.Entity;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public class TimelineManager : ITimelineManager
{
	private readonly ITimelineService _timelineService;

	private readonly ITimelineAnalyticsEvents _timelineAnalyticsEvents;

	private readonly List<ActiveTimeline> _activeTimelines = new List<ActiveTimeline>();

	private readonly ITimecodeService _timecodeService;

	private readonly IEntityFactory _entityFactory;

	private readonly IDebouncerFactory _debouncerFactory;

	private readonly IOutputConfiguration _outputConfiguration;

	public event Action<TimelineStatus>? StatusUpdated;

	public TimelineManager(ITimelineService timelineService, IMessageService messageService, ITimelineAnalyticsEvents timelineAnalyticsEvents, ITimecodeService timecodeService, IEntityFactory entityFactory, IDebouncerFactory debouncerFactory, IOutputConfiguration outputConfiguration)
	{
		_timelineService = timelineService;
		_timelineService.StopRequested += OnStop;
		_timelineService.UpdateStatus += TimelineService_UpdateStatus;
		messageService.SubscribeToMessage<CueTriggeredMessage>(delegate(Pro.Common.MessageService.IMessage m)
		{
			OnTriggeredMessageReceivedAsync(m).ExecuteAsync();
		});
		messageService.SubscribeToMessage<ClearTypeTriggeredMessage>(delegate(Pro.Common.MessageService.IMessage m)
		{
			OnTriggeredMessageReceivedAsync(m).ExecuteAsync();
		});
		_timelineAnalyticsEvents = timelineAnalyticsEvents;
		_timecodeService = timecodeService;
		_entityFactory = entityFactory;
		_debouncerFactory = debouncerFactory;
		_outputConfiguration = outputConfiguration;
	}

	private void TimelineService_UpdateStatus((TriggerHandle handle, TimedPlaybackStatus status) update)
	{
		ActiveTimeline activeTimeline = _activeTimelines.Find((ActiveTimeline a) => a.Handle == update.handle);
		if (activeTimeline != null)
		{
			this.StatusUpdated?.Invoke(new TimelineStatus(activeTimeline.DocumentCue, update.status, activeTimeline.IsRecording));
		}
	}

	private async Task OnTriggeredMessageReceivedAsync(Pro.Common.MessageService.IMessage message)
	{
		bool didRecord = false;
		if (message is ClearTypeTriggeredMessage clearTypeTriggeredMessage)
		{
			didRecord = await RecordClearType(clearTypeTriggeredMessage);
		}
		else if (message is CueTriggeredMessage cueTriggeredMessage)
		{
			didRecord = await RecordCue(cueTriggeredMessage);
			if (cueTriggeredMessage.TriggeredCue is ClearGroup)
			{
				foreach (ActiveTimeline activeTimeline in _activeTimelines)
				{
					Timeline timeline = activeTimeline.DocumentCue?.GetTimeline();
					if (timeline != null)
					{
						TimedPlaybackStatus timedPlaybackStatus = await _timelineService.GetStatusAsync(activeTimeline.Handle);
						TimelineStateChanged.Publish(timeline, timedPlaybackStatus.State == TimedPlaybackState.Playing, timedPlaybackStatus.Time);
					}
				}
			}
		}
		if (didRecord)
		{
			_timelineAnalyticsEvents.RecordCue();
		}
	}

	private async Task<bool> RecordClearType(ClearTypeTriggeredMessage clearTypeTriggeredMessage)
	{
		bool didRecord = false;
		foreach (ActiveTimeline activeTimeline in _activeTimelines.Where((ActiveTimeline t) => t.IsRecording))
		{
			TimeSlice slideTime = TimeSlice.FromSeconds((await _timelineService.GetStatusAsync(activeTimeline.Handle)).Time);
			Pro.DO.Triggering.IAction action = clearTypeTriggeredMessage.TriggeredClearType.ToAction();
			if (action is ITimelineItem item)
			{
				activeTimeline.Timeline?.AddItem(item, slideTime, action.Name);
				didRecord = true;
			}
		}
		return didRecord;
	}

	private async Task<bool> RecordCue(CueTriggeredMessage cueTriggeredMessage)
	{
		bool didRecord = false;
		ITimelineItem item = TriggerableToTimelineItem(cueTriggeredMessage);
		foreach (ActiveTimeline activeTimeline in _activeTimelines.Where((ActiveTimeline t) => t.IsRecording))
		{
			TimeSlice slideTime = TimeSlice.FromSeconds(((!(activeTimeline.Timeline?.IsTimecodeEnabled ?? false) || !_timecodeService.CanFollow(activeTimeline.DocumentCue)) ? (await _timelineService.GetStatusAsync(activeTimeline.Handle)) : _timecodeService.CurrentTimecodePlaybackStatus)?.Time ?? 0.0);
			if (item is SlideCue value)
			{
				IDocumentCue? documentCue = activeTimeline.DocumentCue;
				bool? obj;
				if (documentCue == null)
				{
					obj = null;
				}
				else
				{
					IDocumentAction? documentAction = documentCue.DocumentAction;
					if (documentAction == null)
					{
						obj = null;
					}
					else
					{
						ProPresenter.DO.Presentation.IPresentation? presentation = documentAction.Presentation;
						obj = ((presentation != null) ? new bool?(!presentation.DefaultArrangement.SelectMany((CueGroup g) => g.Cues).Contains(value)) : ((bool?)null));
					}
				}
				if (obj ?? true)
				{
					continue;
				}
			}
			if (item != null)
			{
				activeTimeline.Timeline?.AddItem(item, slideTime, item.Name);
				didRecord = true;
			}
		}
		ITriggerable triggeredCue = cueTriggeredMessage.TriggeredCue;
		ArrangedCue arrangedCue = triggeredCue as ArrangedCue;
		if (arrangedCue != null)
		{
			SlideAction? slideAction = arrangedCue.Source.SlideAction;
			if (slideAction != null && slideAction.ActionType == ActionType.Slide)
			{
				ActiveTimeline timeline = _activeTimelines.Find((ActiveTimeline t) => t.DocumentCue?.DocumentAction?.ActiveArrangement?.ArrangedCues.Contains(arrangedCue) == true);
				if (timeline == null)
				{
					foreach (ActiveTimeline activeTimeline2 in _activeTimelines)
					{
						Pause(activeTimeline2.DocumentCue);
					}
					return false;
				}
				foreach (ActiveTimeline item2 in from t in _activeTimelines.Except(timeline)
					where t.DocumentCue?.DocumentAction?.Destination == timeline?.DocumentCue?.DocumentAction?.Destination
					select t)
				{
					Pause(item2.DocumentCue);
				}
			}
		}
		return didRecord;
	}

	public async Task<bool> TryRegisterTimelineAsync(IDocumentCue cue)
	{
		ActiveTimeline activeTimeline = await CreateAsync(cue);
		if (activeTimeline == null)
		{
			return false;
		}
		_activeTimelines.Add(activeTimeline);
		return true;
	}

	public async Task<TimedPlaybackStatus?> GetCurrentStatusAsync(IDocumentCue document)
	{
		ActiveTimeline activeTimeline;
		return (!TryFindActiveTimeline(document, out activeTimeline)) ? null : (await _timelineService.GetStatusAsync(activeTimeline.Handle));
	}

	public void Play(IDocumentCue? documentCue, TimeSlice? initialTime = null)
	{
		if (documentCue != null)
		{
			playAsync(documentCue, initialTime).ExecuteAsync();
		}
		async Task playAsync(IDocumentCue docCue, TimeSlice? time)
		{
			await StopTheActiveRecordingAsync(docCue);
			if (!TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				activeTimeline = await CreateAsync(docCue);
				if (activeTimeline == null)
				{
					return;
				}
				_activeTimelines.Add(activeTimeline);
			}
			if (time.HasValue)
			{
				await _timelineService.JumpToTimeAsync(activeTimeline.Handle, time.Value);
			}
			await _timelineService.PlayAsync(activeTimeline.Handle);
			_timelineAnalyticsEvents.Action(TimelineActionType.Play);
			await Task.WhenAll(from t in _activeTimelines
				where t.DocumentCue?.DocumentAction?.Destination == docCue.DocumentAction?.Destination
				select OnStatusChangedAsync(t.DocumentCue));
		}
	}

	public void Pause(IDocumentCue? documentCue)
	{
		pauseAsync(documentCue).ExecuteAsync();
		async Task pauseAsync(IDocumentCue? docCue)
		{
			if (TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				await _timelineService.PauseAsync(activeTimeline.Handle);
				_timelineAnalyticsEvents.Action(TimelineActionType.Stop);
				await OnStatusChangedAsync(docCue);
			}
		}
	}

	public void Reset(IDocumentCue documentCue)
	{
		resetAsync(documentCue).ExecuteAsync();
		async Task resetAsync(IDocumentCue docCue)
		{
			if (TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				await _timelineService.ResetAsync(activeTimeline.Handle);
				await OnStatusChangedAsync(docCue);
				_timelineAnalyticsEvents.Action(TimelineActionType.Reset);
			}
		}
	}

	public void JumpToTime(TimeSlice time, IDocumentCue documentCue)
	{
		jumpToTimeAsync(time, documentCue).ExecuteAsync();
		async Task jumpToTimeAsync(TimeSlice timeSlice, IDocumentCue docCue)
		{
			if (TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				await _timelineService.JumpToTimeAsync(activeTimeline.Handle, timeSlice);
				await OnStatusChangedAsync(docCue);
			}
		}
	}

	public void StartScrub(TimeSlice time, IDocumentCue documentCue)
	{
		startScrubAsync(time, documentCue).ExecuteAsync();
		async Task startScrubAsync(TimeSlice timeSlice, IDocumentCue docCue)
		{
			if (TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				await _timelineService.StartScrubAsync(activeTimeline.Handle, timeSlice);
				await OnStatusChangedAsync(docCue);
			}
		}
	}

	public void EndScrub(TimeSlice time, IDocumentCue documentCue)
	{
		endScrubAsync(time, documentCue).ExecuteAsync();
		async Task endScrubAsync(TimeSlice timeSlice, IDocumentCue docCue)
		{
			if (TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				await _timelineService.EndScrubAsync(activeTimeline.Handle, timeSlice);
				await OnStatusChangedAsync(docCue);
			}
		}
	}

	public void StartRecording(IDocumentCue documentCue)
	{
		startRecordingAsync(documentCue).ExecuteAsync();
		async Task startRecordingAsync(IDocumentCue docCue)
		{
			if (!TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				activeTimeline = await CreateAsync(docCue);
				if (activeTimeline == null)
				{
					return;
				}
				_activeTimelines.Add(activeTimeline);
			}
			await StopTheActiveRecordingAsync(docCue);
			await _timelineService.RecordAsync(activeTimeline.Handle, isRecording: true);
			activeTimeline.IsRecording = true;
		}
	}

	public void StopRecording(IDocumentCue documentCue)
	{
		stopRecordingAsync(documentCue).ExecuteAsync();
		async Task stopRecordingAsync(IDocumentCue docCue)
		{
			if (TryFindActiveTimeline(docCue, out ActiveTimeline activeTimeline))
			{
				await _timelineService.RecordAsync(activeTimeline.Handle, isRecording: false);
				activeTimeline.IsRecording = false;
			}
		}
	}

	public async Task StopTheActiveRecordingAsync(IDocumentCue except)
	{
		ActiveTimeline[] array = _activeTimelines.Where((ActiveTimeline a) => a.DocumentCue != except).ToArray();
		foreach (ActiveTimeline activeTimeline in array)
		{
			await _timelineService.RecordAsync(activeTimeline.Handle, isRecording: false);
			activeTimeline.IsRecording = false;
		}
	}

	public (bool isPlaying, bool isRecording, TimeSlice time) GetInfo(IDocumentCue? cue)
	{
		if (TryFindActiveTimeline(cue, out ActiveTimeline activeTimeline))
		{
			TimedPlaybackStatus result = Task.Run(() => _timelineService.GetStatusAsync(activeTimeline.Handle)).Result;
			bool item = result.State == TimedPlaybackState.Playing;
			TimeSlice item2 = TimeSlice.FromSeconds(result.Time);
			return (isPlaying: item, isRecording: activeTimeline.IsRecording, time: item2);
		}
		return (isPlaying: false, isRecording: false, time: TimeSlice.Zero);
	}

	private bool TryFindActiveTimeline(IDocumentCue? cue, [NotNullWhen(true)] out ActiveTimeline? activeTimeline)
	{
		activeTimeline = _activeTimelines.Find((ActiveTimeline t) => t.DocumentCue == cue);
		return activeTimeline != null;
	}

	private ITimelineItem? TriggerableToTimelineItem(CueTriggeredMessage cueTriggeredMessage)
	{
		ITimelineItem timelineItem = null;
		ITriggerable triggeredCue = cueTriggeredMessage.TriggeredCue;
		if (!(triggeredCue is MediaCue mediaCue))
		{
			if (!(triggeredCue is ArrangedCue arrangedCue))
			{
				if (!(triggeredCue is IPropCue prop))
				{
					if (!(triggeredCue is ProPresenterMacro macro))
					{
						if (!(triggeredCue is TimerData timerData))
						{
							if (!(triggeredCue is ClearGroup clearGroup))
							{
								if (!(triggeredCue is StageScreenLayoutMap assignments))
								{
									if (!(triggeredCue is Message message))
									{
										if (triggeredCue is AudienceLook look)
										{
											timelineItem = look.ToAction(_outputConfiguration.AudienceLooks) as ITimelineItem;
										}
									}
									else
									{
										timelineItem = message.ToAction() as ITimelineItem;
									}
								}
								else
								{
									timelineItem = assignments.ToAction() as ITimelineItem;
								}
							}
							else
							{
								timelineItem = clearGroup.ToAction() as ITimelineItem;
							}
						}
						else
						{
							timelineItem = new TimerAction(timerData.ID);
						}
					}
					else
					{
						timelineItem = macro.ToAction() as ITimelineItem;
					}
				}
				else
				{
					timelineItem = (PropAction)prop.ToAction(cueTriggeredMessage.PropTrigger);
				}
			}
			else
			{
				timelineItem = arrangedCue.Source;
			}
		}
		else
		{
			timelineItem = mediaCue.MediaAction?.Clone() as ITimelineItem;
			if (timelineItem is MediaAction mediaAction)
			{
				mediaAction.UpdatePropertiesForTimeline();
			}
		}
		return timelineItem;
	}

	private void OnStop(OutputDestination destination)
	{
		ActiveTimeline[] array = _activeTimelines.Where(delegate(ActiveTimeline t)
		{
			IDocumentCue? documentCue = t.DocumentCue;
			return documentCue != null && documentCue.DocumentAction?.Destination == destination;
		}).ToArray();
		foreach (ActiveTimeline activeTimeline in array)
		{
			Pause(activeTimeline.DocumentCue);
		}
	}

	private async Task<ActiveTimeline?> CreateAsync(IDocumentCue documentCue)
	{
		TriggerHandle triggerHandle = await _timelineService.CreateSessionAsync(documentCue);
		if (triggerHandle == TriggerHandle.Invalid)
		{
			return null;
		}
		ActiveTimeline activeTimeline = new ActiveTimeline(triggerHandle, documentCue, _debouncerFactory);
		activeTimeline.TimelineItemsUpdated += ActiveTimeline_TimelineUpdated;
		activeTimeline.TimelineDurationUpdated += ActiveTimeline_TimelineDurationUpdated;
		activeTimeline.TimelineLoopUpdated += ActiveTimeline_TimelineLoopUpdated;
		return activeTimeline;
	}

	private void ActiveTimeline_TimelineUpdated(IDocumentCue? documentCue)
	{
		if (TryFindActiveTimeline(documentCue, out ActiveTimeline activeTimeline))
		{
			_timelineService.UpdateItemsAsync(documentCue, activeTimeline.Handle).ExecuteAsync();
		}
	}

	private void ActiveTimeline_TimelineDurationUpdated(IDocumentCue? documentCue)
	{
		if (TryFindActiveTimeline(documentCue, out ActiveTimeline activeTimeline))
		{
			_timelineService.SetDurationAsync(documentCue, activeTimeline.Handle).ExecuteAsync();
		}
	}

	private void ActiveTimeline_TimelineLoopUpdated(IDocumentCue? documentCue)
	{
		if (TryFindActiveTimeline(documentCue, out ActiveTimeline activeTimeline))
		{
			Timeline? obj = documentCue?.GetTimeline();
			_timelineService.SetToLoopAsync(activeTimeline.Handle, obj?.IsSetToLoop ?? false).ExecuteAsync();
		}
	}

	private async Task OnStatusChangedAsync(IDocumentCue? document)
	{
		if (TryFindActiveTimeline(document, out ActiveTimeline activeTimeline))
		{
			TimedPlaybackStatus timedPlaybackStatus = await _timelineService.GetStatusAsync(activeTimeline.Handle);
			bool isPlaying = timedPlaybackStatus.State == TimedPlaybackState.Playing;
			TimeSlice timeSlice = TimeSlice.FromSeconds(timedPlaybackStatus.Time);
			this.StatusUpdated?.Invoke(new TimelineStatus(document, timedPlaybackStatus, activeTimeline.IsRecording));
			Timeline timeline = document?.GetTimeline();
			if (timeline != null)
			{
				TimelineStateChanged.Publish(timeline, isPlaying, timeSlice.TotalSeconds);
			}
		}
	}
}
