using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.UI.Utility;
using Pro.ssAPI;
using ProPresenter.Controller;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timecode;
using ProPresenter.UI;
using ProPresenter.UI.Controls;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Timeline;
using ProPresenter.ViewModels.Props;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Timeline;

public class TimelineVM : LinkedNotifyPropertyChangedBase, ITimelineVM, ICutPasteCollection<IAction>, ICutCollection<IAction>
{
	private const double TIMELINE_ZOOM_MIN_MAXIMUM = 15.0;

	private readonly IMediaActionService _mediaActionService;

	private readonly ITimecodeService _timecodeService;

	private readonly IApp _appSettings;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly ITimelineManager _timelineManager;

	private readonly IInputActions _inputActions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private ProPresenter.DO.Presentation.Timeline? _timeline;

	private IActionsMenuVM? _actionsMenuVM;

	private IDocumentCue? _documentCue;

	private bool _isPlaying;

	private bool _isRecording;

	private TimeSlice _currentTime;

	private PairedCollection<TimelineItemInfo, ITimelineItemVM> _timelineItems;

	private ICollectionView _cuesView;

	private ICollectionView _audioView;

	private ICollectionView _actionsView;

	private ICollectionView _mediaView;

	public ICollectionView CuesView
	{
		get
		{
			return _cuesView;
		}
		[MemberNotNull("_cuesView")]
		private set
		{
			SetValue("CuesView", ref _cuesView, value);
		}
	}

	public ICollectionView AudioView
	{
		get
		{
			return _audioView;
		}
		[MemberNotNull("_audioView")]
		private set
		{
			SetValue("AudioView", ref _audioView, value);
		}
	}

	public ICollectionView ActionsView
	{
		get
		{
			return _actionsView;
		}
		[MemberNotNull("_actionsView")]
		private set
		{
			SetValue("ActionsView", ref _actionsView, value);
		}
	}

	public ICollectionView MediaView
	{
		get
		{
			return _mediaView;
		}
		[MemberNotNull("_mediaView")]
		private set
		{
			SetValue("MediaView", ref _mediaView, value);
		}
	}

	public PairedCollection<TimelineItemInfo, ITimelineItemVM> TimelineItems
	{
		get
		{
			return _timelineItems;
		}
		[MemberNotNull("_timelineItems")]
		private set
		{
			SetValue("TimelineItems", ref _timelineItems, value);
		}
	}

	public ProPresenter.DO.Presentation.Timeline? Timeline
	{
		get
		{
			return _timeline;
		}
		set
		{
			SetValue<ProPresenter.DO.Presentation.Timeline>("Timeline", ref _timeline, value, delegate(ProPresenter.DO.Presentation.Timeline o, ProPresenter.DO.Presentation.Timeline n)
			{
				TimelineItems?.ChangeSource(n);
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("IsSetToLoop");
				OnPropertyChanged("ZoomMinimum");
				OnPropertyChanged("ZoomValue");
				OnPropertyChanged("IsPlaying");
				OnPropertyChanged("IsRecording");
				OnPropertyChanged("CurrentTime");
				OnPropertyChanged("IsTimecodeEnabled");
			});
		}
	}

	public bool CanFollowTimecode
	{
		get
		{
			if (IsTimecodeEnabled)
			{
				return _timecodeService.CanFollow(DocumentCue);
			}
			return false;
		}
	}

