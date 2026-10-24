using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.TestPattern;

public static class TestPatternShownSourceExtensions
{
	public static TestPatterns.Types.Source ToProto(this TestPatternShownSource testPatternShownSource)
	{
		if (testPatternShownSource == TestPatternShownSource.ScreenConfiguration)
		{
			return TestPatterns.Types.Source.ScreenConfiguration;
		}
		return TestPatterns.Types.Source.ApplicationMenu;
	}
}
