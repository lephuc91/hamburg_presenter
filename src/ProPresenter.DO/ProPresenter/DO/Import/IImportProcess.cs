using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import.AdditionalInfo;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Import;

public interface IImportProcess : INotifyPropertyChanged
{
	double CompletedPercentage { get; set; }

	IEnumerable<IImportRequest> CompletedRequests { get; }

	IImportRequest? CurrentRequest { get; set; }

	IPowerPointInfo? PowerPointInfo { get; set; }

	bool ImportCanceled { get; }

	bool AllowSelectPlaylist { get; }

	IImportRequest[] Requests { get; }

	ImportProcess.ResolveAnyConflictDelegate ResolveConflictProvider { get; set; }

	ILibrary? SelectedLibrary { get; set; }

	IPlaylist<ProPresenterCue>? SelectedPlaylist { get; set; }

	IImportRequest? SelectionRequest { get; set; }

	bool ShowProgressDialog { get; set; }

	event Action<IImportProcess> ImportComplete;

	void CancelImport();

	IImportResult? GetResultOfRequest(IImportRequest request);

	void StartImport();
}
