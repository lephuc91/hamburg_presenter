using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Import.Requests;

public class MemoryImportRequest : NotifyPropertyChangedBase, IImportRequest, INotifyPropertyChanged
{
	private ImportStatus _status;

	private string _finalName = string.Empty;

	public string Name { get; private set; }

	public ImportSource Source { get; }

	public string SanitizedFilename => Name.SanitizeFilename();

	public string Text { get; }

	public string? Notes { get; }

	public CCLIData CCLIInfo { get; }

	public MultiTracksLicenseData? MultiTracksInfo { get; }

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

	public Action<string>? CompleteCallback { get; set; }

	public MemoryImportRequest(string name, string text, string? notes = null, CCLIData? ccliInfo = null, MultiTracksLicenseData? multiTracksInfo = null, ImportSource source = ImportSource.Other)
	{
		Name = name;
		Text = text;
		Notes = notes;
		CCLIInfo = ccliInfo ?? new CCLIData();
		MultiTracksInfo = multiTracksInfo;
		Source = source;
	}

	public void UpdateNameWithCCLITitle()
	{
		if (!string.IsNullOrWhiteSpace(CCLIInfo.Title))
		{
			Name = CCLIInfo.Title;
			_finalName = CCLIInfo.Title;
		}
	}
}
