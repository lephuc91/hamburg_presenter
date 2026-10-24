using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__UNCRegex_0 : Regex
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				if (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"\\\\"))
				{
					UncaptureUntil(0);
					return false;
				}
				num += 2;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				int num7 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\\');
				if (num7 < 0)
				{
					num7 = readOnlySpan.Length;
				}
				if (num7 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num7);
				num += num7;
				Capture(1, num2, num);
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '\\')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num3 = num;
				num5 = num;
				int num8 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
				if (num8 < 0)
				{
					num8 = readOnlySpan.Length;
				}
				if (num8 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num8);
				num += num8;
				num6 = num;
				num5++;
				while (true)
				{
					num4 = Crawlpos();
					Capture(2, num3, num);
					if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
					{
						break;
					}
					UncaptureUntil(num4);
					if (_003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num5 >= num6)
					{
						UncaptureUntil(0);
						return false;
					}
					num = --num6;
					readOnlySpan = inputSpan.Slice(num);
				}
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

	internal static readonly _003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__UNCRegex_0 Instance = new _003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__UNCRegex_0();

	private _003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__UNCRegex_0()
	{
		pattern = "^\\\\\\\\([^\\\\]+)\\\\(.+)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF4B46D4405B96F7F86721807D0124240ED0698A31136D53C12CA4050B432BB578__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
