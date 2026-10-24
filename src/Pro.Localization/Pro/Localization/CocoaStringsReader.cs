using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.FileSystem;

namespace Pro.Localization;

internal static class CocoaStringsReader
{
	[CompilerGenerated]
	private sealed class _003CRead_003Ed__1 : IEnumerable<KeyValuePair<string, string>>, IEnumerable, IEnumerator<KeyValuePair<string, string>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KeyValuePair<string, string> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string fileName;

		public string _003C_003E3__fileName;

		private StreamReader _003CstreamReader_003E5__2;

		KeyValuePair<string, string> IEnumerator<KeyValuePair<string, string>>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRead_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003CstreamReader_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					if (!FileHelper.WaitForFileAccess(fileName, out FileStream fileStream, enforceFileExists: false, null, FileAccess.Read))
					{
						throw new FileNotFoundException(null, fileName);
					}
					_003CstreamReader_003E5__2 = new StreamReader(fileStream);
					_003C_003E1__state = -3;
					break;
				}
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				string line;
				while ((line = _003CstreamReader_003E5__2.ReadLine()) != null)
				{
					if (TryParseLine(line, out KeyValuePair<string, string>? result))
					{
						_003C_003E2__current = result.Value;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003CstreamReader_003E5__2 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003CstreamReader_003E5__2 != null)
			{
				((IDisposable)_003CstreamReader_003E5__2).Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
		{
			_003CRead_003Ed__1 _003CRead_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CRead_003Ed__ = this;
			}
			else
			{
				_003CRead_003Ed__ = new _003CRead_003Ed__1(0);
			}
			_003CRead_003Ed__.fileName = _003C_003E3__fileName;
			return _003CRead_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<string, string>>)this).GetEnumerator();
		}
	}

	[GeneratedRegex("^\\s*\"(\\w+)\"\\s*=\\s*\"(.*)\"\\s*;\\s*$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex KeyValuePattern()
	{
		return _003CRegexGenerator_g_003EFE947390C33A1E37D8C0D1C12A77E232A6ED161AC9FBCAB4FDE99F7835AAC0F27__KeyValuePattern_0.Instance;
	}

	[IteratorStateMachine(typeof(_003CRead_003Ed__1))]
	public static IEnumerable<KeyValuePair<string, string>> Read(string fileName)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRead_003Ed__1(-2)
		{
			_003C_003E3__fileName = fileName
		};
	}

	internal static bool TryParseLine(string line, [NotNullWhen(true)] out KeyValuePair<string, string>? result)
	{
		result = null;
		Match match = KeyValuePattern().Match(line);
		if (match.Success)
		{
			result = new KeyValuePair<string, string>(match.Groups[1].Value, Unescape(match.Groups[2].Value));
		}
		return match.Success;
	}

	private static string Unescape(string raw)
	{
		StringBuilder stringBuilder = new StringBuilder(raw.Length);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		int num = 0;
		foreach (char c in raw)
		{
			if (flag)
			{
				switch (c)
				{
				case 'r':
					flag2 = true;
					stringBuilder.Append(Environment.NewLine);
					break;
				case 'n':
					if (!flag3)
					{
						stringBuilder.Append(Environment.NewLine);
					}
					break;
				case '"':
				case '%':
				case '\'':
				case '\\':
					stringBuilder.Append(c);
					break;
				}
				flag = false;
			}
			else if (flag4)
			{
				bool flag5 = false;
				switch (c)
				{
				case 'l':
					flag5 = false;
					break;
				case '%':
					stringBuilder.Append(c);
					flag5 = true;
					break;
				case '@':
				case 'd':
				case 'f':
				case 'i':
				case 's':
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2);
					handler.AppendLiteral("{");
					handler.AppendFormatted(num++);
					handler.AppendLiteral("}");
					stringBuilder2.Append(ref handler);
					flag5 = true;
					break;
				}
				}
				flag4 = !flag5;
			}
			else
			{
				switch (c)
				{
				case '\\':
					flag = true;
					break;
				case '%':
					flag4 = true;
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			if (!flag)
			{
				flag3 = flag2;
				flag2 = false;
			}
		}
		return stringBuilder.ToString();
	}
}
