using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupKeyMappingEvent(int TotalMapped, int ClearGroups, int Groups, int Macros, int Props, int Menus) : IAnalyticEvent
{
	public static void Publish(int totalMapped, int clearGroups, int groups, int macros, int props, int menus)
	{
		EventPublisher.Publish(new StartupKeyMappingEvent(totalMapped, clearGroups, groups, macros, props, menus));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupKeyMapping = new KeyMapping
			{
				TotalMapped = TotalMapped,
				ClearGroups = ClearGroups,
				Groups = Groups,
				Macros = Macros,
				Props = Props,
				Menus = Menus
			};
		});
	}
}
