using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.UIPreferences;

public class UiPreferencesAnalyticEventsPublisher : IUiPreferencesAnalyticEventsPublisher
{
	public void HasLogo(bool hasLogo)
	{
		EventPublisher.Publish(new UiPreferencesEvent(hasLogo));
	}
}
