using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;

namespace ProPresenter.ViewModels;

public class CountdownTimerVM : TimerVM
{
	public CountdownTimerVM(TimerData timerData, INetworkCommandTrigger linkTrigger, IApp app)
		: base(timerData, linkTrigger, app)
	{
	}
}
