using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__PlaylistPathPattern_3 : Regex
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
				if (num <= inputSpan.Length - 3 && num == 0)
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					return false;
				}
				num2 = 0;
				while (true)
				{
					_003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.StackPush(ref runstack, ref pos, num);
					num2++;
					int num3 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
					if (num3 < 0)
					{
						num3 = readOnlySpan.Length;
					}
					if (num3 == 0)
					{
						break;
					}
					readOnlySpan = readOnlySpan.Slice(num3);
					num += num3;
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != '.')
					{
						break;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
				}
				while (true)
				{
					if (--num2 < 0)
					{
						return false;
					}
					num = runstack[--pos];
					readOnlySpan = inputSpan.Slice(num);
					int num4 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
					if (num4 < 0)
					{
						num4 = readOnlySpan.Length;
					}
					if (num4 == 0)
					{
						continue;
					}
					readOnlySpan = readOnlySpan.Slice(num4);
					num += num4;
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != ':')
					{
						continue;
					}
					int num5 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan.Slice(1), '0', '9');
					if (num5 < 0)
					{
						num5 = readOnlySpan.Length - 1;
					}
					if (num5 != 0)
					{
						readOnlySpan = readOnlySpan.Slice(num5);
						num += num5;
						if (2 >= readOnlySpan.Length && (1 >= readOnlySpan.Length || readOnlySpan[1] == '\n'))
						{
							break;
						}
					}
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

	internal static readonly _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__PlaylistPathPattern_3 Instance = new _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__PlaylistPathPattern_3();

	private _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__PlaylistPathPattern_3()
	{
		pattern = "^(?:[0-9]+\\.)*[0-9]+\\:[0-9]+$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
