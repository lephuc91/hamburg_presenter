using ProPresenter.DO.Analytics.Events.TestPattern;

namespace ProPresenter.UI.TestPattern;

public static class TestPatternUIShownSourceExtensions
{
	public static TestPatternShownSource ToShownSource(this TestPatternUIShownSource source)
	{
		if (source == TestPatternUIShownSource.ScreenConfiguration)
		{
			return TestPatternShownSource.ScreenConfiguration;
		}
		return TestPatternShownSource.ApplicationMenu;
	}
}
