using System.CodeDom.Compiler;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__NextGroupRegexNeg_2 : Regex
{
	private sealed class RunnerFactory : RegexRunnerFactory
	{
		private sealed class Runner : RegexRunner
		{
			protected override void Scan(ReadOnlySpan<char> inputSpan)
			{
				while (!TryMatchAtCurrentPosition(inputSpan) && runtextpos != inputSpan.Length)
				{
					runtextpos++;
					if (_003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
				}
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
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				num7 = num;
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '-')
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				num8 = num;
				num4 = Crawlpos();
				num9 = num;
				int num13 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
				if (num13 < 0)
				{
					num13 = readOnlySpan.Length;
				}
				readOnlySpan = readOnlySpan.Slice(num13);
				num += num13;
				num10 = num;
				num5 = Crawlpos();
				Capture(1, num2, num);
				num11 = num;
				int i;
				for (i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
				{
					char c;
					if ((((c = readOnlySpan[i]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
					{
						break;
					}
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				num12 = num;
				num6 = Crawlpos();
				num3 = num;
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '-')
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				int num14 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
				if (num14 < 0)
				{
					num14 = readOnlySpan.Length;
				}
				readOnlySpan = readOnlySpan.Slice(num14);
				num += num14;
				Capture(2, num3, num);
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

	internal static readonly _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__NextGroupRegexNeg_2 Instance = new _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__NextGroupRegexNeg_2();

	private _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__NextGroupRegexNeg_2()
	{
		pattern = "(-?[0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*(-?[0-9]*)";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
