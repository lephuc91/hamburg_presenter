using System;

namespace Pro.MIDI.Interop;

[Flags]
internal enum CALLBACK : uint
{
	NULL = 0u,
	WINDOW = 0x10000u,
	TASK = 0x20000u,
	THREAD = 0x20000u,
	FUNCTION = 0x30000u,
	EVENT = 0x50000u,
	TYPEMASK = 0x70000u,
	MIDI_IO_STATUS = 0x20u
}
