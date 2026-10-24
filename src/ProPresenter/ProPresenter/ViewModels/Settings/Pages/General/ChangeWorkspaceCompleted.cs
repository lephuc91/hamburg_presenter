using ProPresenter.DO.Workspaces;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public record ChangeWorkspaceCompleted(IWorkspace? OldWorkspace, IWorkspace NewWorkspace, bool Success, bool PublishAfterChange)
{
	public static implicit operator bool(ChangeWorkspaceCompleted value)
	{
		return value.Success;
	}
}
