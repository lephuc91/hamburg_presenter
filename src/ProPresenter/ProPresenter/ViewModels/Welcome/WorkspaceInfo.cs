using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public class WorkspaceInfo : IWorkspaceInfo
{
	public required string Name { get; init; }

	public required string LastModified { get; init; }

	public required string Size { get; init; }

	public required string Id { get; init; }
}
