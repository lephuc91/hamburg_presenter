using System;

namespace ProPresenter.DO.Analytics.Events.CloudDiagnostics;

public interface ICloudDiagnosticsPublisher
{
	void DocumentUploaded(Guid documentId, string documentName, string logMessage);

	void DocumentDownloaded(Guid documentId, string documentName, string logMessage);

	void DiffPushed(Guid documentId, string documentName, string fromVersionVector, string logMessage);

	void DiffReceived(Guid documentId, string documentName, string logMessage);

	void DocumentUpdated(Guid documentId, string previousName, string updatedName, string logMessage);

	void DocumentDeleted(Guid documentId, string documentName, string logMessage);

	void Error(Guid documentId, string documentName, string logMessage);
}
