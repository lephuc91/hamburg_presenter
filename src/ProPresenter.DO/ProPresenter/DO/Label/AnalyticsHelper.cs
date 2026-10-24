using System.Linq;
using Pro.DO.Analytics;
using ProPresenter.DO.Analytics;

namespace ProPresenter.DO.Label;

public static class AnalyticsHelper
{
	public static IAnalyticEvent? ToShownEvent(this ILabelInteractor? labelInteractor)
	{
		if (labelInteractor is SlideLabelInteractor)
		{
			return new SlideLabelShownEvent();
		}
		return null;
	}

	public static IAnalyticEvent? ToChangedEvent(this ISlideLabelContext? context)
	{
		if (context is MultiTargetSlideLabelContext multiTargetSlideLabelContext)
		{
			return new SlideLabelChangedEvent(multiTargetSlideLabelContext.Cues.Count(), SlideLabelChangeSource.Popover);
		}
		return null;
	}
}
