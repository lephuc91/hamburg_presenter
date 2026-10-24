using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__TwoColonIntegerPattern_14 : Regex
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
					if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if (num <= inputSpan.Length - 5)
				{
					int num2 = MemoryExtensions.IndexOfAny<char>(inputSpan.Slice(num), _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_ascii_20FF030000000000000000);
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
				int num4 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '-')
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				int num5 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
				if (num5 < 0)
				{
					num5 = readOnlySpan.Length;
				}
				if (num5 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num5);
				num += num5;
				Capture(1, num2, num);
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != ':')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num3 = num;
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '-')
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				int num6 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
				if (num6 < 0)
				{
					num6 = readOnlySpan.Length;
				}
				if (num6 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num6);
				num += num6;
				Capture(2, num3, num);
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != ':')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num4 = num;
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '-')
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				int num7 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
				if (num7 < 0)
				{
					num7 = readOnlySpan.Length;
				}
				if (num7 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num7);
				num += num7;
				Capture(3, num4, num);
				if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
				{
					UncaptureUntil(0);
					return false;
				}
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

	internal static readonly _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__TwoColonIntegerPattern_14 Instance = new _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__TwoColonIntegerPattern_14();

	private _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__TwoColonIntegerPattern_14()
	{
		pattern = "(-?[0-9]+)\\:(-?[0-9]+)\\:(-?[0-9]+)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 4;
	}
}
