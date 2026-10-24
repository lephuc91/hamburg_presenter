using System;
using ProPresenter.Controller.NetworkAPI.Transmit.Command;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit;

public interface INetworkCommandTrigger
{
	event Action<INetworkCommand> TriggerCommand;

	void OnChangeStageLayout(StageScreenLayoutMap stageScreenLayoutMap);

	void OnConfigureTimer(TimerData timer);

	void OnGotoEnd(ProLayerIndex layer, int secondsToEnd);

	void OnHideStageMessage();

	void OnPause(ProLayerIndex layer);

	void OnPlay(ProLayerIndex layer);

	void OnShowStageMessage(string message);

	void OnSkipBackward(ProLayerIndex layer, int seconds);

	void OnSkipForward(ProLayerIndex layer, int seconds);
}