	public IDocumentCue? DocumentCue
	{
		get
		{
			return _documentCue;
		}
		set
		{
			SetValue<IDocumentCue>("DocumentCue", ref _documentCue, value, delegate(IDocumentCue o, IDocumentCue n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				Timeline = n?.DocumentAction?.Presentation?.PresentationTimeline;
				if (n != null)
				{
					UpdateCurrentTimeForIncomingTimelineAsync(n).ExecuteAsync();
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("CanFollowTimecode");
			});
		}
	}

	public bool IsPlaying
	{
		get
		{
			return _isPlaying;
		}
		set
		{
			SetValue("IsPlaying", ref _isPlaying, value);
		}
	}

	public bool IsRecording
	{
		get
		{
			return _isRecording;
		}
		set
		{
			SetValue("IsRecording", ref _isRecording, value);
		}
	}

	public bool IsSetToLoop
	{
		get
		{
			return Timeline?.IsSetToLoop ?? false;
		}
		set
		{
			if (Timeline != null)
			{
				Timeline.IsSetToLoop = value;
			}
		}
	}

	public bool IsTimecodeEnabled
	{
		get
		{
			return Timeline?.IsTimecodeEnabled ?? false;
		}
		set
		{
			if (Timeline != null)
			{
				Timeline.IsTimecodeEnabled = value;
			}
			OnPropertyChanged("CanFollowTimecode");
		}
	}

	public double ZoomValue
	{
		get
		{
			if (Timeline != null)
			{
				IApp appSettings = _appSettings;
				if (appSettings != null && appSettings.TimelineZoomValue?.Keys.Contains(Timeline.Presentation.ID) == true)
				{
					return _appSettings.TimelineZoomValue[Timeline.Presentation.ID];
				}
				if (!(Timeline.Duration != TimeSlice.Zero))
				{
					return 15.0;
				}
				return Timeline.Duration.TotalSeconds;
			}
			return 15.0;
		}
		set
		{
			if (Timeline != null)
			{
				IApp appSettings = _appSettings;
				if (appSettings != null && appSettings.TimelineZoomValue?.Keys.Contains(Timeline.Presentation.ID) == true)
				{
					_appSettings.TimelineZoomValue[Timeline.Presentation.ID] = value;
				}
				else
				{
					_appSettings?.TimelineZoomValue?.Add(Timeline.Presentation.ID, value);
				}
				OnPropertyChanged("ZoomValue");
			}
		}
	}

	public double ZoomMinimum
	{
		get
		{
			ProPresenter.DO.Presentation.Timeline? timeline = Timeline;
			double? num = ((timeline != null) ? new double?(timeline.Duration.TotalSeconds * 0.1) : ((double?)null));
			if (num.HasValue && num > 15.0)
			{
				return 15.0;
			}
			return num ?? 15.0;
		}
	}

	public TimeSlice CurrentTime
	{
		get
		{
			return _currentTime;
		}
		set
		{
			SetValue("CurrentTime", ref _currentTime, value);
		}
	}

	public double Fps => _appSettings.Timecode.Format.ToDouble();

	public ObservableCollection<ITimelineItemVM> SelectedItems { get; } = new ObservableCollection<ITimelineItemVM>();

	public ObservableCollection<IActionRepository> SelectedActions { get; } = new ObservableCollection<IActionRepository>();

	public MediaAction? SelectedMediaItem => GetSelectedMediaItem();

	public MediaAction? SelectedAudioItem => SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item).OfType<MediaAction>().FirstOrDefault((MediaAction a) => a.Media.MediaType == MediaType.Audio);

	public AudioBehaviorType SelectedAudioBehaviorType
	{
		get
		{
			MediaAction? selectedAudioItem = SelectedAudioItem;
			if (selectedAudioItem == null || selectedAudioItem.AudioMedia?.Transport.PlaybackBehaviorType != PlaybackBehaviorType.Loop)
			{
				return AudioBehaviorType.Stop;
			}
			return AudioBehaviorType.Loop;
		}
	}

	public IActionsMenuVM? ActionsMenuVM
	{
		get
		{
			return _actionsMenuVM;
		}
		set
		{
			SetValue("ActionsMenuVM", ref _actionsMenuVM, value);
		}
	}

	public Func<ActionBase, FrameworkElement>? FindActionDialogPlacementCallback { get; set; }

	public ICommand DeselectAllCommand => new RelayCommand(DeselectedAllExecuted, () => SelectedItems.Any());

	public ICommand SelectAllCommand => new RelayCommand(SelectAllExecuted, () => Timeline?.Any() ?? false);

	public ICommand PlayCommand => new RelayCommand(PlayExecuted, () => Timeline != null);

	public ICommand RecordCommand => new RelayCommand(RecordExecuted, () => Timeline != null);

