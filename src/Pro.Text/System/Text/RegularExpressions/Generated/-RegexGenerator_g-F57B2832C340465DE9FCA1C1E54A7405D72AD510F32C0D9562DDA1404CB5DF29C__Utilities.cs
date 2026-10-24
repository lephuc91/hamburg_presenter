using System.Buffers;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal static class _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

	internal static readonly SearchValues<char> s_ascii_FF0300000080FEFFFD07 = SearchValues.Create("0123456789_abcdefghijklmnoprstuvwxyz");

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfNonAsciiOrAny_C34997C7D62BDD33DD4A170A2E7311DEA168EBFE9ADF50E249E1F8F73D8EC249(this ReadOnlySpan<char> span)
	{
		int num = MemoryExtensions.IndexOfAnyExcept<char>(span, s_ascii_FF0300000080FEFFFD07);
		if ((uint)num < (uint)span.Length)
		{
			if (char.IsAscii(span[num]))
			{
				return num;
			}
			do
			{
				char c;
				if (((c = span[num]) < '\u0080') ? ((byte)("\uffff\uffff\uffffﰀ\uffff翿\u0001\uf802"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\0\u0004\nA[qr\0\ufffe￼\ufffb\ufffd\uffff\ufffa\ufff7￭\0"))
				{
					return num;
				}
				num++;
			}
			while ((uint)num < (uint)span.Length);
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsWordChar(char ch)
	{
		ReadOnlySpan<byte> readOnlySpan = new byte[16]
		{
			0, 0, 0, 0, 0, 0, 255, 3, 254, 255,
			255, 135, 254, 255, 255, 7
		};
		int num = (int)ch >> 3;
		if ((uint)num >= (uint)readOnlySpan.Length)
		{
			return (0x4013F & (1 << (int)CharUnicodeInfo.GetUnicodeCategory(ch))) != 0;
		}
		return (readOnlySpan[num] & (1 << (ch & 7))) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void StackPush(ref int[] stack, ref int pos, int arg0, int arg1)
	{
		int[] array = stack;
		int num = pos;
		if ((uint)(num + 1) < (uint)array.Length)
		{
			array[num] = arg0;
			array[num + 1] = arg1;
			pos += 2;
		}
		else
		{
			WithResize(ref stack, ref pos, arg0, arg1);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void WithResize(ref int[] stack, ref int pos, int arg0, int arg1)
		{
			Array.Resize(ref stack, (pos + 1) * 2);
			StackPush(ref stack, ref pos, arg0, arg1);
		}
	}
}
