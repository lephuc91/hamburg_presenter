using System.Threading.Tasks;

namespace ProPresenter.DO.CloudOnboarding;

public interface IWorkspaceInspectionService
{
	Task<WorkspaceIssueFlags> DetectIssuesAsync();

	Task<bool> HasUnmanagedMediaAsync();
}
