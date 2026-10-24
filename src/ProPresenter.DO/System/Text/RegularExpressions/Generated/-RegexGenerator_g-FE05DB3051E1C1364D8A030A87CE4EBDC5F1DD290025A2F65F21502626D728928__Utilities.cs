using System.Buffers;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal static class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

	internal static readonly SearchValues<char> s_ascii_20FF03FEFFFF07FEFFFF07 = SearchValues.Create("-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

	internal static readonly SearchValues<string> s_indexOfString_08E967E3F200B7299496DF0988B76E017E9A898A28D55B501328735F1A72FA16;

	internal static readonly SearchValues<string> s_indexOfString_0EB7C57F1E1613EE8D069A853AC87996AAC4AB66EE1DBD194489F3BEE08ED9A3;

	internal static readonly SearchValues<string> s_indexOfString_1A577A05D48438AF89F3428D231CE9C621BACC583995CFDA566F61B5910BA2BD;

	internal static readonly SearchValues<string> s_indexOfString_3B61AE33DF28F1779B7D2635A83C8EF242161C64311DC7BE11481E6BC2F08AC8;

	internal static readonly SearchValues<string> s_indexOfString_58E6DD33ADFC2D38AB8C0CA908AC054FA47C1C23392ECC4384A4AA40C196CBD6;

	internal static readonly SearchValues<string> s_indexOfString_62F210947C29D71886222C59EE9C764C967758E2741DC7F737059B6A61357A0C;

	internal static readonly SearchValues<string> s_indexOfString_917E2BC9B45D915CDE69FF9EAE580D0CAFE88887B625B76A95A78C2E81AEAB2B;

	internal static readonly SearchValues<string> s_indexOfString_BB1156B218C912361EB4E90120C850ECA2890F0BE0D9D4DB46DAB2361C3F64FD;

	internal static readonly SearchValues<string> s_indexOfString_CCLI_Ordinal;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void StackPop(int[] stack, ref int pos, out int arg0, out int arg1)
	{
		arg0 = stack[--pos];
		arg1 = stack[--pos];
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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void StackPush(ref int[] stack, ref int pos, int arg0, int arg1, int arg2)
	{
		int[] array = stack;
		int num = pos;
		if ((uint)(num + 2) < (uint)array.Length)
		{
			array[num] = arg0;
			array[num + 1] = arg1;
			array[num + 2] = arg2;
			pos += 3;
		}
		else
		{
			WithResize(ref stack, ref pos, arg0, arg1, arg2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void WithResize(ref int[] stack, ref int pos, int arg0, int arg1, int arg2)
		{
			Array.Resize(ref stack, (pos + 2) * 2);
			StackPush(ref stack, ref pos, arg0, arg1, arg2);
		}
	}

	static _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities()
	{
		string reference = "Author:";
		s_indexOfString_08E967E3F200B7299496DF0988B76E017E9A898A28D55B501328735F1A72FA16 = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "${";
		s_indexOfString_0EB7C57F1E1613EE8D069A853AC87996AAC4AB66EE1DBD194489F3BEE08ED9A3 = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "Notes:";
		s_indexOfString_1A577A05D48438AF89F3428D231CE9C621BACC583995CFDA566F61B5910BA2BD = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "[!PLACEHOLDER";
		s_indexOfString_3B61AE33DF28F1779B7D2635A83C8EF242161C64311DC7BE11481E6BC2F08AC8 = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "Hymnal:";
		s_indexOfString_58E6DD33ADFC2D38AB8C0CA908AC054FA47C1C23392ECC4384A4AA40C196CBD6 = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "CopyrightTextTemplate=\"";
		s_indexOfString_62F210947C29D71886222C59EE9C764C967758E2741DC7F737059B6A61357A0C = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "Title:";
		s_indexOfString_917E2BC9B45D915CDE69FF9EAE580D0CAFE88887B625B76A95A78C2E81AEAB2B = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "PlayOrder:";
		s_indexOfString_BB1156B218C912361EB4E90120C850ECA2890F0BE0D9D4DB46DAB2361C3F64FD = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
		reference = "CCLI";
		s_indexOfString_CCLI_Ordinal = SearchValues.Create(new ReadOnlySpan<string>(in reference), StringComparison.Ordinal);
	}
}
