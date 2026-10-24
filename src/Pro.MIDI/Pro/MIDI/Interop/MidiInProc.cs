namespace Pro.MIDI.Interop;

internal delegate void MidiInProc(nint handle, MIM msg, nint instance, nint param1, nint param2);
