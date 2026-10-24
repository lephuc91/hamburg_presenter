using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.NetworkAPI.Receive.Command;

public class CommandHandlerFactory : ICommandHandlerFactory
{
	private readonly ITriggering _triggering;

	private readonly IImmutableObservableCollection<TimerData>? _timers;

	private readonly StagePresentation _layouts;

	private readonly StageScreenArrangementCollection _stageScreens;

	public CommandHandlerFactory(ITriggering triggering, IImmutableObservableCollection<TimerData>? timers = null, StagePresentation? layouts = null, StageScreenArrangementCollection? stageScreens = null)
	{
		_triggering = triggering;
		_timers = timers ?? DataVault.TimerDocument?.Timers;
		_layouts = layouts ?? DataVault.StagePresentation;
		stageScreens = stageScreens ?? OutputVault.StageScreenArrangementCollection;
		stageScreens.ThrowWhenNull("stageScreens");
		_stageScreens = stageScreens;
	}

	public CommandHandlerBase? Create(Pro.SerializationInterop.RVProtoData.NetworkAPI protoNetworkAPI)
	{
		if (protoNetworkAPI.CommandCase == Pro.SerializationInterop.RVProtoData.NetworkAPI.CommandOneofCase.Action)
		{
			return protoNetworkAPI.Action.CommandCase switch
			{
				Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.CommandOneofCase.Transport => new TransportCommandHandler(_triggering), 
				Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.CommandOneofCase.Timer => new TimerCommandHandler(_triggering, _timers), 
				Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.CommandOneofCase.Stage => new StageCommandHandler(_triggering, _layouts, _stageScreens), 
				_ => null, 
			};
		}
		return null;
	}
}