	public ICommand ResetCommand => new RelayCommand(ResetExecuted, () => Timeline != null);

	public ICommand<IDocumentCue> DocumentCueUpdatedCommand => new RelayCommand<IDocumentCue>(UpdateDocumentCueExecuted);

	public ICommand<ITimelineItemDropArgs> TimelineItemDroppedCommand => new RelayCommand<ITimelineItemDropArgs>(TimelineItemDropExecuted, CanDropTimelineItem);

	public ICommand<TimeSlice> JumpToTimeCommand => new RelayCommand<TimeSlice>(JumpToTimeCommandExecuted);

	public ICommand<TimeSlice> StartScrubCommand => new RelayCommand<TimeSlice>(StartScrubCommandExecuted);

	public ICommand<TimeSlice> EndScrubCommand => new RelayCommand<TimeSlice>(EndScrubCommandExecuted);

	public ICommand<TimeSlice> AddMediaActionCommand => new RelayCommand<TimeSlice>(delegate(TimeSlice t)
	{
		OnAddMediaActionExecuted(FileFilters.VisualOnlyFilter, t);
	});

	public ICommand<ScaleBehavior> SetMediaScaleBehaviorCommand => new RelayCommand<ScaleBehavior>(SetMediaScaleBehaviorCommandExecuted);

	public ICommand<PlaybackBehaviorType> SetPlaybackCommand => new RelayCommand<PlaybackBehaviorType>(SetPlaybackCommandExecuted, (PlaybackBehaviorType p) => SelectedMediaItem != null);

	public ICommand<TimeSlice?> SetSoftLoopDurationCommand => new RelayCommand<TimeSlice?>(SetSoftLoopDurationCommandExecuted, (TimeSlice? t) => true);

	public ICommand<EndBehaviorType> SetEndBehaviorTypeCommand => new RelayCommand<EndBehaviorType>(SetEndBehaviorTypeCommandExecuted, (EndBehaviorType t) => true);

	public ICommand DeleteCommand => new RelayCommand(DeleteCommandExecuted, () => SelectedItems.Any());

	public ICommand CopyCommand => new RelayCommand(CopyCommandExecuted, () => SelectedActions.Any());

	public ICommand CutCommand => new RelayCommand(CutCommandExecuted, () => SelectedActions.Any());

	public ICommand PasteCommand => new RelayCommand(PasteCommandExecuted, () => SelectedActions.Any() && ClipboardManagerHelper.CanPasteIntoCollection<IAction>());

	public ICommand<MediaAction> ShowInFileExplorerCommand => new RelayCommand<MediaAction>(ShowInFileExplorerCommandExecuted, CanShowMediaInExplorer);

	public ICommand<TimeSlice> AddAudioActionCommand => new RelayCommand<TimeSlice>(delegate(TimeSlice t)
	{
		OnAddMediaActionExecuted(FileFilters.AudioOnlyFilter, t);
	});

	public ICommand<AudioBehaviorType> UpdateAudioBehaviorCommand => new RelayCommand<AudioBehaviorType>(UpdateAudioBehaviorExecuted, (AudioBehaviorType b) => SelectedItems.Any());

	public ICommand<ITimelineItemVM> OpenInspectorCommand => new RelayCommand<ITimelineItemVM>(OnOpenInspectorCommandExecute);

