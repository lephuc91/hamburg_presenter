using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal static class _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfNonAsciiOrAny_964D26B45878A1E76C50F1FE92D9DEF987EEFF4B5343F10BB4DCBA29A5F17939(this ReadOnlySpan<char> span)
	{
		int num = MemoryExtensions.IndexOfAnyExceptInRange<char>(span, '\0', '\u007f');
		if ((uint)num < (uint)span.Length)
		{
			do
			{
				char ch;
				if ((ch = span[num]) >= '\u0080' && RegexRunner.CharInClass(ch, "\0\u000e\0ᄀሀ⺀⼀\u3000\u3100㈀䷀一ꀀ가ힰ︰﹐"))
				{
					return num;
				}
				num++;
			}
			while ((uint)num < (uint)span.Length);
		}
		return -1;
	}
}
