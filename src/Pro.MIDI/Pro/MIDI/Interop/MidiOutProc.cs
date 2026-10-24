namespace Pro.MIDI.Interop;

internal delegate void MidiOutProc(nint handle, MOM msg, nint instance, nint param1, nint param2);
