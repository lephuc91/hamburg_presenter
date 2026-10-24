using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI.Transmit.Command;

public class NetworkCommandFactory : INetworkCommandFactory
{
	private readonly IImmutableObservableCollection<TimerData>? _timers;

	private readonly StagePresentation _layouts;

	private readonly StageScreenArrangementCollection _stageScreens;

	public NetworkCommandFactory(IImmutableObservableCollection<TimerData> timers, StagePresentation layouts, StageScreenArrangementCollection stageScreens)
	{
		_timers = timers;
		_layouts = layouts;
		_stageScreens = stageScreens;
	}

	public INetworkCommand CreateConfigureTimerCommand(TimerData timer)
	{
		return new ConfigureTimerCommand(_timers?.IndexOf(timer) ?? (-1), timer.Source);
	}

	public INetworkCommand CreateGotoEndTransportCommand(ProLayerIndex layer, int secondsToEnd)
	{
		return new GotoEndCommand(layer, secondsToEnd);
	}

	public INetworkCommand CreatePauseTransportCommand(ProLayerIndex layer)
	{
		return new PauseCommand(layer);
	}

	public INetworkCommand CreatePlayTransportCommand(ProLayerIndex layer)
	{
		return new PlayCommand(layer);
	}

	public INetworkCommand CreateSkipBackwardTransportCommand(ProLayerIndex layer, int seconds)
	{
		return new SkipBackwardCommand(layer, seconds);
	}

	public INetworkCommand CreateSkipForwardTransportCommand(ProLayerIndex layer, int seconds)
	{
		return new SkipForwardCommand(layer, seconds);
	}

	public INetworkCommand CreateStageHideMessageCommand()
	{
		return new HideStageMessageCommand();
	}

	public INetworkCommand CreateStageLayoutCommand(StageScreenLayoutMap stageScreenLayoutMap)
	{
		List<(int, int)> list = new List<(int, int)>();
		ScreenArrangementBase[] array = _stageScreens.ToArray();
		SlideCue[] array2 = _layouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue a) => a.Source).ToArray();
		foreach (KeyValuePair<ScreenArrangementBase, SlideCue> item3 in stageScreenLayoutMap)
		{
			int item = array.IndexOf(item3.Key);
			int item2 = array2.IndexOf(item3.Value);
			list.Add((item, item2));
		}
		return new ChangeStageLayoutCommand(list);
	}

	public INetworkCommand CreateStageShowMessageCommand(string message)
	{
		return new ShowStageMessageCommand(message);
	}
}
