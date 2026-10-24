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

public record APIv1Dependencies(IUiDispatcher UiDispatcher, IProPresenterResourceService ProPresenterResourceService, IToastNotificationService ToastNotifications, ILocalization Localization, IPresentationHandlerOperationService PresentationHandlerOperationService, ITimelineManager TimelineManager, IFlagService FlagService, ICaptureService CaptureService, IResiService ResiService, IApp App, IImportProcessFactory ImportProcessFactory, ITransitionDescriptionCollection TransitionDescriptions, IProPresenterDOFactoryProvider FactoryProvider, ISlidePreviewService SlidePreviewRenderer, ILogger Logger, IProPresenterCueFactory CueFactory) : IAPIv1Dependencies;
