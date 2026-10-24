using Pro.Common.Time;
using Pro.DO.Transitions;
using ProPresenter.Controller;
using ProPresenter.DO.Import;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.ViewModels.Timeline;

public class TimelineVMFactory : ITimelineVMFactory, ITimelineItemVMFactory
{
	private readonly IMediaActionService _mediaActionService;

	private readonly ITimecodeService _timeCodeService;

	private readonly IApp _app;

	private readonly ITimelineManager _timelineManager;

	private readonly IInputActions _inputActions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public TimelineVMFactory(IMediaActionService mediaActionService, ITimecodeService timeCodeService, IApp app, ITimelineManager timelineManager, IInputActions inputActions, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
	{
		_mediaActionService = mediaActionService;
		_timeCodeService = timeCodeService;
		_app = app;
		_timelineManager = timelineManager;
		_inputActions = inputActions;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
	}

	public ITimelineVM CreateVM()
	{
		return new TimelineVM(_mediaActionService, _timeCodeService, _app, _timelineManager, this, _inputActions, _importProcessFactory, _mediaFactory, _transitionDescriptions);
	}

	public ITimelineItemVM CreateItemVM(TimelineItemInfo timelineInfo, TimelineItemNamePattern timeline)
	{
		return new TimelineItemVM(timelineInfo)
		{
			NamePattern = timeline
		};
	}

	public ITimeTickSection CreateTickSection(TimeSlice startTime, TimeSlice duration)
	{
		return new TimeTickSection
		{
			StartTime = startTime,
			Duration = duration
		};
	}
}
