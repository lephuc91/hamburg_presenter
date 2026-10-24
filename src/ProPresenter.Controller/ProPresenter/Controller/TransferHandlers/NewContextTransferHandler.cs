using System;
using System.Linq;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;
using ProPresenterCore.ProCore.Interop.Triggering.Transfers;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.TransferHandlers;

public class NewContextTransferHandler : ITransferHandler
{
	private readonly ICoreManager _coreManager;

	private readonly IProPresenterResourceService _resources;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly ITimecodeService _timecodeService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public NewContextTransferHandler(ICoreManager coreManager, IProPresenterResourceService resources, IUiDispatcher uiDispatcher, ITimecodeService timecodeService, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_coreManager = coreManager;
		_resources = resources;
		_uiDispatcher = uiDispatcher;
		_timecodeService = timecodeService;
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
	}

	public void Handle(TriggerAddress? address, TriggerTransfer transfer)
	{
		GetNewContextTransfer getNewContextTransfer = transfer as GetNewContextTransfer;
		if (getNewContextTransfer == null)
		{
			return;
		}
		ITriggerOperation triggerOperation = getNewContextTransfer.ClientObject as ITriggerOperation;
		if (triggerOperation == null)
		{
			triggerOperation = _uiDispatcher.Invoke(() => _coreManager.CreateTriggerOperation(getNewContextTransfer.Handle));
		}
		if (triggerOperation == null)
		{
			Log.Error("TriggerOperation null in Handle");
			return;
		}
		Pro.SerializationInterop.RVProtoData.TriggerSource triggerSource = getNewContextTransfer.TriggerSource;
		IDocumentCue document = null;
		ILibrary library = null;
		IPlaylist<ProPresenterCue> playlist = null;
		getNewContextTransfer.ClientObject = triggerOperation;
		if (getNewContextTransfer.Action == null)
		{
			return;
		}
		if (triggerSource.LocationCase == Pro.SerializationInterop.RVProtoData.TriggerSource.LocationOneofCase.LibraryLocation)
		{
			document = _resources?.LibraryCollection.FindDocument(new RelativePath(triggerSource.LibraryLocation.Path), out library);
		}
		else if (triggerSource.LocationCase == Pro.SerializationInterop.RVProtoData.TriggerSource.LocationOneofCase.PlaylistLocation)
		{
			playlist = _resources?.LibraryPlaylists?.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == triggerSource.PlaylistLocation.Identifier.ToGuid()).FirstOrDefault();
			if (playlist is Playlist<ProPresenterCue> source)
			{
				document = source.FirstOrDefault((ProPresenterCue i) => i.ID == triggerSource.PlaylistLocation.ItemIdentifier.ToGuid()) as IDocumentCue;
			}
		}
		switch (getNewContextTransfer.Action.Type)
		{
		case Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PresentationSlide:
			HandlePresentationSlide(getNewContextTransfer, triggerOperation, document, playlist as Playlist<ProPresenterCue>);
			break;
		case Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media:
			switch (triggerSource.LocationCase)
			{
			case Pro.SerializationInterop.RVProtoData.TriggerSource.LocationOneofCase.MediaPlaylistLocation:
				HandleMediaBin(getNewContextTransfer, triggerOperation);
				break;
			case Pro.SerializationInterop.RVProtoData.TriggerSource.LocationOneofCase.AudioPlaylistLocation:
				HandleAudioBin(getNewContextTransfer, triggerOperation);
				break;
			default:
				HandleLibraryMedia(getNewContextTransfer, triggerOperation, document, playlist as Playlist<ProPresenterCue>);
				break;
			}
			break;
		case Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Prop:
		case Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PropSlide:
			HandlePropSlide(getNewContextTransfer, triggerOperation);
			break;
		case Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Macro:
			HandleMacro(getNewContextTransfer, triggerOperation);
			break;
		case Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.StageLayout:
			HandleStageLayout(getNewContextTransfer, triggerOperation);
			break;
		}
	}

	private void HandlePresentationSlide(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp, IDocumentCue? document, Playlist<ProPresenterCue>? playlist)
	{
		if (newOp.CueInfo != null)
		{
			return;
		}
		PresentationSlide presentationSlide = getNewContextTransfer.Action?.Slide?.Presentation;
		if (presentationSlide != null && document?.DocumentAction?.Presentation != null)
		{
			OutputDestination destination = document.DocumentAction.Destination;
			Timeline presentationTimeline = document.DocumentAction.Presentation.PresentationTimeline;
			TimelineSlideInfo timelineSlideInfo = TriggerHelper.GetTimelineSlideInfo(arrangedCues: document.DocumentAction.Presentation.DefaultArrangement.ArrangedCues, offset: (presentationTimeline.IsTimecodeEnabled && _timecodeService.ActiveTimecodeSettings.IsActive && getNewContextTransfer.TriggerSource.LocationCase == Pro.SerializationInterop.RVProtoData.TriggerSource.LocationOneofCase.PlaylistLocation) ? TimeSlice.FromSeconds(presentationTimeline.TimecodeOffset.TotalSeconds) : TimeSlice.Zero, timelineItems: presentationTimeline, timelineDuration: presentationTimeline.Duration, currentItemTime: getNewContextTransfer.TriggerTime);
			IArrangedCue arrangedCue = timelineSlideInfo?.CurrentSlide;
			IArrangedCue arrangedCue2 = timelineSlideInfo?.NextSlide;
			CustomSlide customSlide = (arrangedCue?.Source?.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true) ?? new CustomSlide(_factoryProvider, _transitionDescriptions);
			if (arrangedCue == null)
			{
				customSlide.Deserialize(presentationSlide, new ApplicationData(ApplicationType.ProPresenter), document.DocumentAction.ContainerId);
			}
			CustomSlide slide = customSlide.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			newOp.SlidePool.AddSlide(slide);
			CustomSlide customSlide2 = (arrangedCue2?.Source?.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			CustomSlide slide2 = customSlide2?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			newOp.SlidePool.AddSlide(slide2);
			if (destination == OutputDestination.Presentation)
			{
				newOp.AttachPresentationSlideCueInfo(arrangedCue as ArrangedCue, arrangedCue2?.Source, customSlide.Serialize().BaseSlide, customSlide, customSlide2, playlist, document, isBibleSlide: false, timelineSlideInfo);
			}
			else
			{
				newOp.AttachAnnouncementSlideCueInfo(arrangedCue as ArrangedCue, arrangedCue2?.Source, customSlide.Serialize().BaseSlide, customSlide, customSlide2, playlist, document, timelineSlideInfo);
			}
		}
	}

	private void HandlePropSlide(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp)
	{
		IPropCueCollection propCueCollection = _resources.PropCueCollection;
		if (getNewContextTransfer.Action?.Slide?.Prop != null && propCueCollection != null)
		{
			PropSlide prop = getNewContextTransfer.Action.Slide.Prop;
			IPropCue originalPropCue = propCueCollection.FirstOrDefault((IPropCue a) => a.SlideAction?.ID == getNewContextTransfer.Action.Uuid.ToGuid());
			newOp.AttachPropCueInfo(originalPropCue, prop.BaseSlide);
		}
	}

	private static void HandleLibraryMedia(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp, IDocumentCue? document, Playlist<ProPresenterCue>? playlist)
	{
		if (getNewContextTransfer.Action?.Media != null)
		{
			MediaAction mediaAction = document?.DocumentAction?.Presentation?.PresentationTimeline.Select((TimelineItemInfo i) => i.Item).OfType<MediaAction>().FirstOrDefault((MediaAction a) => a.ID == getNewContextTransfer.Action.Uuid.ToGuid());
			if (mediaAction != null)
			{
				MediaCue mediaCue = new MediaCue(mediaAction);
				newOp.AttachMediaCueInfo(CueLocation.Presentation, mediaCue, playlist);
			}
		}
	}

	private void HandleAudioBin(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp)
	{
		IPlaylist<MediaCue> playlist = _resources?.AudioPlaylists?.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == getNewContextTransfer.TriggerSource.AudioPlaylistLocation.Identifier.ToGuid()).FirstOrDefault();
		HandleMedia(getNewContextTransfer, playlist as AudioPlaylist, newOp, CueLocation.AudioBin);
	}

	private void HandleMediaBin(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp)
	{
		IPlaylist<MediaCue> playlist = _resources?.VisualPlaylists?.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == getNewContextTransfer.TriggerSource.MediaPlaylistLocation.Identifier.ToGuid()).FirstOrDefault();
		HandleMedia(getNewContextTransfer, playlist as VisualPlaylist, newOp, CueLocation.MediaBin);
	}

	private static void HandleMedia(GetNewContextTransfer getNewContextTransfer, Playlist<MediaCue>? playlist, ITriggerOperation newOp, CueLocation cueLocation)
	{
		if (getNewContextTransfer.Action?.Media != null && playlist != null)
		{
			MediaCue mediaCue = playlist.FirstOrDefault((MediaCue m) => m.MediaAction != null && m.MediaAction.ID == getNewContextTransfer.Action.Uuid.ToGuid());
			if (mediaCue?.MediaAction != null)
			{
				newOp.AttachMediaCueInfo(cueLocation, mediaCue, playlist);
			}
		}
	}

	private void HandleMacro(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp)
	{
		IMacroSource macroSource = _resources.MacroSource;
		if (getNewContextTransfer?.Action.Macro != null && macroSource != null)
		{
			ProPresenterMacro proPresenterMacro = macroSource.FindMacro(getNewContextTransfer.Action.Macro.Identification.ParameterUuid.ToGuid(), getNewContextTransfer.Action.Macro.Identification.ParameterName, getNewContextTransfer.Action.Macro.Identification.ParentCollection?.ParameterUuid.ToGuid() ?? Guid.Empty, getNewContextTransfer.Action.Macro.Identification.ParentCollection?.ParameterName ?? string.Empty);
			if (proPresenterMacro != null)
			{
				newOp.AttachMacroInfo(proPresenterMacro);
				_coreManager.MacroTriggerOPCreated(newOp, proPresenterMacro);
			}
		}
	}

	private static void HandleStageLayout(GetNewContextTransfer getNewContextTransfer, ITriggerOperation newOp)
	{
		Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType stageLayoutType = getNewContextTransfer.Action?.Stage;
		if (stageLayoutType != null)
		{
			newOp.StageInfo = new StageInfo(stageLayoutType.StageScreenAssignments);
		}
	}
}
