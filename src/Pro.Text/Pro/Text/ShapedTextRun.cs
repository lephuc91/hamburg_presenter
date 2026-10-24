using System.Linq;
using System.Runtime.InteropServices;
using Pro.Common.Mathematics;
using Pro.Common.Strings;

namespace Pro.Text;

internal class ShapedTextRun : InternalBase
{
	public delegate void CharacterDataCallback(int cluster, Font font, out int indexOffset, out double characterSize, out int scriptLevel, out double lineHeight);

	private static class NativeMethods
	{
		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TextRun_CreateTextRun")]
		public static extern nint CreateTextRun(nint typeface, FallbackFontProvider.FallbackFontCallback fallbackTypefaceProvider, [MarshalAs(UnmanagedType.LPArray)] uint[] codepoints, int length, TextFeature features);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TextRun_DestroyTextRun")]
		public static extern void DestroyTextRun(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TextRun_SetText")]
		public static extern void SetText(nint handle, nint typeface, FallbackFontProvider.FallbackFontCallback fallbackTypefaceProvider, [MarshalAs(UnmanagedType.LPArray)] uint[] codepoints, int length, TextFeature features);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TextRun_GetLength")]
		public static extern int GetLength(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TextRun_GetCharInfo")]
		public static extern void GetCharInfo(nint handle, int index, out uint glyphIndex, out uint cluster, out bool isRTL, out int bidiLevel, out double xAdvance, out double yAdvance, out double xOffset, out double yOffset, out bool didFallback, out nint typefaceHandle);
	}

	private const string ImportPrefix = "TextRun_";

	private ShapedCharacter[]? _shapedCharacters;

	public Font Font { get; private set; }

	public FallbackFontProvider FallbackFontProvider { get; private set; }

	public string Text { get; private set; }

	public uint[] Codepoints { get; private set; }

	public int Length
	{
		get
		{
			EnsureValid();
			return NativeMethods.GetLength(base.Handle);
		}
	}

	public ShapedTextRun(Font font, FallbackFontProvider fallbackFontProvider, string text, TextFeature features)
		: this(font, fallbackFontProvider, text, text.ToCodepoints().ToArray(), features)
	{
	}

	private ShapedTextRun(Font font, FallbackFontProvider fallbackFontProvider, string text, uint[] codepoints, TextFeature features)
		: base(NativeMethods.CreateTextRun(font.Handle, fallbackFontProvider.ProviderCallback, codepoints, codepoints.Length, features))
	{
		Font = font;
		FallbackFontProvider = fallbackFontProvider;
		Text = text;
		Codepoints = codepoints;
	}

	protected override void Destroy()
	{
		NativeMethods.DestroyTextRun(base.Handle);
	}

	public ShapedCharacter? GetCharInfo(int index, CharacterDataCallback characterDataCallback)
	{
		EnsureValid();
		if (!index.IsInRangeInclusive(0, Length - 1))
		{
			return null;
		}
		ShapedCharacter shapedCharacter = _shapedCharacters?.ElementAtOrDefault(index);
		if (shapedCharacter == null)
		{
			NativeMethods.GetCharInfo(base.Handle, index, out var glyphIndex, out var cluster, out var isRTL, out var bidiLevel, out var xAdvance, out var yAdvance, out var xOffset, out var yOffset, out var didFallback, out var typefaceHandle);
			Font font = (didFallback ? FallbackFontProvider.GetFont(typefaceHandle) : Font);
			characterDataCallback((int)cluster, font, out var indexOffset, out var characterSize, out var scriptLevel, out var lineHeight);
			shapedCharacter = new ShapedCharacter(glyphIndex, cluster, indexOffset, isRTL, bidiLevel, new Vector2<double>(xAdvance, yAdvance), new Vector2<double>(xOffset, 0.0 - yOffset), lineHeight, font, font.GetScalar(characterSize), font.ScriptInfo.GetSizeScalar(scriptLevel));
			if (_shapedCharacters == null)
			{
				_shapedCharacters = new ShapedCharacter[Length];
			}
			_shapedCharacters[index] = shapedCharacter;
		}
		return shapedCharacter;
	}

	public void SetText(Font font, FallbackFontProvider fallbackFontProvider, string text, uint[] codepoints, TextFeature features)
	{
		EnsureValid();
		NativeMethods.SetText(base.Handle, font.Handle, fallbackFontProvider.ProviderCallback, codepoints, codepoints.Length, features);
		Font = font;
		FallbackFontProvider = fallbackFontProvider;
		Text = text;
		Codepoints = codepoints;
		_shapedCharacters = null;
	}
}
