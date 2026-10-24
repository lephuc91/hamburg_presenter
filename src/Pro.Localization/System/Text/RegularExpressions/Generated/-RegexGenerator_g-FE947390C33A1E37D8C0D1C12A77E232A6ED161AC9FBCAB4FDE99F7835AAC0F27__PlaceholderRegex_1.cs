using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__PlaceholderRegex_1 : Regex
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
					if (_003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_hasTimeout)
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
					int num2 = MemoryExtensions.IndexOf<char>(inputSpan.Slice(num), '\'');
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
				num2 = num;
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '\'')
				{
					UncaptureUntil(0);
					return false;
				}
				int num3 = MemoryExtensions.IndexOf<char>(readOnlySpan.Slice(1), '\'');
				if (num3 < 0)
				{
					num3 = readOnlySpan.Length - 1;
				}
				readOnlySpan = readOnlySpan.Slice(num3);
				num += num3;
				if ((uint)readOnlySpan.Length < 2u || readOnlySpan[1] != '\'')
				{
					UncaptureUntil(0);
					return false;
				}
				num += 2;
				readOnlySpan = inputSpan.Slice(num);
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

	internal static readonly _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__PlaceholderRegex_1 Instance = new _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__PlaceholderRegex_1();

	private _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__PlaceholderRegex_1()
	{
		pattern = "(\\'[^\\']*\\')";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 2;
	}
}
