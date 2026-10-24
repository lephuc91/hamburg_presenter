using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__EmailPattern_2 : Regex
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
					if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if (num <= inputSpan.Length - 6)
				{
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					for (int i = 0; i < readOnlySpan.Length; i++)
					{
						if (readOnlySpan[i] != '\n')
						{
							runtextpos = num + i;
							return true;
						}
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
				int num4 = 0;
				int num5 = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				num2 = num;
				int num6 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
				if (num6 < 0)
				{
					num6 = readOnlySpan.Length;
				}
				if (num6 == 0)
				{
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(num6);
				num += num6;
				num3 = num;
				num2++;
				while (true)
				{
					if (runtextpos < num)
					{
						runtextpos = num;
					}
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '@')
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						num4 = num;
						int num7 = MemoryExtensions.IndexOf<char>(readOnlySpan, '\n');
						if (num7 < 0)
						{
							num7 = readOnlySpan.Length;
						}
						if (num7 != 0)
						{
							readOnlySpan = readOnlySpan.Slice(num7);
							num += num7;
							num5 = num;
							num4++;
							while (true)
							{
								if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
								{
									int num8 = MemoryExtensions.IndexOf<char>(readOnlySpan.Slice(1), '\n');
									if (num8 < 0)
									{
										num8 = readOnlySpan.Length - 1;
									}
									if (num8 >= 2)
									{
										readOnlySpan = readOnlySpan.Slice(num8);
										num += num8;
										Capture(0, start, runtextpos = num + 1);
										return true;
									}
								}
								if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (num4 >= num5 || (num5 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num4, num5 - num4), '.')) < 0)
								{
									break;
								}
								num5 += num4;
								num = num5;
								readOnlySpan = inputSpan.Slice(num);
							}
						}
					}
					if (_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num2 >= num3 || (num3 = MemoryExtensions.LastIndexOf<char>(inputSpan.Slice(num2, num3 - num2), '@')) < 0)
					{
						break;
					}
					num3 += num2;
					num = num3;
					readOnlySpan = inputSpan.Slice(num);
				}
				return false;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__EmailPattern_2 Instance = new _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__EmailPattern_2();

	private _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__EmailPattern_2()
	{
		pattern = ".+@.+\\..+.";
		roptions = RegexOptions.None;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
