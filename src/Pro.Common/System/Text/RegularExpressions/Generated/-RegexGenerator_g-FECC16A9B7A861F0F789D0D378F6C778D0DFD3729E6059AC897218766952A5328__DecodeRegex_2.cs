using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_2 : Regex
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
				if (num <= inputSpan.Length - 5 && num == 0)
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
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '{')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				num6 = num;
				int num10 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
				if (num10 < 0)
				{
					num10 = readOnlySpan.Length;
				}
				if (num10 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num10);
				num += num10;
				num7 = num;
				num6++;
				while (true)
				{
					num4 = Crawlpos();
					Capture(1, num2, num);
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ':')
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						num3 = num;
						num8 = num;
						int num11 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
						if (num11 < 0)
						{
							num11 = readOnlySpan.Length;
						}
						if (num11 != 0)
						{
							readOnlySpan = readOnlySpan.Slice(num11);
							num += num11;
							num9 = num;
							num8++;
							while (true)
							{
								num5 = Crawlpos();
								Capture(2, num3, num);
								if (readOnlySpan.IsEmpty || readOnlySpan[0] != '}' || 2 < readOnlySpan.Length || (1 < readOnlySpan.Length && readOnlySpan[1] != '\n'))
								{
									UncaptureUntil(num5);
									if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num8 >= num9 || (num9 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num8, num9 - num8), '}')) < 0)
									{
										break;
									}
									num9 += num8;
									num = num9;
									readOnlySpan = inputSpan.Slice(num);
									continue;
								}
								Capture(0, start, runtextpos = num + 1);
								return true;
							}
						}
					}
					UncaptureUntil(num4);
					if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num6 >= num7 || (num7 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num6, num7 - num6), ':')) < 0)
					{
						break;
					}
					num7 += num6;
					num = num7;
					readOnlySpan = inputSpan.Slice(num);
				}
				UncaptureUntil(0);
				return false;
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

	internal static readonly _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_2 Instance = new _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_2();

	private _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_2()
	{
		pattern = "^\\{(.+)\\:(.+)\\}$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
