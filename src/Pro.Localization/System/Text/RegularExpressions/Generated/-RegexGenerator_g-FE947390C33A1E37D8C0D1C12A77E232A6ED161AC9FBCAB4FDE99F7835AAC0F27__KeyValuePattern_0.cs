using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__KeyValuePattern_0 : Regex
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
				if (num <= inputSpan.Length - 7 && num == 0)
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
				int i;
				for (i = 0; (uint)i < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[i]); i++)
				{
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '"')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				int j;
				for (j = 0; (uint)j < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.IsWordChar(readOnlySpan[j]); j++)
				{
				}
				if (j == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(j);
				num += j;
				Capture(1, num2, num);
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '"')
				{
					UncaptureUntil(0);
					return false;
				}
				int k;
				for (k = 1; (uint)k < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[k]); k++)
				{
				}
				readOnlySpan = readOnlySpan.Slice(k);
				num += k;
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '=')
				{
					UncaptureUntil(0);
					return false;
				}
				int l;
				for (l = 1; (uint)l < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[l]); l++)
				{
				}
				readOnlySpan = readOnlySpan.Slice(l);
				num += l;
				if (readOnlySpan.IsEmpty || readOnlySpan[0] != '"')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num3 = num;
				num6 = num;
				int num10 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
				if (num10 < 0)
				{
					num10 = readOnlySpan.Length;
				}
				readOnlySpan = readOnlySpan.Slice(num10);
				num += num10;
				num7 = num;
				while (true)
				{
					num4 = Crawlpos();
					Capture(2, num3, num);
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '"')
					{
						int m;
						for (m = 1; (uint)m < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[m]); m++)
						{
						}
						readOnlySpan = readOnlySpan.Slice(m);
						num += m;
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ';')
						{
							num++;
							readOnlySpan = inputSpan.Slice(num);
							num8 = num;
							int n;
							for (n = 0; (uint)n < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[n]); n++)
							{
							}
							readOnlySpan = readOnlySpan.Slice(n);
							num += n;
							num9 = num;
							while (true)
							{
								num5 = Crawlpos();
								if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
								{
									UncaptureUntil(num5);
									if (_003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num8 >= num9)
									{
										break;
									}
									num = --num9;
									readOnlySpan = inputSpan.Slice(num);
									continue;
								}
								runtextpos = num;
								Capture(0, start, num);
								return true;
							}
						}
					}
					UncaptureUntil(num4);
					if (_003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num6 >= num7 || (num7 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num6, num7 - num6), '"')) < 0)
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

	internal static readonly _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__KeyValuePattern_0 Instance = new _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__KeyValuePattern_0();

	private _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__KeyValuePattern_0()
	{
		pattern = "^\\s*\"(\\w+)\"\\s*=\\s*\"(.*)\"\\s*;\\s*$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
