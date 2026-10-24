using System;
using System.ComponentModel;
using System.IO;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Import.Requests;

public class FileImportRequest : NotifyPropertyChangedBase, IImportRequest, INotifyPropertyChanged
{
	private ImportStatus _status;

	private string _finalName = string.Empty;

	private FileInfo? _fileInfo;

	private string? _plainText;

	public string Name { get; private set; }

	public ImportSource Source { get; set; } = ImportSource.Other;

	public string SanitizedFilename => ((SkipFileExistCheck || (FullName.IsMediaFile() && !ForceManageMedia && !Advanced.Settings.ManageMediaAutomatically)) ? Name : Name.SanitizeFilename()).Normalize();

	public CCLIData CCLIInfo { get; } = new CCLIData();

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

	public string? TargetFolder { get; set; }

	public bool OverWriteOnConflict { get; set; }

	internal string Filename => _fileInfo?.Name ?? string.Empty;

	public string FullName => _fileInfo?.FullName ?? string.Empty;

	internal string PlainText => _plainText ?? string.Empty;

	internal bool HasPlainText => !string.IsNullOrWhiteSpace(_plainText);

	public PlaylistImportData? PlaylistImportData { get; set; }

	public ILibrary? TargetLibrary { get; set; }

	public bool IsPlaylist { get; set; }

	public bool ForceManageMedia { get; set; }

	public bool SkipFileExistCheck { get; set; }

	public Action<string, string, FileMediaBase?>? CompleteCallback { get; set; }

	public string FileExtension => _fileInfo?.Extension ?? string.Empty;

	public bool OverWrite { get; set; }

	public IImportRequest? ParentRequest { get; set; }

	public bool ShouldAddItemToPlaylist { get; set; } = true;

	public FileMediaBase? ExistingMedia { get; set; }

	public bool IsChordChartImport { get; set; }

	public string ContainerId { get; set; } = "";

	public Guid? OverrideMediaId { get; set; }

	public FileImportRequest(string? file, PlaylistImportData playlistImportData)
		: this(file)
	{
		PlaylistImportData = playlistImportData;
	}

	public FileImportRequest(string? file, CCLIData ccliInfo)
		: this(file)
	{
		CCLIInfo = ccliInfo;
	}

	public FileImportRequest(string? file, Action<string, string, FileMediaBase?> completeCallback)
		: this(file)
	{
		CompleteCallback = completeCallback;
	}

	public FileImportRequest(string? file)
	{
		if (string.IsNullOrWhiteSpace(file))
		{
			throw new ArgumentNullException("file");
		}
		_fileInfo = new FileInfo(file);
		Name = Path.GetFileNameWithoutExtension(_fileInfo.Name);
	}

	internal void ChangeFile(string newFile)
	{
		_fileInfo = new FileInfo(newFile);
		_plainText = null;
	}

	internal void SetPlainText(string plainText)
	{
		_fileInfo = null;
		_plainText = plainText;
	}

	internal void ChangeName(string newName)
	{
		if (!string.IsNullOrWhiteSpace(newName))
		{
			Name = newName;
		}
	}

	public void UpdateNameWithCCLITitle()
	{
		if (!string.IsNullOrWhiteSpace(CCLIInfo.Title))
		{
			Name = CCLIInfo.Title;
			FinalName = CCLIInfo.Title;
		}
	}
}
