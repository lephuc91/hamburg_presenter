using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Utility;

namespace ProPresenter.DO.Chords;

public class Key
{
	public static readonly Key Default = new Key(Note.C, Scale.Major);

	private static readonly Note[] NoteParseOrder = (from note in Enum.GetValues<Note>()
		orderby GetRawValue(note).Length descending
		select note).ToArray();

	private const string MinorChordString = "m";

	public Note Note { get; }

	public Scale Scale { get; }

	public Key(Note note, Scale scale)
	{
		Note = note;
		Scale = scale;
	}

	private string GetScaleString()
	{
		if (Scale != Scale.Minor)
		{
			return string.Empty;
		}
		return "m";
	}

	public override string ToString()
	{
		return Note.GetEnumDescription() + GetScaleString();
	}

	public string ToRawString()
	{
		return GetRawValue(Note) + GetScaleString();
	}

	public static bool TryParse(string key, [NotNullWhen(true)] out Key? parsedKey)
	{
		Note[] noteParseOrder = NoteParseOrder;
		foreach (Note note in noteParseOrder)
		{
			if (key.StartsWith(GetRawValue(note)))
			{
				parsedKey = new Key(note, key.EndsWith("m") ? Scale.Minor : Scale.Major);
				return true;
			}
		}
		parsedKey = null;
		return false;
	}

	public Key Clone()
	{
		return new Key(Note, Scale);
	}

	private static string GetRawValue(Note note)
	{
		return note.GetAttribute<Note, NoteRawValueAttribute>()?.Value ?? string.Empty;
	}
}
