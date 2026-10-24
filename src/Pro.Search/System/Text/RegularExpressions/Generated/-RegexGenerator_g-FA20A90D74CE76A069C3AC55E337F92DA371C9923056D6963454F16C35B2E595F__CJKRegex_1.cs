using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__CJKRegex_1 : Regex
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
					if (_003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__Utilities.s_hasTimeout)
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
					int num2 = inputSpan.Slice(num).IndexOfNonAsciiOrAny_964D26B45878A1E76C50F1FE92D9DEF987EEFF4B5343F10BB4DCBA29A5F17939();
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
				if (num == 0 && !readOnlySpan.IsEmpty && char.IsBetween(readOnlySpan[0], 'ᄀ', 'ᇿ'))
				{
					num++;
					readOnlySpan = inputSpan.Slice(num);
				}
				else
				{
					num = num2;
					readOnlySpan = inputSpan.Slice(num);
					char ch;
					if (!readOnlySpan.IsEmpty && (ch = readOnlySpan[0]) >= '\u0080' && RegexRunner.CharInClass(ch, "\0\u000e\0⺀⼀\u3000\u3040゠\u3100㈀䷀一ꀀ가ힰ︰﹐"))
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
					}
					else
					{
						num = num2;
						readOnlySpan = inputSpan.Slice(num);
						if (readOnlySpan.IsEmpty || !char.IsBetween(readOnlySpan[0], '\u3040', 'ゟ'))
						{
							return false;
						}
						if (2 < readOnlySpan.Length || (1 < readOnlySpan.Length && readOnlySpan[1] != '\n'))
						{
							return false;
						}
						num++;
						readOnlySpan = inputSpan.Slice(num);
					}
				}
				runtextpos = num;
				Capture(0, start, num);
				return true;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__CJKRegex_1 Instance = new _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__CJKRegex_1();

	private _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__CJKRegex_1()
	{
		pattern = "^\\p{IsHangulJamo}|\\p{IsCJKRadicalsSupplement}|\\p{IsCJKSymbolsandPunctuation}|\\p{IsEnclosedCJKLettersandMonths}|\\p{IsCJKCompatibility}|\\p{IsCJKUnifiedIdeographsExtensionA}|\\p{IsCJKUnifiedIdeographs}|\\p{IsHangulSyllables}|\\p{IsCJKCompatibilityForms}|\\p{IsKatakana}|\\p{IsHiragana}$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFA20A90D74CE76A069C3AC55E337F92DA371C9923056D6963454F16C35B2E595F__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
