using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__KeyValuePattern_0 : Regex
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
				if (num <= inputSpan.Length - 3 && num == 0)
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num2 = num;
				if (readOnlySpan.IsEmpty || readOnlySpan[0] == '\n')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				readOnlySpan = inputSpan.Slice(num);
				num8 = num;
				while (true)
				{
					num7 = Crawlpos();
					Capture(1, num2, num);
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '=')
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						num3 = num;
						num5 = num;
						int num9 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
						if (num9 < 0)
						{
							num9 = readOnlySpan.Length;
						}
						readOnlySpan = readOnlySpan.Slice(num9);
						num += num9;
						num6 = num;
						while (true)
						{
							num4 = Crawlpos();
							Capture(2, num3, num);
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ';')
							{
								int num10 = num;
								if (2 >= readOnlySpan.Length && (1 >= readOnlySpan.Length || readOnlySpan[1] == '\n'))
								{
									num++;
									readOnlySpan = inputSpan.Slice(num);
								}
								else
								{
									num = num10;
									readOnlySpan = inputSpan.Slice(num);
									int i;
									for (i = 1; (uint)i < (uint)readOnlySpan.Length && char.IsWhiteSpace(readOnlySpan[i]); i++)
									{
									}
									readOnlySpan = readOnlySpan.Slice(i);
									num += i;
									if (readOnlySpan.IsEmpty || readOnlySpan[0] != '#')
									{
										goto IL_0167;
									}
									int num11 = MemoryExtensions.IndexOf<char>(readOnlySpan.Slice(1), '\n');
									if (num11 < 0)
									{
										num11 = readOnlySpan.Length - 1;
									}
									readOnlySpan = readOnlySpan.Slice(num11);
									num += num11;
									num++;
									readOnlySpan = inputSpan.Slice(num);
								}
								runtextpos = num;
								Capture(0, start, num);
								return true;
							}
							goto IL_0167;
							IL_0167:
							UncaptureUntil(num4);
							if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (num5 >= num6 || (num6 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num5, num6 - num5), ';')) < 0)
							{
								break;
							}
							num6 += num5;
							num = num6;
							readOnlySpan = inputSpan.Slice(num);
						}
					}
					UncaptureUntil(num7);
					if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					num = num8;
					readOnlySpan = inputSpan.Slice(num);
					if (readOnlySpan.IsEmpty || readOnlySpan[0] == '\n')
					{
						UncaptureUntil(0);
						return false;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num8 = MemoryExtensions.IndexOfAny<char>(readOnlySpan, '\n', '=');
					if ((uint)num8 >= (uint)readOnlySpan.Length || readOnlySpan[num8] == '\n')
					{
						break;
					}
					num += num8;
					readOnlySpan = inputSpan.Slice(num);
					num8 = num;
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

	internal static readonly _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__KeyValuePattern_0 Instance = new _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__KeyValuePattern_0();

	private _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__KeyValuePattern_0()
	{
		pattern = "^(.+?)=(.*);(?:$|\\s*\\#.*)";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 3;
	}
}
