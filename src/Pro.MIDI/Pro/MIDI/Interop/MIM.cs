namespace Pro.MIDI.Interop;

internal enum MIM : uint
{
	OPEN = 961u,
	CLOSE,
	DATA,
	LONGDATA,
	ERROR,
	LONGERROR
}
