using System.ComponentModel;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import;

public interface IImportRequest : INotifyPropertyChanged
{
	string Name { get; }

	ImportSource Source { get; }

	string SanitizedFilename { get; }

	CCLIData CCLIInfo { get; }

	MultiTracksLicenseData? MultiTracksInfo { get; }

	ImportStatus Status { get; set; }

	string FinalName { get; set; }

	void UpdateNameWithCCLITitle();
}
