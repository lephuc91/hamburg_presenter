using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_3 : Regex
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
				if (num <= inputSpan.Length - 13 && num == 0)
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
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				if (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"{{"))
				{
					UncaptureUntil(0);
					return false;
				}
				num += 2;
				readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				num12 = num;
				int num24 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
				if (num24 < 0)
				{
					num24 = readOnlySpan.Length;
				}
				if (num24 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num24);
				num += num24;
				num13 = num;
				num12++;
				while (true)
				{
					num6 = Crawlpos();
					Capture(1, num2, num);
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ',')
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						num3 = num;
						num14 = num;
						int num25 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
						if (num25 < 0)
						{
							num25 = readOnlySpan.Length;
						}
						if (num25 != 0)
						{
							readOnlySpan = readOnlySpan.Slice(num25);
							num += num25;
							num15 = num;
							num14++;
							while (true)
							{
								num7 = Crawlpos();
								Capture(2, num3, num);
								if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '}')
								{
									num++;
									readOnlySpan = inputSpan.Slice(num);
									num16 = num;
									int num26 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
									if (num26 < 0)
									{
										num26 = readOnlySpan.Length;
									}
									readOnlySpan = readOnlySpan.Slice(num26);
									num += num26;
									num17 = num;
									while (true)
									{
										num8 = Crawlpos();
										if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ',')
										{
											num++;
											readOnlySpan = inputSpan.Slice(num);
											num18 = num;
											int num27 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
											if (num27 < 0)
											{
												num27 = readOnlySpan.Length;
											}
											readOnlySpan = readOnlySpan.Slice(num27);
											num += num27;
											num19 = num;
											while (true)
											{
												num9 = Crawlpos();
												if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '{')
												{
													num++;
													readOnlySpan = inputSpan.Slice(num);
													num4 = num;
													num20 = num;
													int num28 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
													if (num28 < 0)
													{
														num28 = readOnlySpan.Length;
													}
													if (num28 != 0)
													{
														readOnlySpan = readOnlySpan.Slice(num28);
														num += num28;
														num21 = num;
														num20++;
														while (true)
														{
															num10 = Crawlpos();
															Capture(3, num4, num);
															if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ',')
															{
																num++;
																readOnlySpan = inputSpan.Slice(num);
																num5 = num;
																num22 = num;
																int num29 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
																if (num29 < 0)
																{
																	num29 = readOnlySpan.Length;
																}
																if (num29 != 0)
																{
																	readOnlySpan = readOnlySpan.Slice(num29);
																	num += num29;
																	num23 = num;
																	num22++;
																	while (true)
																	{
																		num11 = Crawlpos();
																		Capture(4, num5, num);
																		if (!MemoryExtensions.StartsWith<char>(readOnlySpan, (ReadOnlySpan<char>)"}}") || 3 < readOnlySpan.Length || (2 < readOnlySpan.Length && readOnlySpan[2] != '\n'))
																		{
																			UncaptureUntil(num11);
																			if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
																			{
																				CheckTimeout();
																			}
																			if (num22 >= num23 || (num23 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num22, Math.Min(inputSpan.Length, num23 + 1) - num22), (ReadOnlySpan<char>)"}}")) < 0)
																			{
																				break;
																			}
																			num23 += num22;
																			num = num23;
																			readOnlySpan = inputSpan.Slice(num);
																			continue;
																		}
																		Capture(0, start, runtextpos = num + 2);
																		return true;
																	}
																}
															}
															UncaptureUntil(num10);
															if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
															{
																CheckTimeout();
															}
															if (num20 >= num21 || (num21 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num20, num21 - num20), ',')) < 0)
															{
																break;
															}
															num21 += num20;
															num = num21;
															readOnlySpan = inputSpan.Slice(num);
														}
													}
												}
												UncaptureUntil(num9);
												if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
												{
													CheckTimeout();
												}
												if (num18 >= num19 || (num19 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num18, num19 - num18), '{')) < 0)
												{
													break;
												}
												num19 += num18;
												num = num19;
												readOnlySpan = inputSpan.Slice(num);
											}
										}
										UncaptureUntil(num8);
										if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
										{
											CheckTimeout();
										}
										if (num16 >= num17 || (num17 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num16, num17 - num16), ',')) < 0)
										{
											break;
										}
										num17 += num16;
										num = num17;
										readOnlySpan = inputSpan.Slice(num);
									}
								}
								UncaptureUntil(num7);
								if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (num14 >= num15 || (num15 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num14, num15 - num14), '}')) < 0)
								{
									break;
								}
								num15 += num14;
								num = num15;
								readOnlySpan = inputSpan.Slice(num);
							}
						}
					}
					UncaptureUntil(num6);
					if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num12 >= num13 || (num13 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num12, num13 - num12), ',')) < 0)
					{
						break;
					}
					num13 += num12;
					num = num13;
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

	internal static readonly _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_3 Instance = new _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_3();

	private _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__DecodeRegex_3()
	{
		pattern = "^\\{\\{(.+)\\,(.+)\\}.*\\,.*\\{(.+)\\,(.+)\\}\\}$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 5;
	}
}
