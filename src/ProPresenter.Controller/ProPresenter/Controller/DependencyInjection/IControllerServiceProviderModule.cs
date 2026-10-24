using Jab;
using Pro.DO.Transitions;
using Pro.ssAPI.Devices;
using ProPresenter.Controller.AsyncTransferHandlers;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.Controller.NetworkAPI.Transmit.Command;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.RenderClockSource;
using ProPresenter.Controller.Repos;
using ProPresenter.DO;
using ProPresenter.DO.Events;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Resi;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IServerStateHandler, ServerStateHandler>]
[Jab.Singleton<IAirCastConfiguration, AirCastConfiguration>]
[Jab.Singleton<IReceiveService, ReceiveService>]
[Jab.Singleton<ICommandSender, CommandSender>]
[Jab.Singleton<INetworkLinkService, NetworkLinkService>]
[Jab.Transient<ILinkRequestFactory, LinkRequestFactory>]
[Jab.Singleton<INetworkEnvironment, NetworkEnvironment>]
[Jab.Singleton<ssAPIOutput>]
[Jab.Singleton<ICommunicationOutput, CommunicationOutput>]
[Jab.Transient<IOutputService, OutputService>]
[Jab.Singleton<ITimedPlaybackRepository, TimedPlaybackRepository>]
[Jab.Singleton<ITimelineService, TimelineService>]
[Jab.Transient<IPresentationHandlerOperationService, PresentationHandlerOperationService>]
[Jab.Singleton<ITimecodeService, TimecodeService>]
[Jab.Singleton<IResiPlugin>(Factory = "GetResiPlugin")]
[Jab.Singleton<IResiController, ResiController>]
[Jab.Singleton<ITimelineManager, TimelineManager>]
[Jab.Transient<INetworkCommandFactory>(Factory = "GetNetworkCommandFactory")]
[Jab.Singleton<INetworkCommandTrigger, NetworkCommandTrigger>]
[Jab.Singleton<CoreManager>]
[Jab.Transient<ICoreManager>(Factory = "GetCoreManager")]
[Jab.Transient<IInternalCoreManager>(Factory = "GetCoreManager")]
[Jab.Transient<IApplicationEventHandler>(Factory = "GetCoreManager", Name = "CoreManagerApplicationEventHandler")]
[Jab.Transient<ITransferHandlerFactory, TransferHandlerFactory>]
[Jab.Transient<ITriggeringFactory, TriggerServiceFactory>]
[Jab.Transient<INetworkTriggerDataTransferFactory>(Factory = "GetNetworkTriggerDataTransferFactory")]
[Jab.Singleton<ISettingsDataToCoreSender, SettingsDataToCoreSender>]
[Jab.Singleton<IClockSourceProvider, ClockSourceProvider>]
[Jab.Singleton<IClockSourceService, ClockSourceService>]
[Jab.Transient<IAPIv1Dependencies, APIv1Dependencies>]
[Jab.Transient<IAudioOutputDeviceCollection>(Factory = "GetAudioOutputDeviceCollection")]
[Jab.Transient<ITransitionDescriptionCollection>(Factory = "GetTransitionDescriptionCollection")]
public interface IControllerServiceProviderModule
{
	const string CoreManagerApplicationEventHandler = "CoreManagerApplicationEventHandler";

	static IResiPlugin GetResiPlugin(IApp app, IErrorPrompt errorPrompt, IProCoreInstance proCore)
	{
		return new ResiPlugin(proCore, errorPrompt, app, autoStart: true);
	}

	static CoreManager GetCoreManager(CoreManager manager)
	{
		return manager;
	}

	static INetworkCommandFactory GetNetworkCommandFactory(IOutputRepository outputRepository)
	{
		return new NetworkCommandFactory(DataVault.TimerDocument.Timers, DataVault.StagePresentation, outputRepository.StageScreenArrangementCollection);
	}

	static INetworkTriggerDataTransferFactory GetNetworkTriggerDataTransferFactory(IOutputConfiguration outputConfiguration)
	{
		return new NetworkTriggerDataTransferFactory(DataVault.ClearGroups, DataVault.LibraryCollection, DataVault.LibraryPlaylistCollection, DataVault.VisualPlaylistCollection, DataVault.AudioPlaylistCollection, DataVault.PropSource, DataVault.TimerDocument.Timers, DataVault.Messages, DataVault.MacroSource, outputConfiguration.AudienceLooks);
	}

	static AudioOutputDeviceCollection GetAudioOutputDeviceCollection(ssAPIOutput ssAPI)
	{
		return ssAPI.AvailableAudioOutputs;
	}

	static TransitionDescriptionCollection GetTransitionDescriptionCollection(ssAPIOutput ssAPI)
	{
		return ssAPI.AvailableTransitions;
	}
}
