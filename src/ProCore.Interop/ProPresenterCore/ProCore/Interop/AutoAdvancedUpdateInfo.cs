namespace ProPresenterCore.ProCore.Interop;

public class AutoAdvancedUpdateInfo : ResourceUpdateInfo
{
	public bool WillAutoAdvance { get; }

	public float Progress { get; }

	public float TimeRemaining { get; }

	internal unsafe AutoAdvancedUpdateInfo(ProAutoAdvanceUpdateInfo.__Internal* native)
	{
		WillAutoAdvance = native->willAutoAdvance != 0;
		Progress = native->progress;
		TimeRemaining = native->timeRemaining;
	}
}
