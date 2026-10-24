using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics.Events.Startup;

public record StartupSettingsEvent(bool HouseOfWorship, bool CustomLogo, bool CopyrightEnabled, CopyRightStyleValue CopyRightStyleValue, bool CopyrightHasLicense, RenderModeValue RenderModeValue, bool SuppressAutoStart, bool ManageMediaAutomatically, bool SearchPathsRelink, UpdateChannelValue UpdateChannelValue) : IAnalyticEvent
{
	public static void Publish(bool houseOfWorship, bool customLogo, bool copyrightEnabled, CopyRightStyleValue copyRightStyleValue, bool copyrightHasLicense, RenderModeValue renderModeValue, bool suppressAutoStart, bool manageMediaAutomatically, bool searchPathsRelink, UpdateChannelValue updateChannelValue)
	{
		EventPublisher.Publish(new StartupSettingsEvent(houseOfWorship, customLogo, copyrightEnabled, copyRightStyleValue, copyrightHasLicense, renderModeValue, suppressAutoStart, manageMediaAutomatically, searchPathsRelink, updateChannelValue));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupPreferences = new Preferences
			{
				HouseOfWorship = HouseOfWorship,
				HasCustomLogo = CustomLogo,
				CopyrightEnabled = CopyrightEnabled,
				CopyrightStyle = CopyRightStyleValue.ToProto(),
				CopyrightHasLicense = CopyrightHasLicense,
				RenderMode = RenderModeValue.ToProto(),
				SuppressAutoStart = SuppressAutoStart,
				ManageMediaAutomatically = ManageMediaAutomatically,
				SearchPathsRelink = SearchPathsRelink,
				UpdateChannel = UpdateChannelValue.ToProto()
			};
		});
	}
}
