using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public interface INetworkCommandFactory
{
	INetworkCommand CreateConfigureTimerCommand(TimerData timer);

	INetworkCommand CreatePlayTransportCommand(ProLayerIndex layer);

	INetworkCommand CreatePauseTransportCommand(ProLayerIndex layer);

	INetworkCommand CreateSkipBackwardTransportCommand(ProLayerIndex layer, int seconds);

	INetworkCommand CreateSkipForwardTransportCommand(ProLayerIndex layer, int seconds);

	INetworkCommand CreateGotoEndTransportCommand(ProLayerIndex layer, int secondsToEnd);

	INetworkCommand CreateStageShowMessageCommand(string message);

	INetworkCommand CreateStageLayoutCommand(StageScreenLayoutMap stageScreenLayoutMap);

	INetworkCommand CreateStageHideMessageCommand();
}
