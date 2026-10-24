namespace ProPresenterCore.ProCore.Interop;

public abstract class ResourceUpdateInfo
{
	public ProResourceUpdateType UpdateType { get; private set; }

	internal unsafe static ResourceUpdateInfo? FromNative(ProResourceUpdateInfo.__Internal* native)
	{
		ResourceUpdateInfo resourceUpdateInfo;
		switch (native->type)
		{
		case ProResourceUpdateType.SlideBuildIndex:
			resourceUpdateInfo = new SlideBuildIndexUpdateInfo((ProSlideBuildIndexUpdateInfo.__Internal*)native);
			break;
		case ProResourceUpdateType.Timer:
			resourceUpdateInfo = new TimerUpdateInfo((ProTimerUpdateInfo.__Internal*)native);
			break;
		case ProResourceUpdateType.AutoAdvance:
			resourceUpdateInfo = new AutoAdvancedUpdateInfo((ProAutoAdvanceUpdateInfo.__Internal*)native);
			break;
		case ProResourceUpdateType.SlideOnStageDisplayOnly:
			resourceUpdateInfo = new SlideOnStageOnlyUpdateInfo((ProSlideOnStageDisplayOnlyUpdateInfo.__Internal*)native);
			break;
		default:
			return null;
		}
		resourceUpdateInfo.UpdateType = native->type;
		return resourceUpdateInfo;
	}
}
