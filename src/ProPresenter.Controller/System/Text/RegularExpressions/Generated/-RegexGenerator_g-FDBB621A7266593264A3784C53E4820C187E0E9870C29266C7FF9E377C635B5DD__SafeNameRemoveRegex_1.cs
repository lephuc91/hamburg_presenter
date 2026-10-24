using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__SafeNameRemoveRegex_1 : Regex
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
					if (_003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_hasTimeout)
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
					int num2 = MemoryExtensions.IndexOfAnyExcept<char>(inputSpan.Slice(num), _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_ascii_20FF03FEFFFF07FEFFFF07);
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
				int num2 = MemoryExtensions.IndexOfAny<char>(readOnlySpan, _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_ascii_20FF03FEFFFF07FEFFFF07);
				if (num2 < 0)
				{
					num2 = readOnlySpan.Length;
				}
				if (num2 == 0)
				{
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num2);
				Capture(0, start, runtextpos = num + num2);
				return true;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__SafeNameRemoveRegex_1 Instance = new _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__SafeNameRemoveRegex_1();

	private _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__SafeNameRemoveRegex_1()
	{
		pattern = "[^A-Za-z0-9\\-]+";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
