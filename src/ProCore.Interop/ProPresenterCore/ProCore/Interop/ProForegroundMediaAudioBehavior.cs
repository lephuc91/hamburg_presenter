namespace ProPresenterCore.ProCore.Interop;

public enum ProForegroundMediaAudioBehavior
{
	DoNothing = 0,
	ClearAlways = 1,
	ClearIfAudio = 2,
	PauseAlways = 3,
	PauseIfAudio = 4,
	MaxValue = int.MaxValue
}
