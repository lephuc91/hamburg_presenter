using System;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;

public record WorkspaceCreationEvent(WorkspaceCreationSource Source, TimeSpan CreationDuration) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.WorkspaceCreation = new WorkspaceCreation
			{
				Source = (WorkspaceCreation.Types.Source)Source,
				DurationSeconds = (ulong)CreationDuration.TotalSeconds
			};
		});
	}
}
