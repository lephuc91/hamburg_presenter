using System;
using System.Threading.Tasks;

namespace ProPresenter.DO.CloudOnboarding;

public interface ICloudConversionService
{
	Task<Guid?> ConvertToCloudAsync(WorkspaceIssueFlags workspaceIssues);
}
