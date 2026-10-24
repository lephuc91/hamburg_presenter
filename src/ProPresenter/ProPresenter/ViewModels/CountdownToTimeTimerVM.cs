using System.ComponentModel;
using Pro.DO.Triggering;
using Pro.Localization;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class CountdownToTimeTimerVM : TimerVM, ICountdownToTimeTimerVM, ITimerVM, ITriggerable, INotifyPropertyChanged
{
	private CountdownToTime CountdownToTime => (CountdownToTime)base.TimerData.Source;

	public override string RunningTime
	{
		get
		{
			if (base.State != 0)
			{
				return base.RunningTime;
			}
			return GetRunningTime();
		}
	}

	public TimeFormat TimeFormat
	{
		get
		{
			return CountdownToTime.TimeFormat;
		}
		set
		{
			if (CountdownToTime.TimeFormat != value)
			{
				CountdownToTime.TimeFormat = value;
				TimersEditEvent.Publish(EditField.Value);
				base.LinkTrigger?.OnConfigureTimer(base.TimerData);
			}
		}
	}

	public CountdownToTimeTimerVM(TimerData timerData, INetworkCommandTrigger linkTrigger, IApp app)
		: base(timerData, linkTrigger, app)
	{
		LinkProperties("TimeFormat", "TimeFormat");
	}

	private string GetRunningTime()
	{
		if (!(base.TimerData.Source is CountdownToTime countdownToTime))
		{
			return string.Empty;
		}
		bool flag = countdownToTime.TimeFormat == TimeFormat.TwentyFour;
		string text = new TimerFormatData
		{
			HourFormat = ((!flag) ? TimerFormatStyle.Short : TimerFormatStyle.Long),
			MinuteFormat = TimerFormatStyle.Long,
			SecondFormat = TimerFormatStyle.ShortTruncated
		}.FormatTime(countdownToTime.EndTime);
		string text2 = (flag ? string.Empty : LocalizedStrings.Get(countdownToTime.TimeFormat));
		return LocalizedStrings.Get("TIMERS_WINDOW_TIMER_TYPE_COUNTDOWN_TO_TIME_text", new object[1] { text + " " + text2 });
	}
}
