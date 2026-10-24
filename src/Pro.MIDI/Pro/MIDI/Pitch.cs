using System;
using Pro.Common.Mathematics;

namespace Pro.MIDI;

public struct Pitch
{
	private const int DefaultBaseOctave = -2;

	private const int NoteCount = 12;

	public Note Note { get; }

	public int Octave { get; }

	public Pitch(Note note, int octave)
	{
		Note = note;
		Octave = octave;
	}

	public Pitch(int noteValue, int baseOctave = -2)
	{
		Note = (Note)noteValue.Mod(12);
		Octave = (int)Math.Floor((double)noteValue / 12.0) + baseOctave;
	}

	public int GetNoteValue(int baseOctave = -2)
	{
		return (int)(Note + (Octave - baseOctave) * 12);
	}
}