	public TimelineVM(IMediaActionService mediaActionService, ITimecodeService timeCodeService, IApp app, ITimelineManager timelineManager, ITimelineItemVMFactory factory, IInputActions inputActions, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		TimelineVM timelineVM = this;
		_mediaActionService = mediaActionService;
		_timecodeService = timeCodeService;
		_appSettings = app;
		_timelineManager = timelineManager;
		_inputActions = inputActions;
		_importProcessFactory = importProcessFactory;
		_transitionDescriptions = transitionDescriptions;
		_mediaFactory = mediaFactory;
		_timelineManager.StatusUpdated += TimelineManager_StatusUpdated;
		TimelineItems = new PairedCollection<TimelineItemInfo, ITimelineItemVM>(Timeline, (TimelineItemInfo timelineInfo) => factory.CreateItemVM(timelineInfo, TimelineItemNamePattern.Timeline));
		CuesView = (ICollectionView)(object)new ListCollectionView(TimelineItems)
		{
			Filter = (object item) => ((ITimelineItemVM)item).ItemType == TimelineItemType.Slide
		};
		AudioView = (ICollectionView)(object)new ListCollectionView(TimelineItems)
		{
			Filter = (object item) => ((ITimelineItemVM)item).ItemType == TimelineItemType.AudioMedia
		};
		MediaView = (ICollectionView)(object)new ListCollectionView(TimelineItems)
		{
			Filter = (object item) => ((ITimelineItemVM)item).ItemType == TimelineItemType.VisualMedia
		};
		ActionsView = (ICollectionView)(object)new ListCollectionView(TimelineItems)
		{
			Filter = (object item) => ((ITimelineItemVM)item).ItemType == TimelineItemType.Actions
		};
		SelectedItems.CollectionChanged += delegate
		{
			timelineVM.OnPropertyChanged("SelectedMediaItem");
			timelineVM.OnPropertyChanged("SelectedAudioItem");
		};
		SelectedActions.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			if (timelineVM.ActionsMenuVM != null && e.NewItems != null)
			{
				IEnumerable<IActionRepository> enumerable = e.NewItems.OfType<IActionRepository>();
				timelineVM.ActionsMenuVM.SelectedItems.Clear();
				timelineVM.ActionsMenuVM.SelectedItem = enumerable.FirstOrDefault();
				timelineVM.ActionsMenuVM.SelectedItems.AddRange(enumerable);
			}
		};
		LinkProperties("Duration", "ZoomMinimum");
		LinkProperties("IsSetToLoop", "IsSetToLoop");
		LinkProperties("Format", "Fps");
		LinkAction("CurrentTimecodePlaybackStatus", OnTimecodeStatusUpdated);
		LinkAction("DocumentAction", delegate
		{
			timelineVM.Timeline = timelineVM.DocumentCue?.DocumentAction?.Presentation?.PresentationTimeline;
			if (timelineVM.DocumentCue != null)
			{
				timelineVM.UpdateCurrentTimeForIncomingTimelineAsync(timelineVM.DocumentCue).ExecuteAsync();
			}
		});
		LinkAction(new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "IsTimecodeEnabled", "IsActive", "Playlist" }), delegate
		{
			timelineVM.OnPropertyChanged("IsTimecodeEnabled");
			timelineVM.OnPropertyChanged("CanFollowTimecode");
			if (timelineVM.CanFollowTimecode && timelineVM.IsPlaying)
			{
				timelineVM._timelineManager.Pause(timelineVM.DocumentCue);
			}
		});
		_timecodeService.PropertyChanged += base.RaiseLinkedValues;
		_appSettings.Timecode.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnOpenInspectorCommandExecute(ITimelineItemVM item)
	{
		if (item.ItemType.IsAnyOf(TimelineItemType.AudioMedia, TimelineItemType.VisualMedia))
		{
			IEnumerable<MediaCue> cues = (from a in (from i in SelectedItems
					select i.Item?.Item as MediaAction into a
					where a?.Media.MediaType.IsAnyOf(MediaType.Audio, MediaType.Image, MediaType.Video) ?? false
					select a).ToList()
				select a?.ToCue()).NotNull();
			InspectorOptions options = InspectorOptions.SupportsTransition | InspectorOptions.SupportsRetriggerBehavior;
			_inputActions.ProCommon.OpenMediaInspector.BindCommand?.Execute(new InspectorParameter(cues, options));
		}
	}

	private async Task UpdateCurrentTimeForIncomingTimelineAsync(IDocumentCue documentCue)
	{
		ProPresenter.Controller.TimedPlaybackStatus timedPlaybackStatus = await _timelineManager.GetCurrentStatusAsync(documentCue);
		if (timedPlaybackStatus != null)
		{
			CurrentTime = TimeSlice.FromSeconds(timedPlaybackStatus.Time);
			if (DocumentCue != null)
			{
				_timelineManager.JumpToTime(CurrentTime, DocumentCue);
			}
		}
		else if (await _timelineManager.TryRegisterTimelineAsync(documentCue))
		{
			await UpdateCurrentTimeForIncomingTimelineAsync(documentCue);
		}
	}

	private void TimelineItemDropExecuted(ITimelineItemDropArgs args)
	{
		if (!(args is ActionTypeTimelineItemDropArgs actionTypeTimelineItemDropArgs))
		{
			if (!(args is ClearTypeTimelineDropArgs clearTypeTimelineDropArgs))
			{
				if (!(args is FileTimelineItemDropArgs fileTimelineItemDropArgs))
				{
					if (!(args is MediaTypeTimelineItemDropArgs args2))
					{
						if (!(args is TriggerableTimelineItemDropArgs triggerableTimelineItemDropArgs))
						{
							return;
						}
						IAction action = TriggerableDropExecuted(args.DropTime, triggerableTimelineItemDropArgs.Triggerables);
						if (action != null)
						{
							triggerableTimelineItemDropArgs.GetAction = () => action;
						}
					}
					else
					{
						MediaTypeDropExecuted(args2);
					}
				}
				else
				{
					FileInfoDropExecuted(fileTimelineItemDropArgs.Files, args.DropTime);
				}
			}
			else
			{
				ClearTypeDropExecuted(clearTypeTimelineDropArgs.ClearTypes, args.DropTime);
			}
			return;
		}
		ActionBase action2 = ActionTypeDropExecuted(actionTypeTimelineItemDropArgs.ActionTypes, args.DropTime);
		if (action2 != null)
		{
			actionTypeTimelineItemDropArgs.GetAction = () => action2;
		}
	}

	private static bool CanDropTimelineItem(ITimelineItemDropArgs args)
	{
		if (args is ActionTypeTimelineItemDropArgs actionTypeTimelineItemDropArgs)
		{
			return actionTypeTimelineItemDropArgs.ActionTypes.All((ActionType a) => a != ActionType.Capture);
		}
		return true;
	}

	private void FileInfoDropExecuted(FileInfo[] fileInfos, TimeSlice time)
	{
		if (Timeline == null)
		{
			return;
		}
		List<FileImportRequest> list = new List<FileImportRequest>();
		foreach (FileInfo fileInfo in fileInfos)
		{
			if (!fileInfo.FullName.IsAudioFile() && !fileInfo.FullName.IsVisualMediaFile())
			{
				continue;
			}
			FileImportRequest item = new FileImportRequest(fileInfo.FullName)
			{
				CompleteCallback = delegate(string o, string n, FileMediaBase? createdMedia)
				{
					FileMediaBase fileMediaBase = createdMedia ?? _mediaFactory.CreateEmptyFileMedia(n, Timeline.Presentation.ContainerId, null);
					if (!fileMediaBase.MetadataLoaded)
					{
						fileMediaBase.MetadataLoadSuccessful += media_MetadataLoadSuccessful;
					}
					else
					{
						media_MetadataLoadSuccessful(fileMediaBase);
					}
					fileMediaBase.UpdateSource(userInitiated: true, new RelativePath(n));
				}
			};
			list.Add(item);
		}
		if (list.Any())
		{
			_importProcessFactory.Create(list).StartImport();
		}
		void media_MetadataLoadSuccessful(FileMediaBase media)
		{
			media.MetadataLoadSuccessful -= media_MetadataLoadSuccessful;
			MediaAction mediaAction = new MediaAction(media, _appSettings, _transitionDescriptions);
			MediaHelper.ApplyImportSettings(mediaAction.ToCue());
			mediaAction.UpdatePropertiesForTimeline();
			Timeline.AddItem(mediaAction, time, mediaAction.Name);
			time += TimeSlice.FromSeconds(1.0);
		}
	}

	private void MediaTypeDropExecuted(MediaTypeTimelineItemDropArgs args)
	{
		MediaType[] mediaTypes = args.MediaTypes;
		TimeSlice dropTime = args.DropTime;
		List<FileInfo> list = new List<FileInfo>();
		MediaType[] array = mediaTypes;
		foreach (MediaType mediaType in array)
		{
			if ((uint)mediaType > 2u)
			{
				if (mediaType == MediaType.LiveVideo)
				{
					MediaAction action = new MediaAction(_mediaFactory.CreateLiveVideoMedia(), _appSettings, _transitionDescriptions);
					args.GetAction = () => action;
					Timeline?.AddItem(action, dropTime, string.Empty);
				}
				continue;
			}
			string text;
			switch (mediaType)
			{
			case MediaType.Image:
			case MediaType.Video:
				text = FileFilters.VisualOnlyFilter;
				break;
			case MediaType.Audio:
				text = FileFilters.AudioOnlyFilter;
				break;
			default:
				throw new NotSupportedException("Unknown media type");
			}
			string filter = text;
			if (DialogHelper.SelectFile(out string selectedFile, filter))
			{
				list.Add(new FileInfo(selectedFile));
			}
		}
		FileInfoDropExecuted(list.ToArray(), dropTime);
	}

	private void ClearTypeDropExecuted(IEnumerable<ClearType> clearTypes, TimeSlice time)
	{
		clearTypes.Select((ClearType c) => c.ToAction()).OfType<ITimelineItem>().ForEach(delegate(ITimelineItem i)
		{
			Timeline?.AddItem(i, time, string.Empty);
		});
	}

	private ActionBase? ActionTypeDropExecuted(IEnumerable<ActionType> actionTypes, TimeSlice time)
	{
		ActionBase action = null;
		actionTypes.Select((ActionType a) => a.ConstructAction(null, DocumentCue?.DocumentAction?.Presentation?.ContainerId ?? "")).OfType<ITimelineItem>().ForEach(delegate(ITimelineItem i)
		{
			Timeline?.AddItem(i, time, string.Empty);
			action = i as ActionBase;
			time += TimeSlice.FromSeconds(1.0);
		});
		return action;
	}

	private IAction? TriggerableDropExecuted(TimeSlice dropTime, IEnumerable<ITriggerable> triggerables)
	{
		IAction action = null;
		if (triggerables != null)
		{
			foreach (ITriggerable triggerable in triggerables)
			{
				if (!(triggerable is MediaCue mediaCue))
				{
					if (!(triggerable is ArrangedCue arrangedCue))
					{
						if (!(triggerable is IMacroItemVM macroItemVM))
						{
							if (!(triggerable is ITimerVM timerVM))
							{
								if (!(triggerable is ScreenArrangementBase screen))
								{
									if (!(triggerable is Message message))
									{
										if (!(triggerable is IPropCue prop))
										{
											if (!(triggerable is IPropCueVMInternal propCueVMInternal))
											{
												if (!(triggerable is IClearGroupItemVM clearGroupItemVM))
												{
													if (!(triggerable is IMediaCueThumbnailVM mediaCueThumbnailVM))
													{
														if (!(triggerable is IPlaylist<MediaCue> playlist))
														{
															continue;
														}
														action = playlist.ToAction();
													}
													else
													{
														action = GetActionFromMediaCue(mediaCueThumbnailVM.MediaCue);
													}
												}
												else
												{
													action = clearGroupItemVM.Item.ToAction();
												}
											}
											else
											{
												action = propCueVMInternal.Source.ToAction(null);
											}
										}
										else
										{
											action = prop.ToAction(null);
										}
									}
									else
									{
										action = message.ToAction();
									}
								}
								else
								{
									action = screen.ToAction();
								}
							}
							else
							{
								action = new TimerAction(timerVM.ID);
							}
						}
						else
						{
							action = macroItemVM.Macro.ToAction();
						}
					}
					else
					{
						Timeline?.AddItem(arrangedCue.Source, dropTime, arrangedCue.LabelName);
					}
				}
				else
				{
					action = GetActionFromMediaCue(mediaCue);
				}
				if (action is ITimelineItem item)
				{
					Timeline?.AddItem(item, dropTime, action.Name);
				}
				dropTime += TimeSlice.FromSeconds(1.0);
			}
		}
		return action;
	}

	private static IAction? GetActionFromMediaCue(MediaCue mediaCue)
	{
		IAction obj = mediaCue.MediaAction?.Clone();
		if (obj is MediaAction mediaAction)
		{
			mediaAction.UpdatePropertiesForTimeline();
		}
		return obj;
	}

	private void UpdateDocumentCueExecuted(IDocumentCue newDocumentCue)
	{
		DocumentCue = newDocumentCue;
	}

	private void TimelineManager_StatusUpdated(TimelineStatus update)
	{
		if (Timeline == null || DocumentCue == null)
		{
			return;
		}
		Guid iD = DocumentCue.ID;
		Guid? guid = update.Document?.ID;
		if (guid.HasValue && iD == guid.GetValueOrDefault() && !CanFollowTimecode)
		{
			ProPresenter.Controller.TimedPlaybackStatus status = update.Status;
			IsPlaying = status.State == TimedPlaybackState.Playing;
			IsRecording = update.IsRecording;
			CurrentTime = TimeSlice.FromSeconds(status.Time);
			OnPropertyChanged("CurrentTime");
			if (IsRecording && CurrentTime >= Timeline.Duration)
			{
				Timeline.Duration += TimeSlice.FromSeconds(10.0);
			}
			else if (!IsRecording && IsPlaying && CurrentTime >= Timeline.Duration && !Timeline.IsSetToLoop)
			{
				_timelineManager.Pause(DocumentCue);
			}
		}
	}

	private void OnTimecodeStatusUpdated()
	{
		if (CanFollowTimecode && _timecodeService.ActiveTimecodeSettings.IsActive)
		{
			ProPresenter.Controller.TimedPlaybackStatus? currentTimecodePlaybackStatus = _timecodeService.CurrentTimecodePlaybackStatus;
			IsPlaying = currentTimecodePlaybackStatus != null && currentTimecodePlaybackStatus.State == TimedPlaybackState.Playing;
			double num = _timecodeService.CurrentTimecodePlaybackStatus?.Time ?? 0.0;
			double num2 = Timeline?.TimecodeOffset.TotalSeconds ?? 0.0;
			num = Math.Max(0.0, num - num2);
			CurrentTime = TimeSlice.FromSeconds(num);
		}
	}

	private void PlayExecuted()
	{
		if (IsPlaying)
		{
			_timelineManager.Play(DocumentCue, CurrentTime);
		}
		else
		{
			_timelineManager.Pause(DocumentCue);
		}
	}

	private void RecordExecuted()
	{
		DocumentCue.ThrowWhenNull("DocumentCue");
		if (IsRecording)
		{
			_timelineManager.StartRecording(DocumentCue);
		}
		else
		{
			_timelineManager.StopRecording(DocumentCue);
		}
	}

	private void ResetExecuted()
	{
		DocumentCue.ThrowWhenNull("DocumentCue");
		_timelineManager.Reset(DocumentCue);
	}

	private void DeselectedAllExecuted()
	{
		SelectedItems.Clear();
	}

	private void SelectAllExecuted()
	{
		Timeline.ThrowWhenNull("Timeline");
		DeselectedAllExecuted();
		SelectedItems.AddRange(Timeline);
	}

	private void OnAddMediaActionExecuted(string extensions, TimeSlice dropTime)
	{
		if (DialogHelper.SelectFile(out string selectedFile, extensions))
		{
			FileInfoDropExecuted(new FileInfo[1]
			{
				new FileInfo(selectedFile)
			}, dropTime);
		}
	}

	private void SetMediaScaleBehaviorCommandExecuted(ScaleBehavior scaleBehavior)
	{
		_mediaActionService.SetMediaScaleBehavior(SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item as MediaAction).NotNull(), scaleBehavior);
	}

	private void SetPlaybackCommandExecuted(PlaybackBehaviorType playback)
	{
		MediaAction selectedMediaItem = SelectedMediaItem;
		selectedMediaItem.ThrowWhenNull("target");
		IEnumerable<MediaAction> others = SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item as MediaAction).NotNull();
		_mediaActionService.SetPlayback(selectedMediaItem, others, playback);
	}

	private void SetSoftLoopDurationCommandExecuted(TimeSlice? duration)
	{
		IEnumerable<MediaAction> mediaActions = SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item as MediaAction).NotNull();
		_mediaActionService.SetSoftLoopDuration(mediaActions, duration);
	}

	private void SetEndBehaviorTypeCommandExecuted(EndBehaviorType endBehavior)
	{
		IEnumerable<MediaAction> mediaActions = SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item as MediaAction).NotNull();
		_mediaActionService.SetEndBehaviorType(mediaActions, endBehavior);
	}

	private void DeleteCommandExecuted()
	{
		Timeline?.RemoveItems(SelectedItems.Select((ITimelineItemVM i) => i.Item).NotNull());
		SelectedItems.Clear();
	}

	private void CopyCommandExecuted()
	{
		IActionRepository? actionRepository = SelectedActions.FirstOrDefault();
		IOrderedEnumerable<IAction> orderedEnumerable = (Enumerable.Concat(second: from a in SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item).OfType<IAction>()
			where a != null
			select a, first: actionRepository?.Actions).NonNull().Distinct() ?? Enumerable.Empty<IAction>()).OrderBy((IAction s) => ((IEnumerable)ActionsView).IndexOf(s));
		if (orderedEnumerable.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(orderedEnumerable);
		}
	}

	private void CutCommandExecuted()
	{
		CopyCommandExecuted();
		DeleteCommandExecuted();
	}

	private void PasteCommandExecuted()
	{
		IEnumerable<IAction> source = SelectedActions.FirstOrDefault()?.Actions ?? Enumerable.Empty<IAction>();
		int index = (source.Any() ? (source.Max((IAction c) => ((IEnumerable)ActionsView).IndexOf(c)) + 1) : 0);
		ClipboardManagerHelper.PasteIntoCollection<ITimelineVM, IAction>(this, index);
	}

	private static void ShowInFileExplorerCommandExecuted(MediaAction action)
	{
		if (action?.FileMedia?.SourceFile?.FullPath != null)
		{
			ProcessHelper.ShowFileInExplorer(action.FileMedia.SourceFile.FullPath);
		}
	}

	private static bool CanShowMediaInExplorer(MediaAction action)
	{
		return action != null;
	}

	private void UpdateAudioBehaviorExecuted(AudioBehaviorType behavior)
	{
		IEnumerable<MediaAction> mediaActions = SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item as MediaAction).NotNull();
		_mediaActionService.SetAudioPlayback(mediaActions, behavior);
		OnPropertyChanged("SelectedAudioBehaviorType");
	}

	private MediaAction? GetSelectedMediaItem()
	{
		IEnumerable<MediaAction> source = from a in SelectedItems.Select((ITimelineItemVM i) => i.Item?.Item).OfType<MediaAction>()
			where a.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video)
			select a;
		return source.FirstOrDefault((MediaAction a) => a.Media.MediaType == MediaType.Image) ?? source.FirstOrDefault();
	}

	private void JumpToTimeCommandExecuted(TimeSlice time)
	{
		DocumentCue.ThrowWhenNull("DocumentCue");
		_timelineManager.JumpToTime(time, DocumentCue);
	}

	private void StartScrubCommandExecuted(TimeSlice time)
	{
		DocumentCue.ThrowWhenNull("DocumentCue");
		_timelineManager.StartScrub(time, DocumentCue);
	}

	private void EndScrubCommandExecuted(TimeSlice time)
	{
		DocumentCue.ThrowWhenNull("DocumentCue");
		_timelineManager.EndScrub(time, DocumentCue);
	}

	public void SetTransition(TransitionParameters currentTransition, UIElement placementTarget, Action<TransitionParameters> setTransitionCallback)
	{
		_mediaActionService.SetTransition(currentTransition, placementTarget, setTransitionCallback);
	}

	public void CutFrom(IEnumerable<IAction> items)
	{
		SelectedActions.FirstOrDefault()?.RemoveActions(items);
	}

	public void PasteInto(IEnumerable<IAction> items, int index)
	{
		SelectedActions.FirstOrDefault()?.InsertActions(items, index);
	}
}
