using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__InternalCapitalPattern_5 : Regex
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
				if (num <= inputSpan.Length - 2)
				{
					int num2 = MemoryExtensions.IndexOfAnyInRange<char>(inputSpan.Slice(num), 'a', 'z');
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				int num2 = num;
				if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
				{
					CheckTimeout();
				}
				char c;
				if (!readOnlySpan.IsEmpty && !(((c = readOnlySpan[0]) < '\u0080') ? (("\0\0\u2000\0\0\0\0\0"[(int)c >> 4] & (1 << (c & 0xF))) == 0) : (!RegexRunner.CharInClass(c, "\0\u0006\0-.‑‒–―"))))
				{
					return false;
				}
				num = num2;
				readOnlySpan = inputSpan.Slice(num);
				int num3 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, 'a', 'z');
				if (num3 < 0)
				{
					num3 = readOnlySpan.Length;
				}
				if (num3 == 0)
				{
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num3);
				num += num3;
				if (readOnlySpan.IsEmpty || !char.IsAsciiLetterUpper(readOnlySpan[0]))
				{
					return false;
				}
				int num4 = MemoryExtensions.IndexOf<char>(readOnlySpan.Slice(1), '\n');
				if (num4 < 0)
				{
					num4 = readOnlySpan.Length - 1;
				}
				readOnlySpan = readOnlySpan.Slice(num4);
				num += num4;
				Capture(0, start, runtextpos = num + 1);
				return true;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__InternalCapitalPattern_5 Instance = new _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__InternalCapitalPattern_5();

	private _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__InternalCapitalPattern_5()
	{
		pattern = "(?![-‑–—])[a-z]+[A-Z].*";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
