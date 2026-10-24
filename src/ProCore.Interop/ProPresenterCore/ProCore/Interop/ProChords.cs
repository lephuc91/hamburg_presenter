using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProChords
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct __Internal
	{
		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proChordTranspose")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe static extern void ChordTranspose(ProChordNote baseNote, ProChordScale baseScale, ProChordNote targetNote, ProChordScale targetScale, ProChordNotationStyle notationStyle, nint originalChord, sbyte* transposedChord, uint transposedChordMaxLength, nint superscriptRangeData);
	}

	public unsafe static void ChordTranspose(ProChordNote baseNote, ProChordScale baseScale, ProChordNote targetNote, ProChordScale targetScale, ProChordNotationStyle notationStyle, nint originalChord, sbyte* transposedChord, uint transposedChordMaxLength, ProSuperscriptRangeData superscriptRangeData)
	{
		nint superscriptRangeData2 = superscriptRangeData?.__Instance ?? IntPtr.Zero;
		__Internal.ChordTranspose(baseNote, baseScale, targetNote, targetScale, notationStyle, originalChord, transposedChord, transposedChordMaxLength, superscriptRangeData2);
	}
}
