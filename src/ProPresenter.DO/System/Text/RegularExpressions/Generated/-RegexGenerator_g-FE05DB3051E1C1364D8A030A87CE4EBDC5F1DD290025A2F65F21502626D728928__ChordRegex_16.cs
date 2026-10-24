using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__ChordRegex_16 : Regex
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
					if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
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
				int pos = 0;
				int num7 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				num4 = 0;
				while (true)
				{
					_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
					num4++;
					int num8 = num;
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '[')
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						int num9 = num;
						num3 = num;
						while (true)
						{
							num2 = Crawlpos();
							_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.StackPush(ref runstack, ref pos, num3, num2);
							Capture(2, num9, num);
							_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.StackPush(ref runstack, ref pos, num9);
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ']')
							{
								break;
							}
							num9 = runstack[--pos];
							_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.StackPop(runstack, ref pos, out num2, out num3);
							UncaptureUntil(num2);
							if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							num = num3;
							readOnlySpan = inputSpan.Slice(num);
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] != '\n')
							{
								num++;
								readOnlySpan = inputSpan.Slice(num);
								num3 = MemoryExtensions.IndexOfAny<char>(readOnlySpan, '\n', ']');
								if ((uint)num3 < (uint)readOnlySpan.Length && readOnlySpan[num3] != '\n')
								{
									num += num3;
									readOnlySpan = inputSpan.Slice(num);
									num3 = num;
									continue;
								}
							}
							goto IL_019e;
						}
						num++;
						readOnlySpan = inputSpan.Slice(num);
						Capture(1, num8, num);
						_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.StackPush(ref runstack, ref pos, num8);
						if (num4 != 0)
						{
							break;
						}
						continue;
					}
					goto IL_019e;
					IL_019e:
					if (--num4 < 0)
					{
						UncaptureUntil(0);
						return false;
					}
					num = runstack[--pos];
					UncaptureUntil(runstack[--pos]);
					readOnlySpan = inputSpan.Slice(num);
					break;
				}
				num7 = pos;
				num6 = num;
				num5 = 0;
				do
				{
					_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num6, num);
					num6 = num;
					num5++;
					int start2 = num;
					int num10 = MemoryExtensions.IndexOf<char>(readOnlySpan, '[');
					if (num10 < 0)
					{
						num10 = readOnlySpan.Length;
					}
					readOnlySpan = readOnlySpan.Slice(num10);
					num += num10;
					Capture(3, start2, num);
				}
				while (num != num6 && num5 == 0);
				pos = num7;
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

	internal static readonly _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__ChordRegex_16 Instance = new _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__ChordRegex_16();

	private _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__ChordRegex_16()
	{
		pattern = "(\\[(.*?)\\])?([^\\[]*)?";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 4;
	}
}
