using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Pattern_0 : Regex
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
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int capturePosition2 = 0;
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				int pos = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num5 = num;
				char c;
				if (!readOnlySpan.IsEmpty && ((c = readOnlySpan[0]) == '+' || c == '-'))
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ' ')
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				num6 = num;
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '\\')
				{
					UncaptureUntil(0);
					return false;
				}
				num4 = num;
				num3 = Crawlpos();
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num8 = num;
				int num11 = MemoryExtensions.IndexOfAnyExcept<char>(readOnlySpan, 'd');
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
					goto IL_0137;
				}
				goto IL_0143;
				IL_0143:
				num = num4;
				readOnlySpan = inputSpan.Slice(num);
				UncaptureUntil(num3);
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num7 = num;
				if (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"\\g<1>\\"))
				{
					UncaptureUntil(0);
					return false;
				}
				num += 6;
				readOnlySpan = inputSpan.Slice(num);
				Capture(3, num7, num);
				num2 = 1;
				goto IL_01c1;
				IL_01c1:
				while (true)
				{
					Capture(2, num6, num);
					num10 = 0;
					while (true)
					{
						_003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
						num10++;
						int start2 = num;
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ' ')
						{
							readOnlySpan = readOnlySpan.Slice(1);
							num++;
						}
						ulong num12;
						if (!readOnlySpan.IsEmpty && (long)((ulong)(-3170534137668820992L << (int)(num12 = (uint)(readOnlySpan[0] - 42))) & (num12 - 64)) < 0L)
						{
							if ((uint)readOnlySpan.Length > 1u && readOnlySpan[1] == ' ')
							{
								readOnlySpan = readOnlySpan.Slice(1);
								num++;
							}
							if (MemoryExtensions.StartsWith<char>(readOnlySpan.Slice(1), (ReadOnlySpan<char>)"\\g<1>"))
							{
								num += 6;
								readOnlySpan = inputSpan.Slice(num);
								Capture(4, start2, num);
								if (num10 == 0)
								{
									continue;
								}
								goto IL_02dd;
							}
						}
						goto IL_02a3;
						IL_02dd:
						Capture(1, num5, num);
						if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
						{
							runtextpos = num;
							Capture(0, start, num);
							return true;
						}
						goto IL_02a3;
						IL_02a3:
						if (--num10 < 0)
						{
							break;
						}
						num = runstack[--pos];
						UncaptureUntil(runstack[--pos]);
						readOnlySpan = inputSpan.Slice(num);
						goto IL_02dd;
					}
					if (_003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_hasTimeout)
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
				}
				UncaptureUntil(capturePosition2);
				if (_003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_hasTimeout)
				{
					CheckTimeout();
				}
				if (num8 < num9)
				{
					num = --num9;
					readOnlySpan = inputSpan.Slice(num);
					goto IL_0137;
				}
				goto IL_0143;
				IL_0137:
				capturePosition2 = Crawlpos();
				num2 = 0;
				goto IL_01c1;
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

	internal static readonly _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Pattern_0 Instance = new _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Pattern_0();

	private _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Pattern_0()
	{
		pattern = "^([-+]? ?(\\\\d+|\\\\(\\\\g<1>\\\\))( ?[-+*\\\\/] ?\\\\g<1>)?)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 5;
	}
}
