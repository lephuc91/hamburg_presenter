using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__ExtensionRegex_0 : Regex
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '.')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				int i;
				for (i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
				{
					char c;
					if ((((c = readOnlySpan[i]) < '\u0080') ? ("쇿\uffff믾\uffff\uffff\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\u0001\u0004\u0001*+./d") ? 1 : 0)) == 0)
					{
						break;
					}
				}
				if (i == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				Capture(1, num2, num);
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

	internal static readonly _003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__ExtensionRegex_0 Instance = new _003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__ExtensionRegex_0();

	private _003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__ExtensionRegex_0()
	{
		pattern = "^\\.([^.*\\s]+)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF1CCF1E6C09450ECA2B4292A0A7490D5145696E05E6E06ADC4F01B8723EFF1CE6__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 2;
	}
}
