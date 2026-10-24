using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal static class _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

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
}
