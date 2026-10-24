using System.ComponentModel;
using Pro.DO.Triggering;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class ElapsedTimerVM : TimerVM, IElapsedTimerVM, ITimerVM, ITriggerable, INotifyPropertyChanged
{
	private ElapsedTime ElapsedTime => (ElapsedTime)base.TimerData.Source;

	public bool HasEndTime
	{
		get
		{
			return ElapsedTime.HasEndTime;
		}
		set
		{
			if (ElapsedTime.HasEndTime != value)
			{
				ElapsedTime.HasEndTime = value;
				TimersEditEvent.Publish(EditField.Value);
			}
		}
	}

	public ElapsedTimerVM(TimerData timerData, INetworkCommandTrigger linkTrigger, IApp app)
		: base(timerData, linkTrigger, app)
	{
		LinkProperties("HasEndTime", "HasEndTime");
	}
}
