using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__MatchRegex_0 : Regex
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
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int num15 = 0;
				int num16 = 0;
				int num17 = 0;
				int num18 = 0;
				int num19 = 0;
				int num20 = 0;
				int num21 = 0;
				int num22 = 0;
				int num23 = 0;
				int num24 = 0;
				int num25 = 0;
				int num26 = 0;
				int num27 = 0;
				int num28 = 0;
				int num29 = 0;
				int num30 = 0;
				int num31 = 0;
				int num32 = 0;
				int num33 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
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
				num2 = num;
				num16 = num;
				int num34 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
				if (num34 < 0)
				{
					num34 = readOnlySpan.Length;
				}
				if (num34 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num34);
				num += num34;
				num17 = num;
				num16++;
				while (true)
				{
					num7 = Crawlpos();
					Capture(1, num2, num);
					num18 = num;
					int j;
					for (j = 0; (uint)j < (uint)readOnlySpan.Length; j++)
					{
						char c;
						if ((((c = readOnlySpan[j]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
						{
							break;
						}
					}
					readOnlySpan = readOnlySpan.Slice(j);
					num += j;
					num19 = num;
					while (true)
					{
						num8 = Crawlpos();
						num3 = num;
						num20 = num;
						int num35 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
						if (num35 < 0)
						{
							num35 = readOnlySpan.Length;
						}
						readOnlySpan = readOnlySpan.Slice(num35);
						num += num35;
						num21 = num;
						while (true)
						{
							num9 = Crawlpos();
							Capture(2, num3, num);
							num22 = num;
							int k;
							for (k = 0; (uint)k < (uint)readOnlySpan.Length; k++)
							{
								char c;
								if ((((c = readOnlySpan[k]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
								{
									break;
								}
							}
							readOnlySpan = readOnlySpan.Slice(k);
							num += k;
							num23 = num;
							while (true)
							{
								num10 = Crawlpos();
								num4 = num;
								num24 = num;
								int num36 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
								if (num36 < 0)
								{
									num36 = readOnlySpan.Length;
								}
								readOnlySpan = readOnlySpan.Slice(num36);
								num += num36;
								num25 = num;
								while (true)
								{
									num11 = Crawlpos();
									Capture(3, num4, num);
									num26 = num;
									int l;
									for (l = 0; (uint)l < (uint)readOnlySpan.Length; l++)
									{
										char c;
										if ((((c = readOnlySpan[l]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
										{
											break;
										}
									}
									readOnlySpan = readOnlySpan.Slice(l);
									num += l;
									num27 = num;
									while (true)
									{
										num12 = Crawlpos();
										num5 = num;
										num28 = num;
										int num37 = MemoryExtensions.IndexOfAnyExceptInRange<char>(readOnlySpan, '0', '9');
										if (num37 < 0)
										{
											num37 = readOnlySpan.Length;
										}
										readOnlySpan = readOnlySpan.Slice(num37);
										num += num37;
										num29 = num;
										while (true)
										{
											num13 = Crawlpos();
											Capture(4, num5, num);
											num30 = num;
											int m;
											for (m = 0; (uint)m < (uint)readOnlySpan.Length; m++)
											{
												char c;
												if ((((c = readOnlySpan[m]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
												{
													break;
												}
											}
											readOnlySpan = readOnlySpan.Slice(m);
											num += m;
											num31 = num;
											while (true)
											{
												num14 = Crawlpos();
												num6 = num;
												num32 = num;
												int num38 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
												if (num38 < 0)
												{
													num38 = readOnlySpan.Length;
												}
												if (num38 != 0)
												{
													readOnlySpan = readOnlySpan.Slice(num38);
													num += num38;
													num33 = num;
													num32++;
													while (true)
													{
														num15 = Crawlpos();
														Capture(5, num6, num);
														if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
														{
															UncaptureUntil(num15);
															if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
															{
																CheckTimeout();
															}
															if (num32 >= num33)
															{
																break;
															}
															num = --num33;
															readOnlySpan = inputSpan.Slice(num);
															continue;
														}
														runtextpos = num;
														Capture(0, start, num);
														return true;
													}
												}
												UncaptureUntil(num14);
												if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
												{
													CheckTimeout();
												}
												if (num30 >= num31 || (num31 = MemoryExtensions.LastIndexOfAnyExcept<char>(inputSpan.Slice(num30, num31 - num30), '\n')) < 0)
												{
													break;
												}
												num31 += num30;
												num = num31;
												readOnlySpan = inputSpan.Slice(num);
											}
											UncaptureUntil(num13);
											if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
											{
												CheckTimeout();
											}
											if (num28 >= num29)
											{
												break;
											}
											num = --num29;
											readOnlySpan = inputSpan.Slice(num);
										}
										UncaptureUntil(num12);
										if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
										{
											CheckTimeout();
										}
										if (num26 >= num27)
										{
											break;
										}
										num = --num27;
										readOnlySpan = inputSpan.Slice(num);
									}
									UncaptureUntil(num11);
									if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num24 >= num25)
									{
										break;
									}
									num = --num25;
									readOnlySpan = inputSpan.Slice(num);
								}
								UncaptureUntil(num10);
								if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (num22 >= num23)
								{
									break;
								}
								num = --num23;
								readOnlySpan = inputSpan.Slice(num);
							}
							UncaptureUntil(num9);
							if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (num20 >= num21)
							{
								break;
							}
							num = --num21;
							readOnlySpan = inputSpan.Slice(num);
						}
						UncaptureUntil(num8);
						if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num18 >= num19)
						{
							break;
						}
						num = --num19;
						readOnlySpan = inputSpan.Slice(num);
					}
					UncaptureUntil(num7);
					if (_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num16 >= num17)
					{
						break;
					}
					num = --num17;
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

	internal static readonly _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__MatchRegex_0 Instance = new _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__MatchRegex_0();

	private _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__MatchRegex_0()
	{
		pattern = "^[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]+)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*(.+)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 6;
	}
}
