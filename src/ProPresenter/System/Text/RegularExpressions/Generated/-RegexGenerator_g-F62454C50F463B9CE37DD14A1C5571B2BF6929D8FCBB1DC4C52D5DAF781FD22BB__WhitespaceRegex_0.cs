using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__WhitespaceRegex_0 : Regex
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
					if (_003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if ((uint)num < (uint)inputSpan.Length)
				{
					int num2 = MemoryExtensions.IndexOfAny<char>(inputSpan.Slice(num), _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__Utilities.s_whitespace);
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
				int i;
				for (i = 0; (uint)i < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[i]); i++)
				{
				}
				if (i == 0)
				{
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(i);
				Capture(0, start, runtextpos = num + i);
				return true;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__WhitespaceRegex_0 Instance = new _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__WhitespaceRegex_0();

	private _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__WhitespaceRegex_0()
	{
		pattern = "\\s+";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
