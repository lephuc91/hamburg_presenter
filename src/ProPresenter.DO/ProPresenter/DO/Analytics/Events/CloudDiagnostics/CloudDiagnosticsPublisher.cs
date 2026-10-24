using System;
using System.Linq;
using Pro.DO.Analytics;
using Pro.Entity.Persistence;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Analytics.Events.CloudDiagnostics;

public class CloudDiagnosticsPublisher : ICloudDiagnosticsPublisher
{
	private readonly string _peerId;

	private readonly IWorkspaceService _workspaceService;

	private string WorkspaceId => _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active)?.CloudId?.ToString() ?? string.Empty;

	public CloudDiagnosticsPublisher(ICollaborationPeerIdProvider peerIdProvider, IWorkspaceService workspaceService)
	{
		_peerId = peerIdProvider.CollaborationPeerId.ToString();
		_workspaceService = workspaceService;
	}

	public void DocumentUploaded(Guid documentId, string documentName, string logMessage)
	{
		EventPublisher.Publish(new LogDocumentUploadedEvent(documentId.ToString(), documentName, WorkspaceId, _peerId, logMessage));
	}

	public void DocumentDownloaded(Guid documentId, string documentName, string logMessage)
	{
		EventPublisher.Publish(new LogDocumentDownloadedEvent(documentId.ToString(), documentName, WorkspaceId, _peerId, logMessage));
	}

	public void DiffPushed(Guid documentId, string documentName, string fromVersionVector, string logMessage)
	{
		EventPublisher.Publish(new LogDiffPushedEvent(documentId.ToString(), documentName, WorkspaceId, _peerId, fromVersionVector, logMessage));
	}

	public void DiffReceived(Guid documentId, string documentName, string logMessage)
	{
		EventPublisher.Publish(new LogDiffReceivedEvent(documentId.ToString(), documentName, WorkspaceId, _peerId, logMessage));
	}

	public void DocumentUpdated(Guid documentId, string previousName, string updatedName, string logMessage)
	{
		EventPublisher.Publish(new LogDocumentUpdatedEvent(documentId.ToString(), previousName, updatedName, WorkspaceId, _peerId, logMessage));
	}

	public void DocumentDeleted(Guid documentId, string documentName, string logMessage)
	{
		EventPublisher.Publish(new LogDocumentDeletedEvent(documentId.ToString(), documentName, WorkspaceId, _peerId, logMessage));
	}

	public void Error(Guid documentId, string documentName, string logMessage)
	{
		EventPublisher.Publish(new LogErrorEvent(documentId.ToString(), documentName, WorkspaceId, _peerId, logMessage));
	}
}
