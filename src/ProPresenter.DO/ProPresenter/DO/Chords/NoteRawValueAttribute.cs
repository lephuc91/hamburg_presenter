using System;

namespace ProPresenter.DO.Chords;

public class NoteRawValueAttribute : Attribute
{
	public string Value { get; }

	public NoteRawValueAttribute(string val)
	{
		Value = val;
	}
}
