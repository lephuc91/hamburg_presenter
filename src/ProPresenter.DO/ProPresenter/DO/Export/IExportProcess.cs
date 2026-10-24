using System;

namespace ProPresenter.DO.Export;

public interface IExportProcess
{
	int CompletedCount { get; }

	IExportRequest? CurrentRequest { get; }

	bool ExportCanceled { get; }

	string Destination { get; }

	event Action ExportComplete;

	void CancelExport();

	void StartExport();
}
