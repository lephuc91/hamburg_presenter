using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ThemeAppliedEvent(ThemeAppliedTargetEnum Target) : IAnalyticEvent
{
	public static void Publish(ThemeAppliedTargetEnum themeAppliedTarget)
	{
		EventPublisher.Publish(new ThemeAppliedEvent(themeAppliedTarget));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			ToolbarThemeApplication toolbarThemeApplication = new ToolbarThemeApplication();
			ToolbarThemeApplication toolbarThemeApplication2 = toolbarThemeApplication;
			toolbarThemeApplication2.Target = Target switch
			{
				ThemeAppliedTargetEnum.SlideSelection => ToolbarThemeApplication.Types.Target.SlideSelection, 
				ThemeAppliedTargetEnum.PresentationSelection => ToolbarThemeApplication.Types.Target.PresentationSelection, 
				_ => ToolbarThemeApplication.Types.Target.Unknown, 
			};
			e.UiToolbarThemeApplication = toolbarThemeApplication;
		});
	}
}
