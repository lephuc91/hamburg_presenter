namespace ProPresenterCore.ProCore.Interop;

public class SlideOnStageOnlyUpdateInfo : ResourceUpdateInfo
{
	public bool StageOnly { get; }

	internal unsafe SlideOnStageOnlyUpdateInfo(ProSlideOnStageDisplayOnlyUpdateInfo.__Internal* native)
	{
		StageOnly = native->stageOnly != 0;
	}
}
