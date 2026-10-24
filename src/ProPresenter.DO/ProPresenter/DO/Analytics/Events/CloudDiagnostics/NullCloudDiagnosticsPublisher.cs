using System;

namespace ProPresenter.DO.Analytics.Events.CloudDiagnostics;

public class NullCloudDiagnosticsPublisher : ICloudDiagnosticsPublisher
{
	public void DocumentUploaded(Guid documentId, string documentName, string logMessage)
	{
	}

	public void DocumentDownloaded(Guid documentId, string documentName, string logMessage)
	{
	}

	public void DiffPushed(Guid documentId, string documentName, string fromVersionVector, string logMessage)
	{
	}

	public void DiffReceived(Guid documentId, string documentName, string logMessage)
	{
	}

	public void DocumentUpdated(Guid documentId, string previousName, string updatedName, string logMessage)
	{
	}

	public void DocumentDeleted(Guid documentId, string documentName, string logMessage)
	{
	}

	public void Error(Guid documentId, string documentName, string logMessage)
	{
	}
}
