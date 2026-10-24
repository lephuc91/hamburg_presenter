namespace ProPresenter.DO.Analytics;

public interface IThemeAnalyiticEvents
{
	void Shown();

	void Applied(ThemeAppliedTargetEnum target);
}
