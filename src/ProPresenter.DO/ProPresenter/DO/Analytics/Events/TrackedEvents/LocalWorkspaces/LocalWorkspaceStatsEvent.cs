using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.LocalWorkspaces;

public record LocalWorkspaceStatsEvent(int TotalWorkspaces, int NumberOfWorkspaceSwitches) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.LocalWorkspaceStats = new LocalWorkspaceStats
			{
				TotalWorkspaces = TotalWorkspaces,
				NumberOfWorkspaceSwitches = NumberOfWorkspaceSwitches
			};
		});
	}
}
