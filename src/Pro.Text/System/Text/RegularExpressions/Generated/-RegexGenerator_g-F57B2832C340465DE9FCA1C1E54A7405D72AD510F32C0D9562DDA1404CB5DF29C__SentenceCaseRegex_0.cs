using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SentenceCaseRegex_0 : Regex
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
				if ((uint)runtextpos < (uint)inputSpan.Length)
				{
					return true;
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
				int num4 = 0;
				int num5 = 0;
				int capturePosition2 = 0;
				int num6 = 0;
				int num7 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				num4 = num;
				num3 = Crawlpos();
				char c;
				if (!readOnlySpan.IsEmpty && !((c = readOnlySpan[0]) != '!' && c != '.' && c != '?'))
				{
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num6 = num;
					int i;
					for (i = 0; (uint)i < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[i]); i++)
					{
					}
					if (i != 0)
					{
						readOnlySpan = readOnlySpan.Slice(i);
						num += i;
						num7 = num;
						num6++;
						goto IL_00eb;
					}
				}
				goto IL_00f7;
				IL_0139:
				while (true)
				{
					num5 = num;
					if (readOnlySpan.IsEmpty || (((c = readOnlySpan[0]) < '\u0080') ? (("쇿\uffff뿼翿\uffff\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) == 0) : (!RegexRunner.CharInClass(c, "\u0001\u0006\u0001!\"./?@d"))))
					{
						if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 == 0)
						{
							break;
						}
						if (num2 == 1)
						{
							UncaptureUntil(0);
							return false;
						}
						continue;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					Capture(1, num5, num);
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
				UncaptureUntil(capturePosition2);
				if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
				{
					CheckTimeout();
				}
				if (num6 < num7)
				{
					num = --num7;
					readOnlySpan = inputSpan.Slice(num);
					goto IL_00eb;
				}
				goto IL_00f7;
				IL_00f7:
				num = num4;
				readOnlySpan = inputSpan.Slice(num);
				UncaptureUntil(num3);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num2 = 1;
				goto IL_0139;
				IL_00eb:
				capturePosition2 = Crawlpos();
				num2 = 0;
				goto IL_0139;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				void UncaptureUntil(int capturePosition)
				{
					while (Crawlpos() > capturePosition)
					{
						Uncapture();
					}
				}
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SentenceCaseRegex_0 Instance = new _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SentenceCaseRegex_0();

	private _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__SentenceCaseRegex_0()
	{
		pattern = "(?:[\\.\\?\\!]\\s+|^)([^\\s\\.\\?\\!])";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 2;
	}
}
