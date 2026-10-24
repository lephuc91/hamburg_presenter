using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Nullability;
using Semver;

namespace ProPresenter.DO.Workspaces;

public class Workspace : ObservableObject, IWorkspace, INotifyPropertyChanged
{
	private sealed record SerializedWorkspace(string Name, bool Active, string Path, Guid? CloudId, ulong? WorkspaceSizeInBytes, WorkspaceType WorkspaceType, DateTimeOffset? LastModified, string MinimumRequiredAppVersion);

	[ObservableProperty]
	private string _name;

	[ObservableProperty]
	private bool _active;

	[ObservableProperty]
	private string _path;

	[ObservableProperty]
	private Guid? _cloudId;

	[ObservableProperty]
	private ulong? _workspaceSizeInBytes;

	[ObservableProperty]
	private WorkspaceType _workspaceType;

	[ObservableProperty]
	private DateTimeOffset? _lastModified;

	[ObservableProperty]
	private SemVersion _minimumRequiredAppVersion;

	public static SemVersion CurrentDataModelVersion { get; } = new SemVersion(22);

	public static SemVersion FallbackDataModelVersion { get; } = new SemVersion(0);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool Active
	{
		get
		{
			return _active;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_active, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Active);
				_active = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Active);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Path
	{
		get
		{
			return _path;
		}
		[MemberNotNull("_path")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_path, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Path);
				_path = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Path);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guid? CloudId
	{
		get
		{
			return _cloudId;
		}
		set
		{
			if (!EqualityComparer<Guid?>.Default.Equals(_cloudId, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CloudId);
				_cloudId = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CloudId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ulong? WorkspaceSizeInBytes
	{
		get
		{
			return _workspaceSizeInBytes;
		}
		set
		{
			if (!EqualityComparer<ulong?>.Default.Equals(_workspaceSizeInBytes, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.WorkspaceSizeInBytes);
				_workspaceSizeInBytes = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.WorkspaceSizeInBytes);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public WorkspaceType WorkspaceType
	{
		get
		{
			return _workspaceType;
		}
		set
		{
			if (!EqualityComparer<WorkspaceType>.Default.Equals(_workspaceType, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.WorkspaceType);
				_workspaceType = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.WorkspaceType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset? LastModified
	{
		get
		{
			return _lastModified;
		}
		set
		{
			if (!EqualityComparer<DateTimeOffset?>.Default.Equals(_lastModified, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LastModified);
				_lastModified = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LastModified);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SemVersion MinimumRequiredAppVersion
	{
		get
		{
			return _minimumRequiredAppVersion;
		}
		[MemberNotNull("_minimumRequiredAppVersion")]
		set
		{
			if (!EqualityComparer<SemVersion>.Default.Equals(_minimumRequiredAppVersion, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.MinimumRequiredAppVersion);
				_minimumRequiredAppVersion = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.MinimumRequiredAppVersion);
			}
		}
	}

	internal Workspace(string name, string path, DateTimeOffset? lastModified, Guid? cloudId, ulong? workspaceSizeInBytes, WorkspaceType workspaceType)
		: this(name, path, lastModified, CurrentDataModelVersion, cloudId, workspaceSizeInBytes, workspaceType)
	{
	}

	private Workspace(string name, string path, DateTimeOffset? lastModified, SemVersion minimumRequiredAppVersion, Guid? cloudId, ulong? workspaceSizeInBytes, WorkspaceType workspaceType)
	{
		_name = name;
		_path = path;
		_cloudId = cloudId;
		_minimumRequiredAppVersion = minimumRequiredAppVersion;
		_workspaceSizeInBytes = workspaceSizeInBytes;
		LastModified = lastModified;
		_workspaceType = workspaceType;
	}

	public static string Encode(IWorkspace workspace)
	{
		return JsonSerializer.Serialize(new SerializedWorkspace(workspace.Name, workspace.Active, workspace.Path, workspace.CloudId, workspace.WorkspaceSizeInBytes, workspace.WorkspaceType, workspace.LastModified, workspace.MinimumRequiredAppVersion.ToString()));
	}

	public static IWorkspace Decode(string json)
	{
		SerializedWorkspace serializedWorkspace = JsonSerializer.Deserialize<SerializedWorkspace>(json);
		serializedWorkspace.ThrowWhenNull("workspace");
		if (!SemVersion.TryParse(serializedWorkspace.MinimumRequiredAppVersion, SemVersionStyles.Any, out SemVersion semver))
		{
			semver = FallbackDataModelVersion;
		}
		return new Workspace(serializedWorkspace.Name, serializedWorkspace.Path, serializedWorkspace.LastModified, semver, serializedWorkspace.CloudId, serializedWorkspace.WorkspaceSizeInBytes, (serializedWorkspace.WorkspaceType == (WorkspaceType)0) ? WorkspaceType.Local : serializedWorkspace.WorkspaceType)
		{
			Active = serializedWorkspace.Active
		};
	}

	public void ConvertToLocalWorkspace()
	{
		if (WorkspaceType != WorkspaceType.Synced)
		{
			throw new InvalidOperationException("Only synced workspaces can be converted to local.");
		}
		CloudId = null;
		WorkspaceType = WorkspaceType.Local;
		WorkspaceSizeInBytes = null;
		LastModified = null;
	}
}
