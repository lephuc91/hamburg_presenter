using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__HashtagAndUserRegexGetter_7 : Regex
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
				if (num <= inputSpan.Length - 2)
				{
					int num2 = MemoryExtensions.IndexOfAny<char>(inputSpan.Slice(num), '#', '@');
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
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				readOnlySpan = inputSpan.Slice(num);
				int num9 = num;
				if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
				{
					CheckTimeout();
				}
				char c;
				if ((uint)(num - 1) < inputSpan.Length && (c = inputSpan[num - 1]) < '{' && ("\0\0\bϿ\uffff蟿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) != 0)
				{
					num--;
					UncaptureUntil(0);
					return false;
				}
				num = num9;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				int num10 = num8;
				if (readOnlySpan.IsEmpty)
				{
					UncaptureUntil(0);
					return false;
				}
				switch (readOnlySpan[0])
				{
				case '#':
				{
					num3 = num;
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != '#')
					{
						UncaptureUntil(0);
						return false;
					}
					int num13 = MemoryExtensions.IndexOfAnyExcept<char>(readOnlySpan.Slice(1), _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_asciiWordChars);
					if (num13 < 0)
					{
						num13 = readOnlySpan.Length - 1;
					}
					if (num13 == 0)
					{
						UncaptureUntil(0);
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(num13);
					num += num13;
					num++;
					readOnlySpan = inputSpan.Slice(num);
					Capture(2, num3, num);
					break;
				}
				case '@':
				{
					num4 = num;
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != '@')
					{
						UncaptureUntil(0);
						return false;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num6 = num;
					int num11 = MemoryExtensions.IndexOfAnyExcept<char>(readOnlySpan, _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_ascii_40FF03FEFFFF87FEFFFF07);
					if (num11 < 0)
					{
						num11 = readOnlySpan.Length;
					}
					if (num11 == 0)
					{
						UncaptureUntil(0);
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(num11);
					num += num11;
					num7 = num;
					num6++;
					int num12;
					while (true)
					{
						num5 = Crawlpos();
						readOnlySpan = inputSpan.Slice(num);
						num12 = num;
						if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (readOnlySpan.IsEmpty || readOnlySpan[0] != '.')
						{
							break;
						}
						UncaptureUntil(num5);
						if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num6 >= num7)
						{
							UncaptureUntil(0);
							return false;
						}
						num = --num7;
						readOnlySpan = inputSpan.Slice(num);
					}
					num = num12;
					readOnlySpan = inputSpan.Slice(num);
					Capture(3, num4, num);
					break;
				}
				default:
					UncaptureUntil(0);
					return false;
				}
				num8 = num10;
				Capture(1, num2, num);
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

	internal static readonly _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__HashtagAndUserRegexGetter_7 Instance = new _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__HashtagAndUserRegexGetter_7();

	private _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__HashtagAndUserRegexGetter_7()
	{
		pattern = "(?<![#@a-zA-Z0-9_])(([#][a-zA-Z0-9_]+)|([@][a-zA-Z0-9_\\.]+(?!\\.)))";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 4;
	}
}
