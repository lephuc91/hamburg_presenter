using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace Pro.Common.Strings;

public static class StringExtensions
{
	[CompilerGenerated]
	private sealed class _003CAllIndicesOf_003Ed__8 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string value;

		public string _003C_003E3__value;

		private string str;

		public string _003C_003E3__str;

		private StringComparison comparison;

		public StringComparison _003C_003E3__comparison;

		private int _003Cindex_003E5__2;

		int IEnumerator<int>.Current
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
		public _003CAllIndicesOf_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("the string to find may not be empty", "value");
				}
				_003Cindex_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Cindex_003E5__2 += value.Length;
				break;
			}
			if (_003Cindex_003E5__2 < str.Length)
			{
				_003Cindex_003E5__2 = str.IndexOf(value, _003Cindex_003E5__2, comparison);
				if (_003Cindex_003E5__2 != -1)
				{
					_003C_003E2__current = _003Cindex_003E5__2;
					_003C_003E1__state = 1;
					return true;
				}
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			_003CAllIndicesOf_003Ed__8 _003CAllIndicesOf_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CAllIndicesOf_003Ed__ = this;
			}
			else
			{
				_003CAllIndicesOf_003Ed__ = new _003CAllIndicesOf_003Ed__8(0);
			}
			_003CAllIndicesOf_003Ed__.str = _003C_003E3__str;
			_003CAllIndicesOf_003Ed__.value = _003C_003E3__value;
			_003CAllIndicesOf_003Ed__.comparison = _003C_003E3__comparison;
			return _003CAllIndicesOf_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetUTF32Indices_003Ed__10 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string value;

		public string _003C_003E3__value;

		private int _003Ci_003E5__2;

		int IEnumerator<int>.Current
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
		public _003CGetUTF32Indices_003Ed__10(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_005f;
			}
			_003C_003E1__state = -1;
			_003Ci_003E5__2 = 0;
			goto IL_006f;
			IL_005f:
			_003Ci_003E5__2++;
			goto IL_006f;
			IL_006f:
			if (_003Ci_003E5__2 < value.Length)
			{
				if (char.ConvertToUtf32(value, _003Ci_003E5__2) > 65535)
				{
					_003C_003E2__current = _003Ci_003E5__2++;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_005f;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			_003CGetUTF32Indices_003Ed__10 _003CGetUTF32Indices_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetUTF32Indices_003Ed__ = this;
			}
			else
			{
				_003CGetUTF32Indices_003Ed__ = new _003CGetUTF32Indices_003Ed__10(0);
			}
			_003CGetUTF32Indices_003Ed__.value = _003C_003E3__value;
			return _003CGetUTF32Indices_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CToCodepoints_003Ed__16 : IEnumerable<uint>, IEnumerable, IEnumerator<uint>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private uint _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string text;

		public string _003C_003E3__text;

		private int _003Ci_003E5__2;

		uint IEnumerator<uint>.Current
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
		public _003CToCodepoints_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (text == null)
				{
					return false;
				}
				_003Ci_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				if (char.IsHighSurrogate(text[_003Ci_003E5__2]))
				{
					_003Ci_003E5__2++;
				}
				_003Ci_003E5__2++;
				break;
			}
			if (_003Ci_003E5__2 < text.Length)
			{
				_003C_003E2__current = (uint)char.ConvertToUtf32(text, _003Ci_003E5__2);
				_003C_003E1__state = 1;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<uint> IEnumerable<uint>.GetEnumerator()
		{
			_003CToCodepoints_003Ed__16 _003CToCodepoints_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToCodepoints_003Ed__ = this;
			}
			else
			{
				_003CToCodepoints_003Ed__ = new _003CToCodepoints_003Ed__16(0);
			}
			_003CToCodepoints_003Ed__.text = _003C_003E3__text;
			return _003CToCodepoints_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<uint>)this).GetEnumerator();
		}
	}

	public static readonly char[] NonBreakingSpaces = new char[4] { '\u00a0', '\u202f', '\u2007', '\ufeff' };

	public const char ZeroWidthSpace = '\u200b';

	public static readonly char[] AdditionalCharactersAllowingBreak = new char[2] { '-', '\u200b' };

	public static string SubstringRange(this string source, int start, int end)
	{
		return source.Substring(start, (end - start).Abs() + 1);
	}

	public static int CompareIgnoreCase(this string source, string target)
	{
		return string.Compare(source, target, ignoreCase: true, CultureInfo.InvariantCulture);
	}

	public static bool AreEqualIgnoreCase(this string source, string target)
	{
		return source.CompareIgnoreCase(target) == 0;
	}

	public static string Inverse(this string source)
	{
		if (string.IsNullOrWhiteSpace(source))
		{
			return string.Empty;
		}
		return new string(source.Reverse().ToArray());
	}

	public static string DuplicateName<T>(this string origin, IEnumerable<T> otherEntries, Func<T, string> getName, bool isCaseInsensitive = true)
	{
		string[] source = otherEntries.Select((T e) => (!isCaseInsensitive) ? getName(e) : getName(e).ToLower()).ToArray();
		int num = 1;
		string text = origin;
		while (source.Contains(isCaseInsensitive ? text.ToLower() : text))
		{
			text = $"{origin} {num}";
			num++;
		}
		return text;
	}

	[IteratorStateMachine(typeof(_003CAllIndicesOf_003Ed__8))]
	public static IEnumerable<int> AllIndicesOf(this string str, string value, StringComparison comparison)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CAllIndicesOf_003Ed__8(-2)
		{
			_003C_003E3__str = str,
			_003C_003E3__value = value,
			_003C_003E3__comparison = comparison
		};
	}

	public static string ToHexString(this byte[] byteArray, bool uppercase = true)
	{
		string format = (uppercase ? "X2" : "x2");
		return string.Join(string.Empty, byteArray.Select((byte b) => b.ToString(format)));
	}

	[IteratorStateMachine(typeof(_003CGetUTF32Indices_003Ed__10))]
	public static IEnumerable<int> GetUTF32Indices(this string value)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetUTF32Indices_003Ed__10(-2)
		{
			_003C_003E3__value = value
		};
	}

	public static string Truncate(this string source, int length)
	{
		if (string.IsNullOrEmpty(source))
		{
			return source;
		}
		return source.Substring(0, Math.Min(source.Length, length));
	}

	public static string TruncateAtNewLine(this string source, int length)
	{
		if (string.IsNullOrEmpty(source))
		{
			return source;
		}
		string text = source.Truncate(length);
		string[] all = LineBreaks.All;
		foreach (string value in all)
		{
			int num = text.IndexOf(value);
			if (num > 0)
			{
				text = text.Substring(0, num);
				return text + "...";
			}
		}
		return text;
	}

	public static string FoldDiacritics(this string source)
	{
		if (string.IsNullOrEmpty(source))
		{
			return source;
		}
		StringBuilder stringBuilder = new StringBuilder();
		(from c in source.Normalize(NormalizationForm.FormD)
			where CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark
			select c).ForEach(delegate(char c)
		{
			stringBuilder.Append(c);
		});
		return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
	}

	public static bool IsValidRegex(this string pattern, out Regex? regex, RegexOptions options = RegexOptions.None)
	{
		regex = null;
		if (string.IsNullOrWhiteSpace(pattern))
		{
			return false;
		}
		try
		{
			regex = new Regex(pattern, options);
		}
		catch (ArgumentException)
		{
			return false;
		}
		return true;
	}

	public static string ToWildCardRegex(this string pattern)
	{
		return Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".");
	}

	[IteratorStateMachine(typeof(_003CToCodepoints_003Ed__16))]
	public static IEnumerable<uint> ToCodepoints(this string text)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToCodepoints_003Ed__16(-2)
		{
			_003C_003E3__text = text
		};
	}

	public static bool IsSubPath(this string lhs, string rhs)
	{
		global::_003C_003Ey__InlineArray2<char> buffer = default(global::_003C_003Ey__InlineArray2<char>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 0) = Path.DirectorySeparatorChar;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 1) = Path.AltDirectorySeparatorChar;
		string[] source = lhs.Split(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<char>, char>(in buffer, 2)).ToArray();
		global::_003C_003Ey__InlineArray2<char> buffer2 = default(global::_003C_003Ey__InlineArray2<char>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer2, 0) = Path.DirectorySeparatorChar;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer2, 1) = Path.AltDirectorySeparatorChar;
		string[] array = rhs.Split(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<char>, char>(in buffer2, 2)).ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			string obj = array[i];
			string text = source.ElementAtOrDefault(i);
			if (obj != text)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsValidEmail(this string email, bool emptyIsValid = false)
	{
		try
		{
			if (emptyIsValid && string.IsNullOrEmpty(email))
			{
				return true;
			}
			new MailAddress(email);
			return email.LastIndexOf(".") > email.LastIndexOf("@");
		}
		catch
		{
			return false;
		}
	}
}
