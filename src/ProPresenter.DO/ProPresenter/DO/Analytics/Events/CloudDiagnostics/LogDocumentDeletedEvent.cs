using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Logs;

namespace ProPresenter.DO.Analytics.Events.CloudDiagnostics;

public record LogDocumentDeletedEvent(string DocumentId, string DocumentName, string WorkspaceId, string PeerId, string LogMessage) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.LogDocumentDeleted = new LogDocumentDeleted
			{
				DocumentIdentifier = DocumentId,
				DocumentName = DocumentName,
				Metadata = new LogMetadata
				{
					PeerId = PeerId,
					WorkspaceIdentifier = WorkspaceId,
					LogSource = LogSource.Client,
					LogMessage = LogMessage
				}
			};
		});
	}
}
