using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Logs;

namespace ProPresenter.DO.Analytics.Events.CloudDiagnostics;

public record LogDocumentUpdatedEvent(string DocumentId, string PreviousDocumentName, string UpdatedDocumentName, string WorkspaceId, string PeerId, string LogMessage) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.LogDocumentUpdated = new LogDocumentUpdated
			{
				DocumentIdentifier = DocumentId,
				PreviousDocumentName = PreviousDocumentName,
				UpdatedDocumentName = UpdatedDocumentName,
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
