using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics.Events.Startup;

public record StartupThemesEvent(int ThemeCount, int ThemeFolderCount, int ThemeFolderMaxDepth, int ThemeSlideCount) : IAnalyticEvent
{
	public static void Publish(int themeCount, int themeFolderCount, int themeFolderMaxDepth, int themeSlideCount)
	{
		EventPublisher.Publish(new StartupThemesEvent(themeCount, themeFolderCount, themeFolderMaxDepth, themeSlideCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupThemes = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Themes
			{
				ThemeCount = ThemeCount,
				ThemeFolderCount = ThemeFolderCount,
				ThemeFolderMaxDepth = ThemeFolderMaxDepth,
				ThemeSlidesCount = ThemeSlideCount
			};
		});
	}
}
