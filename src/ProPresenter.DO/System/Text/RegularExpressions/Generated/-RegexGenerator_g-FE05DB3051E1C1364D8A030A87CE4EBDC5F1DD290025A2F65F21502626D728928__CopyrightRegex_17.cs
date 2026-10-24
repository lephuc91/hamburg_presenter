using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_17 : Regex
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
				if (runtextpos == 0)
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
				int capturePosition2 = 0;
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num6 = num;
				num4 = Crawlpos();
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '©')
				{
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num11 = num;
					int i;
					for (i = 0; (uint)i < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[i]); i++)
					{
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					num12 = num;
					goto IL_00eb;
				}
				goto IL_00f7;
				IL_00f7:
				num = num6;
				readOnlySpan = inputSpan.Slice(num);
				UncaptureUntil(num4);
				num2 = 1;
				goto IL_012d;
				IL_00eb:
				capturePosition2 = Crawlpos();
				num2 = 0;
				goto IL_012d;
				IL_012d:
				while (true)
				{
					num8 = num;
					num7 = num;
					num5 = Crawlpos();
					if ((uint)readOnlySpan.Length < 4u || !char.IsAsciiDigit(readOnlySpan[0]) || !char.IsAsciiDigit(readOnlySpan[1]) || !char.IsAsciiDigit(readOnlySpan[2]) || !char.IsAsciiDigit(readOnlySpan[3]))
					{
						goto IL_0197;
					}
					num3 = 0;
					num += 4;
					readOnlySpan = inputSpan.Slice(num);
					goto IL_01c7;
					IL_01c7:
					while (true)
					{
						Capture(1, num8, num);
						num9 = num;
						num13 = num;
						int num15 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
						if (num15 < 0)
						{
							num15 = readOnlySpan.Length;
						}
						readOnlySpan = readOnlySpan.Slice(num15);
						num += num15;
						num14 = num;
						while (true)
						{
							num10 = Crawlpos();
							Capture(2, num9, num);
							if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
							{
								UncaptureUntil(num10);
								if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (num13 >= num14)
								{
									break;
								}
								num = --num14;
								readOnlySpan = inputSpan.Slice(num);
								continue;
							}
							runtextpos = num;
							Capture(0, start, num);
							return true;
						}
						if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num3 == 0)
						{
							break;
						}
						if (num3 != 1)
						{
							continue;
						}
						goto IL_0110;
					}
					goto IL_0197;
					IL_0110:
					if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num2 == 0)
					{
						break;
					}
					if (num2 == 1)
					{
						UncaptureUntil(0);
						return false;
					}
					continue;
					IL_0197:
					num = num7;
					readOnlySpan = inputSpan.Slice(num);
					UncaptureUntil(num5);
					num3 = 1;
					goto IL_01c7;
				}
				UncaptureUntil(capturePosition2);
				if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
				{
					CheckTimeout();
				}
				if (num11 < num12)
				{
					num = --num12;
					readOnlySpan = inputSpan.Slice(num);
					goto IL_00eb;
				}
				goto IL_00f7;
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

	internal static readonly _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_17 Instance = new _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_17();

	private _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_17()
	{
		pattern = "^(?:©\\s*|)([0-9]{4}|)(.*)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
