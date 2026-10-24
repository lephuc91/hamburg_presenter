namespace ProPresenterCore.ProCore.Interop;

public class SlideBuildIndexUpdateInfo : ResourceUpdateInfo
{
	public int BuildIndex { get; }

	internal unsafe SlideBuildIndexUpdateInfo(ProSlideBuildIndexUpdateInfo.__Internal* native)
	{
		BuildIndex = native->buildIndex;
	}
}
