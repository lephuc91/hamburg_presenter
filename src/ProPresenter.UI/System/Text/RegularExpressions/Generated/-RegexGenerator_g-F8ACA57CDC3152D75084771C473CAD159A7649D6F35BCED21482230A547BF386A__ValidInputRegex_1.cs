using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputRegex_1 : Regex
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
				if (readOnlySpan.IsEmpty || !char.IsAsciiLetter(readOnlySpan[0]))
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

	internal static readonly _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputRegex_1 Instance = new _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputRegex_1();

	private _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputRegex_1()
	{
		pattern = "^[a-zA-Z]$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
