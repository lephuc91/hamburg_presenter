using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
internal sealed class _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__IpAddressPattern_16 : Regex
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
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int num15 = 0;
				int num16 = 0;
				int num17 = 0;
				int capturePosition2 = 0;
				int capturePosition3 = 0;
				int capturePosition4 = 0;
				int capturePosition5 = 0;
				int num18 = 0;
				int num19 = 0;
				int num20 = 0;
				int num21 = 0;
				int num22 = 0;
				int num23 = 0;
				int num24 = 0;
				int num25 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num14 = num;
				num10 = num;
				num6 = Crawlpos();
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '2' && (uint)readOnlySpan.Length >= 2u)
				{
					switch (readOnlySpan[1])
					{
					case '5':
						if ((uint)readOnlySpan.Length < 3u || !char.IsBetween(readOnlySpan[2], '0', '5'))
						{
							break;
						}
						num += 3;
						readOnlySpan = inputSpan.Slice(num);
						goto IL_012d;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
						{
							if ((uint)readOnlySpan.Length < 3u || !char.IsAsciiDigit(readOnlySpan[2]))
							{
								break;
							}
							num += 3;
							readOnlySpan = inputSpan.Slice(num);
							goto IL_012d;
						}
						IL_012d:
						num2 = 0;
						goto IL_0218;
					}
				}
				goto IL_0134;
				IL_017c:
				UncaptureUntil(capturePosition2);
				if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
				{
					CheckTimeout();
				}
				if (num18 >= num19)
				{
					UncaptureUntil(0);
					return false;
				}
				num = --num19;
				readOnlySpan = inputSpan.Slice(num);
				goto IL_01b2;
				IL_01b2:
				capturePosition2 = Crawlpos();
				int i;
				for (i = 0; i < 2 && (uint)i < (uint)readOnlySpan.Length && char.IsAsciiDigit(readOnlySpan[i]); i++)
				{
				}
				if (i == 0)
				{
					goto IL_017c;
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				num2 = 1;
				goto IL_0218;
				IL_0218:
				while (true)
				{
					Capture(1, num14, num);
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != '.')
					{
						goto IL_01fe;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num15 = num;
					num11 = num;
					num7 = Crawlpos();
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '2' && (uint)readOnlySpan.Length >= 2u)
					{
						switch (readOnlySpan[1])
						{
						case '5':
							if ((uint)readOnlySpan.Length < 3u || !char.IsBetween(readOnlySpan[2], '0', '5'))
							{
								break;
							}
							num += 3;
							readOnlySpan = inputSpan.Slice(num);
							goto IL_0302;
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
							{
								if ((uint)readOnlySpan.Length < 3u || !char.IsAsciiDigit(readOnlySpan[2]))
								{
									break;
								}
								num += 3;
								readOnlySpan = inputSpan.Slice(num);
								goto IL_0302;
							}
							IL_0302:
							num3 = 0;
							goto IL_03e7;
						}
					}
					goto IL_0309;
					IL_0309:
					num = num11;
					readOnlySpan = inputSpan.Slice(num);
					UncaptureUntil(num7);
					num20 = num;
					if (!readOnlySpan.IsEmpty && char.IsBetween(readOnlySpan[0], '0', '1'))
					{
						readOnlySpan = readOnlySpan.Slice(1);
						num++;
					}
					num21 = num;
					goto IL_0381;
					IL_0351:
					UncaptureUntil(capturePosition3);
					if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num20 >= num21)
					{
						goto IL_01fe;
					}
					num = --num21;
					readOnlySpan = inputSpan.Slice(num);
					goto IL_0381;
					IL_01fe:
					if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num2 == 0)
					{
						break;
					}
					if (num2 != 1)
					{
						continue;
					}
					goto IL_017c;
					IL_03e7:
					while (true)
					{
						Capture(2, num15, num);
						if (readOnlySpan.IsEmpty || readOnlySpan[0] != '.')
						{
							goto IL_03cd;
						}
						num++;
						readOnlySpan = inputSpan.Slice(num);
						num16 = num;
						num12 = num;
						num8 = Crawlpos();
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '2' && (uint)readOnlySpan.Length >= 2u)
						{
							switch (readOnlySpan[1])
							{
							case '5':
								if ((uint)readOnlySpan.Length < 3u || !char.IsBetween(readOnlySpan[2], '0', '5'))
								{
									break;
								}
								num += 3;
								readOnlySpan = inputSpan.Slice(num);
								goto IL_04d1;
							case '0':
							case '1':
							case '2':
							case '3':
							case '4':
								{
									if ((uint)readOnlySpan.Length < 3u || !char.IsAsciiDigit(readOnlySpan[2]))
									{
										break;
									}
									num += 3;
									readOnlySpan = inputSpan.Slice(num);
									goto IL_04d1;
								}
								IL_04d1:
								num4 = 0;
								goto IL_05ba;
							}
						}
						goto IL_04d9;
						IL_04d9:
						num = num12;
						readOnlySpan = inputSpan.Slice(num);
						UncaptureUntil(num8);
						num22 = num;
						if (!readOnlySpan.IsEmpty && char.IsBetween(readOnlySpan[0], '0', '1'))
						{
							readOnlySpan = readOnlySpan.Slice(1);
							num++;
						}
						num23 = num;
						goto IL_0551;
						IL_0521:
						UncaptureUntil(capturePosition4);
						if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num22 >= num23)
						{
							goto IL_03cd;
						}
						num = --num23;
						readOnlySpan = inputSpan.Slice(num);
						goto IL_0551;
						IL_03cd:
						if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num3 == 0)
						{
							break;
						}
						if (num3 != 1)
						{
							continue;
						}
						goto IL_0351;
						IL_05ba:
						while (true)
						{
							Capture(3, num16, num);
							if (readOnlySpan.IsEmpty || readOnlySpan[0] != '.')
							{
								goto IL_059e;
							}
							num++;
							readOnlySpan = inputSpan.Slice(num);
							num17 = num;
							num13 = num;
							num9 = Crawlpos();
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '2' && (uint)readOnlySpan.Length >= 2u)
							{
								switch (readOnlySpan[1])
								{
								case '5':
									if ((uint)readOnlySpan.Length < 3u || !char.IsBetween(readOnlySpan[2], '0', '5'))
									{
										break;
									}
									num += 3;
									readOnlySpan = inputSpan.Slice(num);
									goto IL_06a4;
								case '0':
								case '1':
								case '2':
								case '3':
								case '4':
									{
										if ((uint)readOnlySpan.Length < 3u || !char.IsAsciiDigit(readOnlySpan[2]))
										{
											break;
										}
										num += 3;
										readOnlySpan = inputSpan.Slice(num);
										goto IL_06a4;
									}
									IL_06a4:
									num5 = 0;
									goto IL_078d;
								}
							}
							goto IL_06ac;
							IL_06ac:
							num = num13;
							readOnlySpan = inputSpan.Slice(num);
							UncaptureUntil(num9);
							num24 = num;
							if (!readOnlySpan.IsEmpty && char.IsBetween(readOnlySpan[0], '0', '1'))
							{
								readOnlySpan = readOnlySpan.Slice(1);
								num++;
							}
							num25 = num;
							goto IL_0724;
							IL_06f4:
							UncaptureUntil(capturePosition5);
							if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (num24 >= num25)
							{
								goto IL_059e;
							}
							num = --num25;
							readOnlySpan = inputSpan.Slice(num);
							goto IL_0724;
							IL_059e:
							if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (num4 == 0)
							{
								break;
							}
							if (num4 != 1)
							{
								continue;
							}
							goto IL_0521;
							IL_078d:
							while (true)
							{
								Capture(4, num17, num);
								if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
								{
									if (_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num5 == 0)
									{
										break;
									}
									if (num5 != 1)
									{
										continue;
									}
									goto IL_06f4;
								}
								runtextpos = num;
								Capture(0, start, num);
								return true;
							}
							goto IL_06ac;
							IL_0724:
							capturePosition5 = Crawlpos();
							int j;
							for (j = 0; j < 2 && (uint)j < (uint)readOnlySpan.Length && char.IsAsciiDigit(readOnlySpan[j]); j++)
							{
							}
							if (j == 0)
							{
								goto IL_06f4;
							}
							readOnlySpan = readOnlySpan.Slice(j);
							num += j;
							num5 = 1;
							goto IL_078d;
						}
						goto IL_04d9;
						IL_0551:
						capturePosition4 = Crawlpos();
						int k;
						for (k = 0; k < 2 && (uint)k < (uint)readOnlySpan.Length && char.IsAsciiDigit(readOnlySpan[k]); k++)
						{
						}
						if (k == 0)
						{
							goto IL_0521;
						}
						readOnlySpan = readOnlySpan.Slice(k);
						num += k;
						num4 = 1;
						goto IL_05ba;
					}
					goto IL_0309;
					IL_0381:
					capturePosition3 = Crawlpos();
					int l;
					for (l = 0; l < 2 && (uint)l < (uint)readOnlySpan.Length && char.IsAsciiDigit(readOnlySpan[l]); l++)
					{
					}
					if (l == 0)
					{
						goto IL_0351;
					}
					readOnlySpan = readOnlySpan.Slice(l);
					num += l;
					num3 = 1;
					goto IL_03e7;
				}
				goto IL_0134;
				IL_0134:
				num = num10;
				readOnlySpan = inputSpan.Slice(num);
				UncaptureUntil(num6);
				num18 = num;
				if (!readOnlySpan.IsEmpty && char.IsBetween(readOnlySpan[0], '0', '1'))
				{
					readOnlySpan = readOnlySpan.Slice(1);
					num++;
				}
				num19 = num;
				goto IL_01b2;
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

	internal static readonly _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__IpAddressPattern_16 Instance = new _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__IpAddressPattern_16();

	private _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__IpAddressPattern_16()
	{
		pattern = "^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EFECC16A9B7A861F0F789D0D378F6C778D0DFD3729E6059AC897218766952A5328__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 5;
	}
}
