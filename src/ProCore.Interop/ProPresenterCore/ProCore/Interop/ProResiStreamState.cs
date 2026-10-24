namespace ProPresenterCore.ProCore.Interop;

public enum ProResiStreamState
{
	Starting = 0,
	StartCheck = 1,
	Started = 2,
	StartError = 3,
	Stopping = 4,
	StopCheck = 5,
	Stopped = 6,
	StopError = 7,
	Unknown = 8,
	MaxValue = int.MaxValue
}
