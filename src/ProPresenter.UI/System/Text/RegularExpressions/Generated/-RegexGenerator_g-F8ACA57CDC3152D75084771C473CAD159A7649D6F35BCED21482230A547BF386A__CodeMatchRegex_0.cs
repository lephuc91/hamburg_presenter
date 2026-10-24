using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__CodeMatchRegex_0 : Regex
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
				if (runtextpos == 0)
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
				int num34 = 0;
				int num35 = 0;
				int num36 = 0;
				int num37 = 0;
				int num38 = 0;
				int num39 = 0;
				int num40 = 0;
				int num41 = 0;
				int num42 = 0;
				int num43 = 0;
				int num44 = 0;
				int num45 = 0;
				int num46 = 0;
				int num47 = 0;
				int num48 = 0;
				int num49 = 0;
				int num50 = 0;
				int num51 = 0;
				int num52 = 0;
				int num53 = 0;
				int num54 = 0;
				int num55 = 0;
				int num56 = 0;
				int num57 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num26 = num;
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
				num27 = num;
				while (true)
				{
					num10 = Crawlpos();
					num2 = num;
					num28 = num;
					int j;
					for (j = 0; j < 5 && (uint)j < (uint)readOnlySpan.Length; j++)
					{
						ulong num58;
						if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[j] - 48))) & (num58 - 64)) >= 0L)
						{
							break;
						}
					}
					readOnlySpan = readOnlySpan.Slice(j);
					num += j;
					num29 = num;
					while (true)
					{
						num11 = Crawlpos();
						Capture(1, num2, num);
						num42 = num;
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
						num43 = num;
						while (true)
						{
							num18 = Crawlpos();
							num3 = num;
							num44 = num;
							int l;
							for (l = 0; l < 5 && (uint)l < (uint)readOnlySpan.Length; l++)
							{
								ulong num58;
								if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[l] - 48))) & (num58 - 64)) >= 0L)
								{
									break;
								}
							}
							readOnlySpan = readOnlySpan.Slice(l);
							num += l;
							num45 = num;
							while (true)
							{
								num19 = Crawlpos();
								Capture(2, num3, num);
								num46 = num;
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
								num47 = num;
								while (true)
								{
									num20 = Crawlpos();
									num4 = num;
									num48 = num;
									int n;
									for (n = 0; n < 5 && (uint)n < (uint)readOnlySpan.Length; n++)
									{
										ulong num58;
										if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[n] - 48))) & (num58 - 64)) >= 0L)
										{
											break;
										}
									}
									readOnlySpan = readOnlySpan.Slice(n);
									num += n;
									num49 = num;
									while (true)
									{
										num21 = Crawlpos();
										Capture(3, num4, num);
										num50 = num;
										int num59;
										for (num59 = 0; (uint)num59 < (uint)readOnlySpan.Length; num59++)
										{
											char c;
											if ((((c = readOnlySpan[num59]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
											{
												break;
											}
										}
										readOnlySpan = readOnlySpan.Slice(num59);
										num += num59;
										num51 = num;
										while (true)
										{
											num22 = Crawlpos();
											num5 = num;
											num52 = num;
											int num60;
											for (num60 = 0; num60 < 5 && (uint)num60 < (uint)readOnlySpan.Length; num60++)
											{
												ulong num58;
												if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[num60] - 48))) & (num58 - 64)) >= 0L)
												{
													break;
												}
											}
											readOnlySpan = readOnlySpan.Slice(num60);
											num += num60;
											num53 = num;
											while (true)
											{
												num23 = Crawlpos();
												Capture(4, num5, num);
												num54 = num;
												int num61;
												for (num61 = 0; (uint)num61 < (uint)readOnlySpan.Length; num61++)
												{
													char c;
													if ((((c = readOnlySpan[num61]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
													{
														break;
													}
												}
												readOnlySpan = readOnlySpan.Slice(num61);
												num += num61;
												num55 = num;
												while (true)
												{
													num24 = Crawlpos();
													num6 = num;
													num56 = num;
													int num62;
													for (num62 = 0; num62 < 5 && (uint)num62 < (uint)readOnlySpan.Length; num62++)
													{
														ulong num58;
														if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[num62] - 48))) & (num58 - 64)) >= 0L)
														{
															break;
														}
													}
													readOnlySpan = readOnlySpan.Slice(num62);
													num += num62;
													num57 = num;
													while (true)
													{
														num25 = Crawlpos();
														Capture(5, num6, num);
														num30 = num;
														int num63;
														for (num63 = 0; (uint)num63 < (uint)readOnlySpan.Length; num63++)
														{
															char c;
															if ((((c = readOnlySpan[num63]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
															{
																break;
															}
														}
														readOnlySpan = readOnlySpan.Slice(num63);
														num += num63;
														num31 = num;
														while (true)
														{
															num12 = Crawlpos();
															num7 = num;
															num32 = num;
															int num64;
															for (num64 = 0; num64 < 5 && (uint)num64 < (uint)readOnlySpan.Length; num64++)
															{
																ulong num58;
																if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[num64] - 48))) & (num58 - 64)) >= 0L)
																{
																	break;
																}
															}
															readOnlySpan = readOnlySpan.Slice(num64);
															num += num64;
															num33 = num;
															while (true)
															{
																num13 = Crawlpos();
																Capture(6, num7, num);
																num34 = num;
																int num65;
																for (num65 = 0; (uint)num65 < (uint)readOnlySpan.Length; num65++)
																{
																	char c;
																	if ((((c = readOnlySpan[num65]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
																	{
																		break;
																	}
																}
																readOnlySpan = readOnlySpan.Slice(num65);
																num += num65;
																num35 = num;
																while (true)
																{
																	num14 = Crawlpos();
																	num8 = num;
																	num36 = num;
																	int num66;
																	for (num66 = 0; num66 < 5 && (uint)num66 < (uint)readOnlySpan.Length; num66++)
																	{
																		ulong num58;
																		if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[num66] - 48))) & (num58 - 64)) >= 0L)
																		{
																			break;
																		}
																	}
																	readOnlySpan = readOnlySpan.Slice(num66);
																	num += num66;
																	num37 = num;
																	while (true)
																	{
																		num15 = Crawlpos();
																		Capture(7, num8, num);
																		num38 = num;
																		int num67;
																		for (num67 = 0; (uint)num67 < (uint)readOnlySpan.Length; num67++)
																		{
																			char c;
																			if ((((c = readOnlySpan[num67]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
																			{
																				break;
																			}
																		}
																		readOnlySpan = readOnlySpan.Slice(num67);
																		num += num67;
																		num39 = num;
																		while (true)
																		{
																			num16 = Crawlpos();
																			num9 = num;
																			int num68;
																			for (num68 = 0; num68 < 5 && (uint)num68 < (uint)readOnlySpan.Length; num68++)
																			{
																				ulong num58;
																				if ((long)((ulong)(-17873661023223808L << (int)(num58 = (uint)(readOnlySpan[num68] - 48))) & (num58 - 64)) >= 0L)
																				{
																					break;
																				}
																			}
																			readOnlySpan = readOnlySpan.Slice(num68);
																			num += num68;
																			Capture(8, num9, num);
																			num40 = num;
																			int num69;
																			for (num69 = 0; (uint)num69 < (uint)readOnlySpan.Length; num69++)
																			{
																				char c;
																				if ((((c = readOnlySpan[num69]) < '\u0080') ? ("㸀\0\uffffﰀ\u0001\uf800\u0001砀"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\b\u0001!0:A[a{\u007fd") ? 1 : 0)) == 0)
																				{
																					break;
																				}
																			}
																			readOnlySpan = readOnlySpan.Slice(num69);
																			num += num69;
																			num41 = num;
																			while (true)
																			{
																				num17 = Crawlpos();
																				if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
																				{
																					UncaptureUntil(num17);
																					if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
																					{
																						CheckTimeout();
																					}
																					if (num40 >= num41)
																					{
																						break;
																					}
																					num = --num41;
																					readOnlySpan = inputSpan.Slice(num);
																					continue;
																				}
																				runtextpos = num;
																				Capture(0, start, num);
																				return true;
																			}
																			UncaptureUntil(num16);
																			if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
																			{
																				CheckTimeout();
																			}
																			if (num38 >= num39)
																			{
																				break;
																			}
																			num = --num39;
																			readOnlySpan = inputSpan.Slice(num);
																		}
																		UncaptureUntil(num15);
																		if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
																		{
																			CheckTimeout();
																		}
																		if (num36 >= num37)
																		{
																			break;
																		}
																		num = --num37;
																		readOnlySpan = inputSpan.Slice(num);
																	}
																	UncaptureUntil(num14);
																	if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
																	{
																		CheckTimeout();
																	}
																	if (num34 >= num35)
																	{
																		break;
																	}
																	num = --num35;
																	readOnlySpan = inputSpan.Slice(num);
																}
																UncaptureUntil(num13);
																if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
																{
																	CheckTimeout();
																}
																if (num32 >= num33)
																{
																	break;
																}
																num = --num33;
																readOnlySpan = inputSpan.Slice(num);
															}
															UncaptureUntil(num12);
															if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
															{
																CheckTimeout();
															}
															if (num30 >= num31)
															{
																break;
															}
															num = --num31;
															readOnlySpan = inputSpan.Slice(num);
														}
														UncaptureUntil(num25);
														if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
														{
															CheckTimeout();
														}
														if (num56 >= num57)
														{
															break;
														}
														num = --num57;
														readOnlySpan = inputSpan.Slice(num);
													}
													UncaptureUntil(num24);
													if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
													{
														CheckTimeout();
													}
													if (num54 >= num55)
													{
														break;
													}
													num = --num55;
													readOnlySpan = inputSpan.Slice(num);
												}
												UncaptureUntil(num23);
												if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
												{
													CheckTimeout();
												}
												if (num52 >= num53)
												{
													break;
												}
												num = --num53;
												readOnlySpan = inputSpan.Slice(num);
											}
											UncaptureUntil(num22);
											if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
											{
												CheckTimeout();
											}
											if (num50 >= num51)
											{
												break;
											}
											num = --num51;
											readOnlySpan = inputSpan.Slice(num);
										}
										UncaptureUntil(num21);
										if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
										{
											CheckTimeout();
										}
										if (num48 >= num49)
										{
											break;
										}
										num = --num49;
										readOnlySpan = inputSpan.Slice(num);
									}
									UncaptureUntil(num20);
									if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num46 >= num47)
									{
										break;
									}
									num = --num47;
									readOnlySpan = inputSpan.Slice(num);
								}
								UncaptureUntil(num19);
								if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (num44 >= num45)
								{
									break;
								}
								num = --num45;
								readOnlySpan = inputSpan.Slice(num);
							}
							UncaptureUntil(num18);
							if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (num42 >= num43)
							{
								break;
							}
							num = --num43;
							readOnlySpan = inputSpan.Slice(num);
						}
						UncaptureUntil(num11);
						if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
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
					UncaptureUntil(num10);
					if (_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_hasTimeout)
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

	internal static readonly _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__CodeMatchRegex_0 Instance = new _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__CodeMatchRegex_0();

	private _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__CodeMatchRegex_0()
	{
		pattern = "^[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([A-Z0-9]{0,5})[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 9;
	}
}
