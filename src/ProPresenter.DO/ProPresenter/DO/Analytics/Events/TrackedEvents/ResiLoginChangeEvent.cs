using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record ResiLoginChangeEvent(bool LogedIn) : IAnalyticEvent
{
	public static void Publish(bool logedIn)
	{
		EventPublisher.Publish(new ResiLoginChangeEvent(logedIn));
	}

	public static ResiLoginChange.Types.LoginState TranslateEnumToProtoEnum(bool loggedIn)
	{
		if (!loggedIn)
		{
			return ResiLoginChange.Types.LoginState.Loggedout;
		}
		return ResiLoginChange.Types.LoginState.Loggedin;
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ResiLoginChange = new ResiLoginChange
			{
				State = TranslateEnumToProtoEnum(LogedIn)
			};
		});
	}
}
