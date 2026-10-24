using System.Linq;
using System.Text;
using Pro.Common.Utility;
using Pro.Text;
using ProPresenter.DO.Chords;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenter.DO.Presentation;

public static class ChordTranspositionProvider
{
	public unsafe static void ChordTranspose(Key baseKey, Key targetKey, ChordProNotationType notationType, string originalChord, out string transposedChord, out (int start, int end)[] superscriptRanges)
	{
		if (UnitTestDetector.IsInUnitTest || baseKey == null || targetKey == null || string.IsNullOrWhiteSpace(originalChord))
		{
			transposedChord = originalChord;
			superscriptRanges = new(int, int)[0];
			return;
		}
		ProChordNote note = GetNote(baseKey);
		ProChordNote note2 = GetNote(targetKey);
		ProChordScale scale = GetScale(baseKey);
		ProChordScale scale2 = GetScale(targetKey);
		ProChordNotationStyle notationStyle = GetNotationStyle(notationType);
		ProSuperscriptRangeData superscriptRangeData = new ProSuperscriptRangeData();
		uint num = (uint)(originalChord.Length + 32);
		sbyte[] array = new sbyte[num];
		fixed (byte* bytes = Encoding.UTF8.GetBytes(originalChord))
		{
			fixed (sbyte* ptr = &array[0])
			{
				ProChords.ChordTranspose(note, scale, note2, scale2, notationStyle, (nint)bytes, ptr, num, superscriptRangeData);
				transposedChord = StringMarshalling.StringFromCString(ptr);
				superscriptRanges = (from i in Enumerable.Range(0, (int)superscriptRangeData.RangeCount)
					select ((int)superscriptRangeData.Ranges[i].StartIndex, (int)superscriptRangeData.Ranges[i].EndIndex)).ToArray();
			}
		}
	}

	private static ProChordNote GetNote(Key key)
	{
		return key.Note switch
		{
			Note.Ces => ProChordNote.Ces, 
			Note.Cis => ProChordNote.Cis, 
			Note.Des => ProChordNote.Des, 
			Note.D => ProChordNote.D, 
			Note.Dis => ProChordNote.Dis, 
			Note.Ees => ProChordNote.Ees, 
			Note.E => ProChordNote.E, 
			Note.Eis => ProChordNote.Eis, 
			Note.Fes => ProChordNote.Fes, 
			Note.F => ProChordNote.F, 
			Note.Fis => ProChordNote.Fis, 
			Note.Ges => ProChordNote.Ges, 
			Note.G => ProChordNote.G, 
			Note.Gis => ProChordNote.Gis, 
			Note.Aes => ProChordNote.Aes, 
			Note.A => ProChordNote.A, 
			Note.Ais => ProChordNote.Ais, 
			Note.Bes => ProChordNote.Bes, 
			Note.B => ProChordNote.B, 
			Note.Bis => ProChordNote.Bis, 
			_ => ProChordNote.C, 
		};
	}

	private static ProChordScale GetScale(Key key)
	{
		Scale scale = key.Scale;
		if (scale == Scale.Major || scale != Scale.Minor)
		{
			return ProChordScale.Major;
		}
		return ProChordScale.Minor;
	}

	private static ProChordNotationStyle GetNotationStyle(ChordProNotationType type)
	{
		return type switch
		{
			ChordProNotationType.Numbers => ProChordNotationStyle.NashvilleNumber, 
			ChordProNotationType.Numerals => ProChordNotationStyle.RomanNumeral, 
			ChordProNotationType.DoReMi => ProChordNotationStyle.Solfege, 
			_ => ProChordNotationStyle.Chord, 
		};
	}
}
