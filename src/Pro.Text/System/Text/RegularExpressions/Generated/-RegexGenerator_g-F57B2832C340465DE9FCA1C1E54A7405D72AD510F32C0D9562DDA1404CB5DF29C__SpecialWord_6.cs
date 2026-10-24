using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SpecialWord_6 : Regex
{
	private sealed class RunnerFactory : RegexRunnerFactory
	{
		private sealed class Runner : RegexRunner
		{
			protected override void Scan(ReadOnlySpan<char> inputSpan)
			{
				while (TryFindNextPossibleStartingPosition(inputSpan) && !TryMatchAtCurrentPosition(inputSpan) && runtextpos != inputSpan.Length)
				{
					runtextpos++;
					if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if (num <= inputSpan.Length - 3)
				{
					int num2 = inputSpan.Slice(num).IndexOfNonAsciiOrAny_C34997C7D62BDD33DD4A170A2E7311DEA168EBFE9ADF50E249E1F8F73D8EC249();
					if (num2 >= 0)
					{
						runtextpos = num + num2;
						return true;
					}
				}
				runtextpos = inputSpan.Length;
				return false;
			}

			private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				int start = num;
				int num2 = 0;
				int num3 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				int num4 = 0;
				int num5 = num;
				num2 = num;
				int i;
				for (i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
				{
					char c;
					if ((((c = readOnlySpan[i]) < '\u0080') ? ("\uffff\uffff\uffffﰀ\uffff翿\u0001\uf800"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\u0002\nA[\0\ufffe￼\ufffb\ufffd\uffff\ufffa\ufff7￭\0") ? 1 : 0)) == 0)
					{
						break;
					}
				}
				if (i == 0)
				{
					goto IL_0109;
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				num3 = num;
				num2++;
				while (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"'s"))
				{
					if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num2 < num3 && (num3 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num2, Math.Min(inputSpan.Length, num3 + 1) - num2), (ReadOnlySpan<char>)"'s")) >= 0)
					{
						num3 += num2;
						num = num3;
						readOnlySpan = inputSpan.Slice(num);
						continue;
					}
					goto IL_0109;
				}
				num += 2;
				readOnlySpan = inputSpan.Slice(num);
				goto IL_0175;
				IL_0175:
				runtextpos = num;
				Capture(0, start, num);
				return true;
				IL_0109:
				num = num5;
				readOnlySpan = inputSpan.Slice(num);
				int num6 = MemoryExtensions.IndexOfAnyExcept<char>(readOnlySpan, 'Q', 'q');
				if (num6 < 0)
				{
					num6 = readOnlySpan.Length;
				}
				if (num6 == 0)
				{
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num6);
				num += num6;
				if ((uint)readOnlySpan.Length < 2u || !MemoryExtensions.StartsWith(readOnlySpan, (ReadOnlySpan<char>)"&a", StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				num += 2;
				readOnlySpan = inputSpan.Slice(num);
				goto IL_0175;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SpecialWord_6 Instance = new _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SpecialWord_6();

	private _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SpecialWord_6()
	{
		pattern = "[A-Z\\W]+['][s]|[qQ]+&[aA]";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
