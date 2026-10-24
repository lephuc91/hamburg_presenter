using System;
using System.Globalization;
using System.Windows.Media;
using Pro.UI.Converters;
using ProPresenter.DO.Timer;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Timer;

public class TimerStateToBackgroundConverter : ValueConverterBase<TimerState, Brush>
{
	protected override Brush ConvertValue(TimerState value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = default(bool);
		int num;
		if (parameter is bool)
		{
			flag = (bool)parameter;
			num = 1;
		}
		else
		{
			num = 0;
		}
		bool flag2 = (byte)((uint)num & (flag ? 1u : 0u)) != 0;
		switch (value)
		{
		case TimerState.Started:
			return (Brush)(flag2 ? AppTheme.Active.UTILITYVIEW_TIMER_RUNNING_SETTINGS : AppTheme.Active.UTILITYVIEW_TIMER_RUNNING);
		case TimerState.Expired:
			return (Brush)(flag2 ? AppTheme.Active.UTILITYVIEW_TIMER_EXPIRED_SETTINGS : AppTheme.Active.UTILITYVIEW_TIMER_EXPIRED);
		case TimerState.Overrunning:
		case TimerState.Overran:
			return (Brush)(flag2 ? AppTheme.Active.UTILITYVIEW_TIMER_OVERRUN_SETTINGS : AppTheme.Active.UTILITYVIEW_TIMER_OVERRUN);
		case TimerState.Reset:
		case TimerState.Paused:
			return (Brush)(flag2 ? AppTheme.Active.OUTLINEDETAIL : AppTheme.Active.OUTLINESOURCE);
		default:
			return new SolidColorBrush(Colors.Transparent);
		}
	}
}
