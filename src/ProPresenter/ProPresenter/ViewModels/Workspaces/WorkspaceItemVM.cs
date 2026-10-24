using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Workspaces;
using Semver;

namespace ProPresenter.ViewModels.Workspaces;

public class WorkspaceItemVM : LinkedObservableObjectBase, IWorkspaceItemVMInternal, IWorkspaceItemVM, IEquatable<WorkspaceItemVM>
{
	public string Name
	{
		get
		{
			return Workspace.Name;
		}
		set
		{
			Workspace.Name = value;
		}
	}

	public bool Active
	{
		get
		{
			return Workspace.Active;
		}
		set
		{
			Workspace.Active = value;
		}
	}

	public string Path
	{
		get
		{
			return Workspace.Path;
		}
		set
		{
			Workspace.Path = value;
		}
	}

	public Guid? CloudId
	{
		get
		{
			return Workspace.CloudId;
		}
		set
		{
			Workspace.CloudId = value;
		}
	}

	public DateTimeOffset? LastModified
	{
		get
		{
			return Workspace.LastModified;
		}
		set
		{
			Workspace.LastModified = value;
		}
	}

	public ulong? WorkspaceSizeInBytes
	{
		get
		{
			return Workspace.WorkspaceSizeInBytes;
		}
		set
		{
			Workspace.WorkspaceSizeInBytes = value;
		}
	}

	public string ReadableWorkspaceSize
	{
		get
		{
			if (!Workspace.WorkspaceSizeInBytes.HasValue)
			{
				return string.Empty;
			}
			return ((long)Workspace.WorkspaceSizeInBytes.Value).BytesToReadableSizeFormat();
		}
	}

	public SemVersion MinimumRequiredAppVersion => Workspace.MinimumRequiredAppVersion;

	public ProPresenter.UI.ViewModels.Workspaces.WorkspaceType WorkspaceType
	{
		get
		{
			return Workspace.WorkspaceType.ToUIWorkspaceType();
		}
		set
		{
			Workspace.WorkspaceType = value.ToDOWorkspaceType();
		}
	}

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Path", "Path")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Active", "Active")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("WorkspaceType", "WorkspaceType")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("CloudId", "CloudId")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("WorkspaceSizeInBytes", "WorkspaceSizeInBytes")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("WorkspaceSizeInBytes", "ReadableWorkspaceSize")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("MinimumRequiredAppVersion", "MinimumRequiredAppVersion")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("LastModified", "LastModified")]
	public IWorkspace Workspace { get; }

	public WorkspaceItemVM(IWorkspace workspace)
	{
		Workspace = workspace;
		AddPropertyLinks();
	}

	public override int GetHashCode()
	{
		return Path.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		return Equals(obj as WorkspaceItemVM);
	}

	public bool Equals(WorkspaceItemVM? other)
	{
		if (other == null)
		{
			return false;
		}
		return Path == other.Path;
	}

	public void ConvertToLocalWorkspace()
	{
		Workspace.ConvertToLocalWorkspace();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Workspace_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == null)
		{
			return;
		}
		switch (propertyName.Length)
		{
		case 4:
			switch (propertyName[0])
			{
			case 'N':
				if (propertyName == "Name")
				{
					OnPropertyChanged("Name");
				}
				break;
			case 'P':
				if (propertyName == "Path")
				{
					OnPropertyChanged("Path");
				}
				break;
			}
			break;
		case 6:
			if (propertyName == "Active")
			{
				OnPropertyChanged("Active");
			}
			break;
		case 13:
			if (propertyName == "WorkspaceType")
			{
				OnPropertyChanged("WorkspaceType");
			}
			break;
		case 7:
			if (propertyName == "CloudId")
			{
				OnPropertyChanged("CloudId");
			}
			break;
		case 20:
			if (propertyName == "WorkspaceSizeInBytes")
			{
				OnPropertyChanged("WorkspaceSizeInBytes");
				OnPropertyChanged("ReadableWorkspaceSize");
			}
			break;
		case 25:
			if (propertyName == "MinimumRequiredAppVersion")
			{
				OnPropertyChanged("MinimumRequiredAppVersion");
			}
			break;
		case 12:
			if (propertyName == "LastModified")
			{
				OnPropertyChanged("LastModified");
			}
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		Workspace.PropertyChanged += Workspace_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		Workspace.PropertyChanged -= Workspace_PropertyChanged;
	}
}
