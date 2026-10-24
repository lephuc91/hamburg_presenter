using System;

namespace Pro.MIDI.Interop;

[Flags]
internal enum MIDICAPS : ushort
{
	None = 0,
	VOLUME = 1,
	LRVOLUME = 4,
	CACHE = 8,
	STREAM = 0x10
}
