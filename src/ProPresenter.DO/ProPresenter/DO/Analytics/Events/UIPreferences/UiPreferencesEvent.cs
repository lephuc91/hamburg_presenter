using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.UIPreferences;

public record UiPreferencesEvent(bool HasLogo) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiSettingsCustomLogo = new SettingsCustomLogo
			{
				HasLogo = HasLogo
			};
		});
	}
}
