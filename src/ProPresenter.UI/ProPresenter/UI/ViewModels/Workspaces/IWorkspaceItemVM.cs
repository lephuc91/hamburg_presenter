using System;
using Semver;

namespace ProPresenter.UI.ViewModels.Workspaces;

public interface IWorkspaceItemVM
{
	string Name { get; set; }

	bool Active { get; set; }

	string Path { get; set; }

	Guid? CloudId { get; set; }

	ulong? WorkspaceSizeInBytes { get; set; }

	SemVersion MinimumRequiredAppVersion { get; }

	DateTimeOffset? LastModified { get; set; }

	WorkspaceType WorkspaceType { get; set; }

	void ConvertToLocalWorkspace();
}
