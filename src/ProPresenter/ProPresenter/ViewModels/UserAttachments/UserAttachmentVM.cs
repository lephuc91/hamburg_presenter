using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Nullability;
using Pro.Common.Security;
using Pro.Localization;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using ProPresenter.UI.UserAttachments;
using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.ViewModels.UserAttachments;

public class UserAttachmentVM : ObservableObject, IUserAttachment, IEquatable<IUserAttachment>, IEqualityComparer<UserAttachmentVM>
{
	private readonly Dictionary<string, string> _fileExtentionDisplayNames = new Dictionary<string, string>
	{
		[".systeminfo"] = "ATTACH_FILE_TYPE_SYSTEM_DIAGNOSTICS_title",
		["Log.txt"] = "ATTACH_FILE_TYPE_PROGRAM_FILE_LOG_title",
		[".crash"] = "ATTACH_FILE_TYPE_CRASH_REPORT_title",
		[".mdmp"] = "ATTACH_FILE_TYPE_MEMORY_DUMP_title",
		["AppMetadata.json"] = "ATTACH_FILE_TYPE_APPLICATION_METADATA_title",
		["CRDTDocuments.zip"] = "ATTACH_FILE_TYPE_CRDT_DOCUMENTS_title"
	};

	[ObservableProperty]
	[ReadOnly(true)]
	[NotifyPropertyChangedFor("FileNameShort")]
	[NotifyPropertyChangedFor("DisplayName")]
	[NotifyPropertyChangedFor("Exists")]
	[NotifyPropertyChangedFor("Extension")]
	private string _fileName;

	[ObservableProperty]
	private bool _isValid;

	[ObservableProperty]
	private string? _displayName;

	[ObservableProperty]
	private bool _isReadOnly;

	[ObservableProperty]
	private bool _isUploaded;

	[ObservableProperty]
	private string? _viewUrl;

	[ObservableProperty]
	private string? _uploadUrl;

	[ObservableProperty]
	private long _fileSize;

	[ObservableProperty]
	private string _fileShaHash = string.Empty;

	[ObservableProperty]
	private bool _attachmentInProgress;

	public string FileNameShort => Path.GetFileName(FileName);

	public bool Exists => File.Exists(FileName);

	public string Extension => Path.GetExtension(FileName);

	public IReadOnlyList<UploadHeader> UploadHeaders { get; set; } = Array.Empty<UploadHeader>();

	public string Identifier { get; set; } = string.Empty;

	[MemberNotNullWhen(true, "UploadUrl")]
	public bool IsReadyToSend
	{
		[MemberNotNullWhen(true, "UploadUrl")]
		get
		{
			if (IsValid && !UploadUrl.NullableIsNullOrEmpty())
			{
				return !Identifier.NullableIsNullOrEmpty();
			}
			return false;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string FileName
	{
		get
		{
			return _fileName;
		}
		[MemberNotNull("_fileName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_fileName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FileName);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FileNameShort);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DisplayName);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Exists);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Extension);
				_fileName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FileName);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FileNameShort);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DisplayName);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Exists);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Extension);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsValid
	{
		get
		{
			return _isValid;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isValid, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsValid);
				_isValid = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsValid);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? DisplayName
	{
		get
		{
			return _displayName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_displayName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DisplayName);
				_displayName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DisplayName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsReadOnly
	{
		get
		{
			return _isReadOnly;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isReadOnly, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsReadOnly);
				_isReadOnly = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsReadOnly);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsUploaded
	{
		get
		{
			return _isUploaded;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isUploaded, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsUploaded);
				_isUploaded = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsUploaded);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? ViewUrl
	{
		get
		{
			return _viewUrl;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_viewUrl, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ViewUrl);
				_viewUrl = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ViewUrl);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? UploadUrl
	{
		get
		{
			return _uploadUrl;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_uploadUrl, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UploadUrl);
				_uploadUrl = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UploadUrl);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long FileSize
	{
		get
		{
			return _fileSize;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_fileSize, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FileSize);
				_fileSize = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FileSize);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string FileShaHash
	{
		get
		{
			return _fileShaHash;
		}
		[MemberNotNull("_fileShaHash")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_fileShaHash, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FileShaHash);
				_fileShaHash = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FileShaHash);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool AttachmentInProgress
	{
		get
		{
			return _attachmentInProgress;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_attachmentInProgress, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AttachmentInProgress);
				_attachmentInProgress = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AttachmentInProgress);
			}
		}
	}

	public UserAttachmentVM(string filename, bool isReadOnly = false)
	{
		_fileName = filename.Trim();
		if (Exists)
		{
			_isReadOnly = isReadOnly;
			_fileSize = new FileInfo(FileName).Length;
			_fileShaHash = GetHash();
			_displayName = CalculateDisplayName();
			Validate(null);
		}
	}

	private string CalculateDisplayName()
	{
		string value = string.Empty;
		_fileExtentionDisplayNames.TryGetValue(Path.GetExtension(FileName), out value);
		if (string.IsNullOrEmpty(value))
		{
			_fileExtentionDisplayNames.TryGetValue(Path.GetFileName(FileName), out value);
		}
		if (!string.IsNullOrEmpty(value))
		{
			return LocalizedStrings.Get(value);
		}
		return FileNameShort;
	}

	public bool Validate()
	{
		GetHash();
		IsValid = Exists && !string.IsNullOrEmpty(FileShaHash);
		return IsValid;
	}

	public bool Validate(IUserAttachSettings? userAttachSettings)
	{
		if (userAttachSettings == null)
		{
			return Validate();
		}
		UserAttachmentLimit userAttachmentLimit = userAttachSettings.AttachmentLimits.FirstOrDefault((UserAttachmentLimit i) => !string.IsNullOrEmpty(i.Extension) && i.Extension.Equals(Extension, StringComparison.InvariantCultureIgnoreCase));
		if (userAttachmentLimit != null && (FileSize <= userAttachmentLimit.SizeLimit || userAttachmentLimit.SizeLimit == 0L))
		{
			return Validate();
		}
		if (FileSize > userAttachSettings.MaxAttachmentSize)
		{
			return userAttachSettings.MaxAttachmentSize == 0;
		}
		return true;
	}

	private string GetHash()
	{
		try
		{
			if (!FileShaHash.NullableIsNullOrEmpty())
			{
				return FileShaHash;
			}
			if (!Exists)
			{
				return string.Empty;
			}
			using FileStream data = File.OpenRead(FileName);
			return data.Hash();
		}
		catch
		{
			return string.Empty;
		}
	}

	public Attachment ToFileAttachment()
	{
		return new Attachment(new AttachmentMetadata(FileNameShort, FileShaHash, FileSize), Identifier);
	}

	public bool Equals(IUserAttachment? other)
	{
		return other?.FileName.Equals(FileName) ?? false;
	}

	public bool Equals(UserAttachmentVM? x, UserAttachmentVM? y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null)
		{
			return false;
		}
		return x.FileName.Equals(y.FileName);
	}

	public int GetHashCode(UserAttachmentVM obj)
	{
		return GetHash().GetHashCode();
	}
}
