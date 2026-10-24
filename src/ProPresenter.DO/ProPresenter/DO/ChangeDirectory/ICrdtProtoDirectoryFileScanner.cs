using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.ChangeDirectory;

public interface ICrdtProtoDirectoryFileScanner
{
	bool ShouldLoadLegacy { get; }

	void ValidateWorkspace(IWorkspace workspaceFolder);
}
