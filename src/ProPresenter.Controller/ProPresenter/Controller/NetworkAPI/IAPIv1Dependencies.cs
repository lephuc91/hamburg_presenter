using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.ToastNotifications;
using Pro.DO.Transitions;
using Pro.Localization.Services;
using ProPresenter.DO;
using ProPresenter.DO.Capture;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.Rendering;

namespace ProPresenter.Controller.NetworkAPI;

public interface IAPIv1Dependencies
{
	IApp App { get; init; }

	ICaptureService CaptureService { get; init; }

	IProPresenterCueFactory CueFactory { get; init; }

	IProPresenterDOFactoryProvider FactoryProvider { get; init; }

	IFlagService FlagService { get; init; }

	IImportProcessFactory ImportProcessFactory { get; init; }

	ILocalization Localization { get; init; }

	ILogger Logger { get; init; }

	IToastNotificationService ToastNotifications { get; init; }

	IPresentationHandlerOperationService PresentationHandlerOperationService { get; init; }

	IProPresenterResourceService ProPresenterResourceService { get; init; }

	IResiService ResiService { get; init; }

	ISlidePreviewService SlidePreviewRenderer { get; init; }

	ITimelineManager TimelineManager { get; init; }

	ITransitionDescriptionCollection TransitionDescriptions { get; init; }

	IUiDispatcher UiDispatcher { get; init; }
}
