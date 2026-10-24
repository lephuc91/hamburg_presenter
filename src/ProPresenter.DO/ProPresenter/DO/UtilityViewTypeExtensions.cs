using ProPresenter.DO.Analytics;

namespace ProPresenter.DO;

public static class UtilityViewTypeExtensions
{
	public static void Publish(this UtilityViewType viewType)
	{
		switch (viewType)
		{
		case UtilityViewType.Timers:
			TimersShownEvent.Publish();
			break;
		case UtilityViewType.Props:
			PropsShownEvent.Publish();
			break;
		case UtilityViewType.Stage:
			StageShownEvent.Publish();
			break;
		case UtilityViewType.Messages:
			MessagesShownEvent.Publish();
			break;
		case UtilityViewType.Macros:
			MacrosShownEvent.Publish();
			break;
		case UtilityViewType.Audio:
			break;
		}
	}
}
