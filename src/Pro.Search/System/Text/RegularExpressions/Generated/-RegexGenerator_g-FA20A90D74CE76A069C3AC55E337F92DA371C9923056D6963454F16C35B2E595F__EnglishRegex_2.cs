using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__EnglishRegex_2 : Regex
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
				if ((uint)num < (uint)inputSpan.Length && num == 0)
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					return false;
				}
				if (readOnlySpan.IsEmpty || !char.IsAscii(readOnlySpan[0]))
				{
					return false;
				}
				if (2 < readOnlySpan.Length || (1 < readOnlySpan.Length && readOnlySpan[1] != '\n'))
				{
					return false;
				}
				Capture(0, start, runtextpos = num + 1);
				return true;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__EnglishRegex_2 Instance = new _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__EnglishRegex_2();

	private _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__EnglishRegex_2()
	{
		pattern = "^\\p{IsBasicLatin}$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
