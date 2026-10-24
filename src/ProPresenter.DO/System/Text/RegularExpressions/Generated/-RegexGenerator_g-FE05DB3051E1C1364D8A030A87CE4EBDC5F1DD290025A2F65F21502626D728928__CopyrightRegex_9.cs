using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_9 : Regex
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
					if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if (num <= inputSpan.Length - 5)
				{
					int num2 = MemoryExtensions.IndexOfAny<char>(inputSpan.Slice(num), 'C', '©');
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
				int num9 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				int num10 = 0;
				if (readOnlySpan.IsEmpty)
				{
					UncaptureUntil(0);
					return false;
				}
				switch (readOnlySpan[0])
				{
				case 'C':
				{
					if (!MemoryExtensions.StartsWith<char>(readOnlySpan.Slice(1), (ReadOnlySpan<char>)"opyright:"))
					{
						UncaptureUntil(0);
						return false;
					}
					num += 10;
					readOnlySpan = inputSpan.Slice(num);
					num6 = num;
					int num12 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
					if (num12 < 0)
					{
						num12 = readOnlySpan.Length;
					}
					readOnlySpan = readOnlySpan.Slice(num12);
					num += num12;
					num7 = num;
					while (true)
					{
						num4 = Crawlpos();
						num2 = num;
						if ((uint)readOnlySpan.Length >= 4u && char.IsDigit(readOnlySpan[0]) && char.IsDigit(readOnlySpan[1]) && char.IsDigit(readOnlySpan[2]) && char.IsDigit(readOnlySpan[3]))
						{
							break;
						}
						UncaptureUntil(num4);
						if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
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
					num += 4;
					readOnlySpan = inputSpan.Slice(num);
					Capture(1, num2, num);
					break;
				}
				case '©':
				{
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num8 = num;
					int num11 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
					if (num11 < 0)
					{
						num11 = readOnlySpan.Length;
					}
					readOnlySpan = readOnlySpan.Slice(num11);
					num += num11;
					num9 = num;
					while (true)
					{
						num5 = Crawlpos();
						num3 = num;
						if ((uint)readOnlySpan.Length >= 4u && char.IsDigit(readOnlySpan[0]) && char.IsDigit(readOnlySpan[1]) && char.IsDigit(readOnlySpan[2]) && char.IsDigit(readOnlySpan[3]))
						{
							break;
						}
						UncaptureUntil(num5);
						if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num8 >= num9)
						{
							UncaptureUntil(0);
							return false;
						}
						num = --num9;
						readOnlySpan = inputSpan.Slice(num);
					}
					num += 4;
					readOnlySpan = inputSpan.Slice(num);
					Capture(2, num3, num);
					break;
				}
				default:
					UncaptureUntil(0);
					return false;
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

	internal static readonly _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_9 Instance = new _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_9();

	private _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_9()
	{
		pattern = "Copyright:.*(\\d{4})|©.*(\\d{4})";
		roptions = RegexOptions.Multiline;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
