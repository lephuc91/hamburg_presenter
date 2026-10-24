using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import.Requests;

public class GeneratedPresentationRequest : NotifyPropertyChangedBase, IImportRequest, INotifyPropertyChanged
{
	private ImportStatus _status;

	private string _finalName = string.Empty;

	public PresentationBase Presentation { get; private set; }

	public string Name => Presentation.Name;

	public ImportSource Source => ImportSource.Other;

	public string SanitizedFilename => Name.SanitizeFilename();

	public CCLIData CCLIInfo => Presentation.CCLIInfo;

	public MultiTracksLicenseData? MultiTracksInfo => null;

	public ImportStatus Status
	{
		get
		{
			return _status;
		}
		set
		{
			SetValue("Status", ref _status, value);
		}
	}

	public string FinalName
	{
		get
		{
			return _finalName;
		}
		set
		{
			SetValue("FinalName", ref _finalName, value);
		}
	}

	public GeneratedPresentationRequest(PresentationBase presentation)
	{
		Presentation = presentation;
	}

	public void UpdateNameWithCCLITitle()
	{
		throw new NotImplementedException();
	}
}
