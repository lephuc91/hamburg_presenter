using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.Localization;

namespace ProPresenter.DO.Slide;

public class GotoNext : LinkedNotifyPropertyChangedBase, IScrimSource, ICloneable<GotoNext>
{
	private TimeSlice _time;

	private bool _loopToBeginning;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public ActionType ActionType => ActionType.GoToNext;

	public string Name => LocalizedStrings.Get("ACTION_TYPE_GO_TO_NEXT_TIMER_title");

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;

	public TimeSlice Time
	{
		get
		{
			return _time;
		}
		set
		{
			SetValue("Time", ref _time, value);
		}
	}

	public bool LoopToBeginning
	{
		get
		{
			return _loopToBeginning;
		}
		set
		{
			SetValue("LoopToBeginning", ref _loopToBeginning, value);
		}
	}

	public GotoNext(TimeSlice time, bool loopToBeginning)
	{
		Time = time;
		LoopToBeginning = loopToBeginning;
	}

	public GotoNext()
	{
	}

	public GotoNext Clone()
	{
		return CopyProperties(new GotoNext());
	}

	private GotoNext CopyProperties(GotoNext gotoNext)
	{
		gotoNext.Time = _time;
		gotoNext.LoopToBeginning = _loopToBeginning;
		return gotoNext;
	}
}
