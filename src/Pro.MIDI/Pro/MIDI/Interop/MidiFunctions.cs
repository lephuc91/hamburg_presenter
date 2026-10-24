using System.Runtime.InteropServices;

namespace Pro.MIDI.Interop;

internal static class MidiFunctions
{
	private const string WinMMDLL = "Winmm.dll";

	private const string ImportPrefix = "midi";

	[DllImport("Winmm.dll", EntryPoint = "midiInGetNumDevs")]
	public static extern uint InGetNumDevs();

	[DllImport("Winmm.dll", EntryPoint = "midiInGetDevCapsW")]
	public static extern MMRESULT InGetDevCapsW(nuint deviceID, out MIDIINCAPS caps, uint capsSize);

	[DllImport("Winmm.dll", EntryPoint = "midiInOpen")]
	public static extern MMRESULT InOpen(out nint handle, uint deviceID, nint callback, nint instance, CALLBACK flags);

	[DllImport("Winmm.dll", EntryPoint = "midiInStart")]
	public static extern MMRESULT InStart(nint handle);

	[DllImport("Winmm.dll", EntryPoint = "midiInStop")]
	public static extern MMRESULT InStop(nint handle);

	[DllImport("Winmm.dll", EntryPoint = "midiInClose")]
	public static extern MMRESULT InClose(nint handle);

	[DllImport("Winmm.dll", EntryPoint = "midiOutGetNumDevs")]
	public static extern uint OutGetNumDevs();

	[DllImport("Winmm.dll", EntryPoint = "midiOutGetDevCapsW")]
	public static extern MMRESULT OutGetDevCapsW(nuint deviceID, out MIDIOUTCAPS caps, uint capsSize);

	[DllImport("Winmm.dll", EntryPoint = "midiOutOpen")]
	public static extern MMRESULT OutOpen(out nint handle, uint deviceID, nint callback, nint instance, CALLBACK flags);

	[DllImport("Winmm.dll", EntryPoint = "midiOutShortMsg")]
	public static extern MMRESULT OutShortMsg(nint handle, uint message);

	[DllImport("Winmm.dll", EntryPoint = "midiOutClose")]
	public static extern MMRESULT OutClose(nint handle);
}
