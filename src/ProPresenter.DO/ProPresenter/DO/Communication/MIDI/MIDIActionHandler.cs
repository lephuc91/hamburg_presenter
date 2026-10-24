using System;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Communication.MIDI;

public class MIDIActionHandler : IMIDIActionHandler
{
	private readonly IMIDIExecutor _executor;

	private readonly IMIDIDataProvider _dataProvider;

	public MIDIActionHandler(IMIDIExecutor executor, IMIDIDataProvider? dataProvider = null)
	{
		_executor = executor;
		_dataProvider = dataProvider ?? new MIDIDataProvider();
	}

	public void Handle(MIDIAction action, int index)
	{
		switch (action)
		{
		case MIDIAction.ClearAll:
			_executor.ClearAll();
			break;
		case MIDIAction.ClearSlide:
			_executor.ClearSlide();
			break;
		case MIDIAction.ClearBackground:
			_executor.ClearBackground();
			break;
		case MIDIAction.ClearAnnouncements:
			_executor.ClearAnnouncements();
			break;
		case MIDIAction.ClearProps:
			_executor.ClearProps();
			break;
		case MIDIAction.ClearMessages:
			_executor.ClearMessages();
			break;
		case MIDIAction.ClearAudio:
			_executor.ClearAudio();
			break;
		case MIDIAction.ShowLogo:
			_executor.TriggerLogo();
			break;
		case MIDIAction.GoToVideoBeginning:
			_executor.RestartBackgroundVideo();
			break;
		case MIDIAction.PlayPauseVideo:
			_executor.ToggleVideo();
			break;
		case MIDIAction.PlayVideo:
			_executor.PlayVideo();
			break;
		case MIDIAction.PauseVideo:
			_executor.PauseVideo();
			break;
		case MIDIAction.NextPlaylistItem:
			_executor.GoToNextPlaylistItem();
			break;
		case MIDIAction.PreviousPlaylistItem:
			_executor.GoToPreviousPlaylistItem();
			break;
		case MIDIAction.NextSlide:
			_executor.TriggerNextSlide();
			break;
		case MIDIAction.PreviousSlide:
			_executor.TriggerPreviousSlide();
			break;
		case MIDIAction.StartTimeline:
			_executor.StartTimeline();
			break;
		case MIDIAction.StopTimeline:
			_executor.PauseTimeline();
			break;
		case MIDIAction.RewindTimeline:
			_executor.ResetTimeline();
			break;
		case MIDIAction.SelectPlaylist:
			_executor.SelectPlaylist(_dataProvider.GetPlaylist(index));
			break;
		case MIDIAction.SelectPlaylistItem:
			_executor.SelectPlaylistItem(index);
			break;
		case MIDIAction.TriggerSlideCue:
			_executor.TriggerSlide(index);
			break;
		case MIDIAction.SelectVisualPlaylist:
			_executor.SelectVisualPlaylist(_dataProvider.GetVisualPlaylist(index));
			break;
		case MIDIAction.TriggerVisualCue:
			_executor.TriggerVisualCue(index);
			break;
		case MIDIAction.SelectAudioPlaylist:
			_executor.SelectAudioPlaylist(_dataProvider.GetAudioPlaylist(index));
			break;
		case MIDIAction.TriggerAudioCue:
			_executor.TriggerAudioCue(index);
			break;
		case MIDIAction.ToggleProps:
		{
			IPropCue prop = _dataProvider.GetProp(index);
			if (prop != null)
			{
				_executor.ToggleProp(prop);
			}
			break;
		}
		case MIDIAction.StartTimer:
		{
			TimerData timer3 = _dataProvider.GetTimer(index);
			if (timer3 != null)
			{
				_executor.StartTimer(timer3);
			}
			break;
		}
		case MIDIAction.StopTimer:
		{
			TimerData timer2 = _dataProvider.GetTimer(index);
			if (timer2 != null)
			{
				_executor.StopTimer(timer2);
			}
			break;
		}
		case MIDIAction.ResetTimer:
		{
			TimerData timer = _dataProvider.GetTimer(index);
			if (timer != null)
			{
				_executor.ResetTimer(timer);
			}
			break;
		}
		case MIDIAction.TriggerMacro:
		{
			ProPresenterMacro macro = _dataProvider.GetMacro(index);
			if (macro != null)
			{
				_executor.TriggerMacro(macro);
			}
			break;
		}
		case MIDIAction.SelectMacroCollection:
			_executor.SelectMacroGroup(index);
			break;
		case MIDIAction.SelectPropCollection:
			_executor.SelectPropGroup(index);
			break;
		default:
			throw new NotSupportedException();
		}
	}
}
