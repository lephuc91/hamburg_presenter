namespace ProPresenter.DO.Analytics;

public class ThemeAnalyticEvents : IThemeAnalyiticEvents
{
	public void Shown()
	{
		ThemeShowEvent.Publish();
	}

	public void Applied(ThemeAppliedTargetEnum target)
	{
		ThemeAppliedEvent.Publish(target);
	}
}
