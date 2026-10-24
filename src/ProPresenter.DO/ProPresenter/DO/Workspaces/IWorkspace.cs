using System;
using System.ComponentModel;
using Semver;

namespace ProPresenter.DO.Workspaces;

public interface IWorkspace : INotifyPropertyChanged
{
	bool Active { get; set; }

	string Path { get; set; }

	string Name { get; set; }

	WorkspaceType WorkspaceType { get; set; }

	SemVersion MinimumRequiredAppVersion { get; set; }

	Guid? CloudId { get; set; }

	DateTimeOffset? LastModified { get; set; }

	ulong? WorkspaceSizeInBytes { get; set; }

	void ConvertToLocalWorkspace();
}
