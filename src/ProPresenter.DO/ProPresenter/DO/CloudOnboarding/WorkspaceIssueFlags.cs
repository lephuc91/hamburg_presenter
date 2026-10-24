using System;

namespace ProPresenter.DO.CloudOnboarding;

[Flags]
public enum WorkspaceIssueFlags
{
	None = 0,
	SmartPlaylists = 1,
	UnmanagedMedia = 2
}
