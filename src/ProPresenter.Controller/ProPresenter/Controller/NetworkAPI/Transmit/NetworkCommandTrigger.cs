using System;
using ProPresenter.Controller.NetworkAPI.Transmit.Command;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit;

public class NetworkCommandTrigger : INetworkCommandTrigger
{
	private readonly INetworkCommandFactory _commandFactory;

	public event Action<INetworkCommand>? TriggerCommand;

	public NetworkCommandTrigger(INetworkCommandFactory commandFactory)
	{
		_commandFactory = commandFactory;
	}

	public void OnConfigureTimer(TimerData timer)
	{
		OnTriggerCommand(_commandFactory.CreateConfigureTimerCommand(timer));
	}

	public void OnPlay(ProLayerIndex layer)
	{
		OnTriggerCommand(_commandFactory.CreatePlayTransportCommand(layer));
	}

	public void OnPause(ProLayerIndex layer)
	{
		OnTriggerCommand(_commandFactory.CreatePauseTransportCommand(layer));
	}

	public void OnSkipBackward(ProLayerIndex layer, int seconds)
	{
		OnTriggerCommand(_commandFactory.CreateSkipBackwardTransportCommand(layer, seconds));
	}

	public void OnSkipForward(ProLayerIndex layer, int seconds)
	{
		OnTriggerCommand(_commandFactory.CreateSkipForwardTransportCommand(layer, seconds));
	}

	public void OnGotoEnd(ProLayerIndex layer, int secondsToEnd)
	{
		OnTriggerCommand(_commandFactory.CreateGotoEndTransportCommand(layer, secondsToEnd));
	}

	public void OnChangeStageLayout(StageScreenLayoutMap stageScreenLayoutMap)
	{
		OnTriggerCommand(_commandFactory.CreateStageLayoutCommand(stageScreenLayoutMap));
	}

	public void OnShowStageMessage(string message)
	{
		OnTriggerCommand(_commandFactory.CreateStageShowMessageCommand(message));
	}

	public void OnHideStageMessage()
	{
		OnTriggerCommand(_commandFactory.CreateStageHideMessageCommand());
	}

	private void OnTriggerCommand(INetworkCommand command)
	{
		if (command != null)
		{
			this.TriggerCommand?.Invoke(command);
		}
	}
}
