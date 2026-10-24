using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__FilePathPattern_3 : Regex
{
	private sealed class RunnerFactory : RegexRunnerFactory
	{
		private sealed class Runner : RegexRunner
		{
			protected override void Scan(ReadOnlySpan<char> inputSpan)
			{
				if (TryFindNextPossibleStartingPosition(inputSpan) && !TryMatchAtCurrentPosition(inputSpan))
				{
					runtextpos = inputSpan.Length;
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if (num <= inputSpan.Length - 2 && num == 0)
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
				int pos = 0;
				int num3 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num3 = pos;
				num2 = 0;
				while (true)
				{
					_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
					num2++;
					int start2 = num;
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != '/')
					{
						break;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					int i;
					for (i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
					{
						char c;
						if ((((c = readOnlySpan[i]) < '\u0080') ? ("\0\0䀀Ͽ\ufffe蟿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\u0002\n./\0\u0002\u0004\u0005\u0003\u0001\u0006\t\u0013\0") ? 1 : 0)) == 0)
						{
							break;
						}
					}
					if (i == 0)
					{
						break;
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					Capture(1, start2, num);
				}
				if (--num2 < 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num = runstack[--pos];
				UncaptureUntil(runstack[--pos]);
				readOnlySpan = inputSpan.Slice(num);
				if (num2 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				pos = num3;
				runtextpos = num;
				Capture(0, start, num);
				return true;
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

	internal static readonly _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__FilePathPattern_3 Instance = new _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__FilePathPattern_3();

	private _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__FilePathPattern_3()
	{
		pattern = "^(\\/[\\w.]+)+";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 2;
	}
}
