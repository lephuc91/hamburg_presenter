using System.Buffers;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal static class _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

	internal static readonly SearchValues<char> s_ascii_20FF03FEFFFF07FEFFFF07 = SearchValues.Create("-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

	internal static readonly SearchValues<char> s_ascii_FFC1FFFFFEDFFFFFFFFFFF7FFFFFFFFF = SearchValues.Create("\0\u0001\u0002\u0003\u0004\u0005\u0006\a\b\u000e\u000f\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\u001c\u001d\u001e\u001f!\"#$%&'()*+,./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^`abcdefghijklmnopqrstuvwxyz{|}~\u007f");

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfNonAsciiOrAny_45D04AD7B2A6581AEEE20CEC05EA4AAD2ABB34EEBA86418BA168427FA10C18DB(this ReadOnlySpan<char> span)
	{
		int num = MemoryExtensions.IndexOfAnyExcept<char>(span, s_ascii_FFC1FFFFFEDFFFFFFFFFFF7FFFFFFFFF);
		if ((uint)num < (uint)span.Length)
		{
			if (char.IsAscii(span[num]))
			{
				return num;
			}
			do
			{
				char c;
				if (((c = span[num]) < '\u0080') ? ((byte)("㸀\0\u2001\0\0耀\0\0"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\0\u0004\u0001-._`d"))
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
	internal static void StackPush(ref int[] stack, ref int pos, int arg0)
	{
		int[] array = stack;
		int num = pos;
		if ((uint)num < (uint)array.Length)
		{
			array[num] = arg0;
			pos++;
		}
		else
		{
			WithResize(ref stack, ref pos, arg0);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void WithResize(ref int[] stack, ref int pos, int arg0)
		{
			Array.Resize(ref stack, pos * 2);
			StackPush(ref stack, ref pos, arg0);
		}
	}
}
