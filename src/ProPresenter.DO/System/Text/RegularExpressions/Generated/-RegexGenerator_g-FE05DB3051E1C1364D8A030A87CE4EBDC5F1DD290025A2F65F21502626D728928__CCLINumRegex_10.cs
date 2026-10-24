using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CCLINumRegex_10 : Regex
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
					int num2 = MemoryExtensions.IndexOfAny(inputSpan.Slice(num), _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_indexOfString_CCLI_Ordinal);
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"CCLI"))
				{
					UncaptureUntil(0);
					return false;
				}
				if ((uint)readOnlySpan.Length < 5u)
				{
					UncaptureUntil(0);
					return false;
				}
				switch (readOnlySpan[4])
				{
				case ':':
				{
					num += 5;
					readOnlySpan = inputSpan.Slice(num);
					num2 = num;
					int num5 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
					if (num5 < 0)
					{
						num5 = readOnlySpan.Length;
					}
					readOnlySpan = readOnlySpan.Slice(num5);
					num += num5;
					Capture(1, num2, num);
					break;
				}
				case ' ':
				{
					if (!MemoryExtensions.StartsWith<char>(readOnlySpan.Slice(5), (ReadOnlySpan<char>)"License #"))
					{
						UncaptureUntil(0);
						return false;
					}
					num += 14;
					readOnlySpan = inputSpan.Slice(num);
					num3 = num;
					int num4 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
					if (num4 < 0)
					{
						num4 = readOnlySpan.Length;
					}
					readOnlySpan = readOnlySpan.Slice(num4);
					num += num4;
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

	internal static readonly _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CCLINumRegex_10 Instance = new _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CCLINumRegex_10();

	private _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CCLINumRegex_10()
	{
		pattern = "CCLI:(.*)|CCLI License #(.*)";
		roptions = RegexOptions.Multiline;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
