using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__GuidToken_15 : Regex
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
				if (num <= inputSpan.Length - 4)
				{
					int num2 = MemoryExtensions.IndexOfAny(inputSpan.Slice(num), _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_indexOfString_0EB7C57F1E1613EE8D069A853AC87996AAC4AB66EE1DBD194489F3BEE08ED9A3);
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"${"))
				{
					UncaptureUntil(0);
					return false;
				}
				num += 2;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				int num3 = MemoryExtensions.IndexOfAnyExcept<char>(readOnlySpan, _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_ascii_20FF03FEFFFF07FEFFFF07);
				if (num3 < 0)
				{
					num3 = readOnlySpan.Length;
				}
				if (num3 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num3);
				num += num3;
				Capture(1, num2, num);
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '}')
				{
					UncaptureUntil(0);
					return false;
				}
				Capture(0, start, runtextpos = num + 1);
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

	internal static readonly _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__GuidToken_15 Instance = new _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__GuidToken_15();

	private _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__GuidToken_15()
	{
		pattern = "\\$\\{([a-zA-Z0-9\\-]+)\\}";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 2;
	}
}
