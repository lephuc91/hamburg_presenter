using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;

namespace Pro.Text;

public class Font : InternalBase, IEquatable<Font>
{
	private static class NativeMethods
	{
		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_CreateTypeface")]
		public static extern nint CreateTypeface(nint library, [MarshalAs(UnmanagedType.LPWStr)] string fontFilename, int faceIndex, uint languageID);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_DestroyTypeface")]
		public static extern void DestroyTypeface(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetIsValid")]
		public static extern bool GetIsValid(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_LoadGlyphFromIndex")]
		public static extern nint LoadGlyphFromIndex(nint handle, uint glyphIndex);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetGlyphIndexByCharacter")]
		public static extern uint GetGlyphIndexByCharacter(nint handle, ushort characterCode);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetLineHeight")]
		public static extern double GetLineHeight(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetFaceCount")]
		public static extern int GetFaceCount(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetNames")]
		public static extern void GetNames(nint handle, out nint systemFamilyName, out nint systemFaceName, out nint displayFamilyName, out nint displayFaceName, out nint fullName, out nint psName);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetUnitsPerEM")]
		public static extern short GetUnitsPerEM(nint handle, out ushort unitsPerEM);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetScriptDimensions")]
		public static extern void GetScriptDimensions(nint handle, out short subscriptXOffset, out short subscriptYOffset, out short subscriptXSize, out short subscriptYSize, out short superscriptXOffset, out short superscriptYOffset, out short superscriptXSize, out short superscriptYSize);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetStrikethroughInfo")]
		public static extern void GetStrikethroughInfo(nint handle, out short strikethroughPosition, out short strikethroughSize);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetUnderlineInfo")]
		public static extern void GetUnderlineInfo(nint handle, out short underlinePosition, out short underlineSize);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Typeface_GetDesignInfo")]
		public static extern void GetDesignInfo(nint handle, out ushort faceWeight, out ushort faceStretch, out bool isItalic, out bool isUnicode);
	}

	private const string ImportPrefix = "Typeface_";

	private readonly string _fontFilename;

	private readonly int _faceIndex;

	private readonly GlyphCache _glyphCache;

	public bool IsValidFont { get; }

	public FontSourceType SourceType { get; }

	internal int FaceCount
	{
		get
		{
			EnsureValid();
			return NativeMethods.GetFaceCount(base.Handle);
		}
	}

	internal ushort UnitsPerEM { get; }

	internal ScriptDimensionInfo ScriptInfo { get; }

	internal double StrikethroughOffset { get; }

	internal double StrikethroughThickness { get; }

	internal double UnderlineOffset { get; }

	internal double UnderlineThickness { get; }

	public FontInfo Info { get; }

	internal Font(TypefaceLibrary library, string fontFilename, int faceIndex, uint languageID, FontSourceType sourceType)
		: base(NativeMethods.CreateTypeface(library.Handle, fontFilename, faceIndex, languageID))
	{
		_fontFilename = fontFilename;
		_glyphCache = new GlyphCache(this);
		SourceType = sourceType;
		try
		{
			_faceIndex = faceIndex;
			IsValidFont = NativeMethods.GetIsValid(base.Handle);
			if (!IsValidFont)
			{
				return;
			}
			ushort unitsPerEM;
			int unitsPerEM2 = NativeMethods.GetUnitsPerEM(base.Handle, out unitsPerEM);
			if (unitsPerEM2 != 0)
			{
				if (unitsPerEM2 == 1)
				{
					Log.Error("GetUnitsPerEM resulted in an error code. Handle pointer null");
				}
				else
				{
					Log.Error("GetUnitsPerEM resulted in an error code. Handle instance pointer null");
				}
				IsValidFont = false;
				return;
			}
			UnitsPerEM = unitsPerEM;
			ScriptInfo = GetFontScriptDimensions();
			Info = GetFontInfo();
			NativeMethods.GetStrikethroughInfo(base.Handle, out var strikethroughPosition, out var strikethroughSize);
			StrikethroughOffset = -strikethroughPosition + strikethroughSize / 2;
			StrikethroughThickness = strikethroughSize;
			NativeMethods.GetUnderlineInfo(base.Handle, out var underlinePosition, out var underlineSize);
			UnderlineOffset = -underlinePosition;
			UnderlineThickness = underlineSize;
		}
		catch (AccessViolationException ex)
		{
			Log.Error("Access Violation while attempting to initialize Font");
			Log.Error($"FileName: {fontFilename}\r\nFace Index: {faceIndex}\r\nLanguage ID: {languageID}\r\n");
			Log.Error(ex.ToString());
		}
	}

	private ScriptDimensionInfo GetFontScriptDimensions()
	{
		NativeMethods.GetScriptDimensions(base.Handle, out var subscriptXOffset, out var subscriptYOffset, out var subscriptXSize, out var subscriptYSize, out var superscriptXOffset, out var superscriptYOffset, out var superscriptXSize, out var superscriptYSize);
		return new ScriptDimensionInfo(subscriptXOffset, subscriptYOffset, (double)subscriptXSize / (double)(int)UnitsPerEM, (double)subscriptYSize / (double)(int)UnitsPerEM, superscriptXOffset, -superscriptYOffset, (double)superscriptXSize / (double)(int)UnitsPerEM, (double)superscriptYSize / (double)(int)UnitsPerEM);
	}

	private FontInfo GetFontInfo()
	{
		NativeMethods.GetNames(base.Handle, out var systemFamilyName, out var systemFaceName, out var displayFamilyName, out var displayFaceName, out var fullName, out var psName);
		NativeMethods.GetDesignInfo(base.Handle, out var faceWeight, out var faceStretch, out var isItalic, out var isUnicode);
		if (!faceWeight.IsInRangeInclusive((ushort)1, (ushort)999))
		{
			faceWeight = (ushort)FontWeights.Normal.ToOpenTypeWeight();
		}
		if (!faceStretch.IsInRangeInclusive((ushort)1, (ushort)9))
		{
			faceStretch = (ushort)FontStretches.Normal.ToOpenTypeStretch();
		}
		string? text = Marshal.PtrToStringUni(systemFamilyName);
		text.ThrowWhenNull("systemFamilyNameString");
		string text2 = Marshal.PtrToStringUni(displayFamilyName);
		text2.ThrowWhenNull("displayFamilyNameString");
		return new FontInfo(text, Marshal.PtrToStringUni(systemFaceName), text2, Marshal.PtrToStringUni(displayFaceName), Marshal.PtrToStringUni(fullName), Marshal.PtrToStringUni(psName), FontWeight.FromOpenTypeWeight(faceWeight), FontStretch.FromOpenTypeStretch(faceStretch), isItalic, isUnicode);
	}

	protected override void Destroy()
	{
		NativeMethods.DestroyTypeface(base.Handle);
	}

	internal GlyphInfo LoadGlyphFromIndex(uint glyphIndex)
	{
		EnsureValid();
		return new GlyphInfo(NativeMethods.LoadGlyphFromIndex(base.Handle, glyphIndex));
	}

	internal double GetScalar(double characterSize)
	{
		return characterSize / (double)(int)UnitsPerEM;
	}

	internal double GetLineHeight(double characterSize)
	{
		EnsureValid();
		return NativeMethods.GetLineHeight(base.Handle) * GetScalar(characterSize);
	}

	internal Glyph GetGlyph(uint glyphIndex)
	{
		return _glyphCache.Get(glyphIndex);
	}

	internal Glyph GetGlyph(char character)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(new char[1] { character });
		if (bytes.Length != 2)
		{
			throw new Exception("Failed to convert the character to Utf-16");
		}
		return GetGlyph((ushort)(bytes[0] | (bytes[1] << 8)));
	}

	internal Glyph GetGlyph(ushort characterCode)
	{
		EnsureValid();
		return _glyphCache.Get(NativeMethods.GetGlyphIndexByCharacter(base.Handle, characterCode));
	}

	public override bool Equals(object? obj)
	{
		if (obj is Font other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Font? other)
	{
		if ((object)other != null && _fontFilename == other._fontFilename)
		{
			return _faceIndex == other._faceIndex;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_fontFilename, _faceIndex);
	}

	public static bool operator ==(Font lhs, Font rhs)
	{
		return lhs.NullableEquals<Font>(rhs);
	}

	public static bool operator !=(Font lhs, Font rhs)
	{
		return !lhs.NullableEquals<Font>(rhs);
	}
}
