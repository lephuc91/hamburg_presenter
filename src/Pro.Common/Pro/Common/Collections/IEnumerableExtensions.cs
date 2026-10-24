using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.Common.Operations;

namespace Pro.Common.Collections;

public static class IEnumerableExtensions
{
	private sealed class DistinctEqualityComparer<T, TKey> : IEqualityComparer<T>
	{
		private readonly Func<T, TKey> _keySelector;

		public DistinctEqualityComparer(Func<T, TKey> keySelector)
		{
			_keySelector = keySelector;
		}

		bool IEqualityComparer<T>.Equals(T? lhs, T? rhs)
		{
			lhs.ThrowWhenNull("lhs");
			rhs.ThrowWhenNull("rhs");
			return _keySelector(lhs).Equal(_keySelector(rhs));
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			TKey val = _keySelector(obj);
			if (val == null)
			{
				return 0;
			}
			return val.GetHashCode();
		}
	}

	private sealed class CustomEqualityComparer<T> : IEqualityComparer<T>
	{
		private readonly Func<T?, T?, bool> _comparer;

		private readonly Func<T, int>? _hashCodeGenerator;

		public CustomEqualityComparer(Func<T?, T?, bool> comparer, Func<T, int>? hashCodeGenerator)
		{
			_comparer = comparer;
			_hashCodeGenerator = hashCodeGenerator;
		}

		public bool Equals(T? x, T? y)
		{
			return _comparer(x, y);
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			return _hashCodeGenerator?.Invoke(obj) ?? obj?.GetHashCode() ?? 0;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0<T> where T : notnull
	{
		public T start;

		public Func<T, bool> _003C_003E9__0;

		internal bool _003CRangeBetween_003Eb__0(T i)
		{
			return !i.Equal(start);
		}
	}

	[CompilerGenerated]
	private sealed class _003CContiguousGroups_003Ed__23<T, K> : IEnumerable<K[]>, IEnumerable, IEnumerator<K[]>, IEnumerator, IDisposable where T : notnull where K : notnull
	{
		private int _003C_003E1__state;

		private K[] _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private Func<int, T, K> selector;

		public Func<int, T, K> _003C_003E3__selector;

		private Func<T, T, bool> comparer;

		public Func<T, T, bool> _003C_003E3__comparer;

		private T[] _003CsourceArray_003E5__2;

		private List<K> _003CactiveGroup_003E5__3;

		private int _003Ci_003E5__4;

		K[] IEnumerator<K[]>.Current
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
		public _003CContiguousGroups_003Ed__23(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CsourceArray_003E5__2 = null;
			_003CactiveGroup_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num;
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CsourceArray_003E5__2 = (source as T[]) ?? source.ToArray();
				if (!_003CsourceArray_003E5__2.Any())
				{
					return false;
				}
				num = 0;
				_003CactiveGroup_003E5__3 = new List<K> { selector(0, _003CsourceArray_003E5__2.First()) };
				_003Ci_003E5__4 = 1;
				goto IL_012e;
			case 1:
				_003C_003E1__state = -1;
				num = _003Ci_003E5__4;
				_003CactiveGroup_003E5__3.Clear();
				goto IL_00f1;
			case 2:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_012e:
				if (_003Ci_003E5__4 < _003CsourceArray_003E5__2.Length)
				{
					if (!comparer(_003CsourceArray_003E5__2[num], _003CsourceArray_003E5__2[_003Ci_003E5__4]) && _003CactiveGroup_003E5__3.Any())
					{
						_003C_003E2__current = _003CactiveGroup_003E5__3.ToArray();
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_00f1;
				}
				if (_003CactiveGroup_003E5__3.Any())
				{
					_003C_003E2__current = _003CactiveGroup_003E5__3.ToArray();
					_003C_003E1__state = 2;
					return true;
				}
				break;
				IL_00f1:
				_003CactiveGroup_003E5__3.Add(selector(_003Ci_003E5__4, _003CsourceArray_003E5__2[_003Ci_003E5__4]));
				_003Ci_003E5__4++;
				goto IL_012e;
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
		IEnumerator<K[]> IEnumerable<K[]>.GetEnumerator()
		{
			_003CContiguousGroups_003Ed__23<T, K> _003CContiguousGroups_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CContiguousGroups_003Ed__ = this;
			}
			else
			{
				_003CContiguousGroups_003Ed__ = new _003CContiguousGroups_003Ed__23<T, K>(0);
			}
			_003CContiguousGroups_003Ed__.source = _003C_003E3__source;
			_003CContiguousGroups_003Ed__.comparer = _003C_003E3__comparer;
			_003CContiguousGroups_003Ed__.selector = _003C_003E3__selector;
			return _003CContiguousGroups_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<K[]>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CContiguousGroups_003Ed__24<T> : IEnumerable<T[]>, IEnumerable, IEnumerator<T[]>, IEnumerator, IDisposable where T : notnull
	{
		private int _003C_003E1__state;

		private T[] _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private Predicate<T> predicate;

		public Predicate<T> _003C_003E3__predicate;

		private List<T> _003CactiveGroup_003E5__2;

		private IEnumerator<T> _003C_003E7__wrap2;

		T[] IEnumerator<T[]>.Current
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
		public _003CContiguousGroups_003Ed__24(int _003C_003E1__state)
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
			_003CactiveGroup_003E5__2 = null;
			_003C_003E7__wrap2 = null;
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
					_003C_003E1__state = -1;
					_003CactiveGroup_003E5__2 = new List<T>();
					_003C_003E7__wrap2 = source.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00b1;
				case 1:
					_003C_003E1__state = -3;
					_003CactiveGroup_003E5__2.Clear();
					goto IL_00b1;
				case 2:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_00b1:
					while (_003C_003E7__wrap2.MoveNext())
					{
						T current = _003C_003E7__wrap2.Current;
						if (predicate(current))
						{
							_003CactiveGroup_003E5__2.Add(current);
						}
						else if (_003CactiveGroup_003E5__2.Any())
						{
							_003C_003E2__current = _003CactiveGroup_003E5__2.ToArray();
							_003C_003E1__state = 1;
							return true;
						}
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap2 = null;
					if (_003CactiveGroup_003E5__2.Any())
					{
						_003C_003E2__current = _003CactiveGroup_003E5__2.ToArray();
						_003C_003E1__state = 2;
						return true;
					}
					break;
				}
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
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T[]> IEnumerable<T[]>.GetEnumerator()
		{
			_003CContiguousGroups_003Ed__24<T> _003CContiguousGroups_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CContiguousGroups_003Ed__ = this;
			}
			else
			{
				_003CContiguousGroups_003Ed__ = new _003CContiguousGroups_003Ed__24<T>(0);
			}
			_003CContiguousGroups_003Ed__.source = _003C_003E3__source;
			_003CContiguousGroups_003Ed__.predicate = _003C_003E3__predicate;
			return _003CContiguousGroups_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T[]>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CEnumerate_003Ed__51<T> : IEnumerable<(T, int)>, IEnumerable, IEnumerator<(T, int)>, IEnumerator, IDisposable where T : notnull
	{
		private int _003C_003E1__state;

		private (T, int) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private int _003Cindex_003E5__2;

		private IEnumerator<T> _003C_003E7__wrap2;

		(T, int) IEnumerator<(T, int)>.Current
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
		public _003CEnumerate_003Ed__51(int _003C_003E1__state)
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
			_003C_003E7__wrap2 = null;
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
					_003C_003E1__state = -1;
					_003Cindex_003E5__2 = 0;
					_003C_003E7__wrap2 = source.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					T current = _003C_003E7__wrap2.Current;
					_003C_003E2__current = (current, _003Cindex_003E5__2++);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap2 = null;
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
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<(T, int)> IEnumerable<(T, int)>.GetEnumerator()
		{
			_003CEnumerate_003Ed__51<T> _003CEnumerate_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CEnumerate_003Ed__ = this;
			}
			else
			{
				_003CEnumerate_003Ed__ = new _003CEnumerate_003Ed__51<T>(0);
			}
			_003CEnumerate_003Ed__.source = _003C_003E3__source;
			return _003CEnumerate_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<(T, int)>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CNonNull_003Ed__33<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : class
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T?> source;

		public IEnumerable<T?> _003C_003E3__source;

		private IEnumerator<T?> _003C_003E7__wrap1;

		T IEnumerator<T>.Current
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
		public _003CNonNull_003Ed__33(int _003C_003E1__state)
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
			_003C_003E7__wrap1 = null;
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
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = source.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					T current = _003C_003E7__wrap1.Current;
					if (current != null)
					{
						_003C_003E2__current = current;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			_003CNonNull_003Ed__33<T> _003CNonNull_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CNonNull_003Ed__ = this;
			}
			else
			{
				_003CNonNull_003Ed__ = new _003CNonNull_003Ed__33<T>(0);
			}
			_003CNonNull_003Ed__.source = _003C_003E3__source;
			return _003CNonNull_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CRangeBetween_003Ed__32<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : notnull
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private T start;

		public T _003C_003E3__start;

		private T end;

		public T _003C_003E3__end;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private IEnumerator<T> _003C_003E7__wrap1;

		private T _003Citem_003E5__3;

		T IEnumerator<T>.Current
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
		public _003CRangeBetween_003Ed__32(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003Citem_003E5__3 = default(T);
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			bool result;
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					result = false;
					goto end_IL_0000;
				case 0:
				{
					_003C_003E1__state = -1;
					_003C_003Ec__DisplayClass32_0<T> CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass32_0<T>
					{
						start = start
					};
					if (!CS_0024_003C_003E8__locals4.start.Equal(end))
					{
						if (source.IndexOf(CS_0024_003C_003E8__locals4.start) > source.IndexOf(end))
						{
							source = source.Reverse();
						}
						_003C_003E7__wrap1 = source.SkipWhile((T i) => !i.Equal(CS_0024_003C_003E8__locals4.start)).GetEnumerator();
						_003C_003E1__state = -3;
						break;
					}
					_003C_003E2__current = CS_0024_003C_003E8__locals4.start;
					_003C_003E1__state = 1;
					result = true;
					goto end_IL_0000;
				}
				case 1:
					_003C_003E1__state = -1;
					result = false;
					goto end_IL_0000;
				case 2:
					_003C_003E1__state = -3;
					if (!_003Citem_003E5__3.Equal(end))
					{
						_003Citem_003E5__3 = default(T);
						break;
					}
					result = false;
					_003C_003Em__Finally1();
					goto end_IL_0000;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003Citem_003E5__3 = _003C_003E7__wrap1.Current;
					_003C_003E2__current = _003Citem_003E5__3;
					_003C_003E1__state = 2;
					result = true;
				}
				else
				{
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					result = false;
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
			return result;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			_003CRangeBetween_003Ed__32<T> _003CRangeBetween_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CRangeBetween_003Ed__ = this;
			}
			else
			{
				_003CRangeBetween_003Ed__ = new _003CRangeBetween_003Ed__32<T>(0);
			}
			_003CRangeBetween_003Ed__.source = _003C_003E3__source;
			_003CRangeBetween_003Ed__.start = _003C_003E3__start;
			_003CRangeBetween_003Ed__.end = _003C_003E3__end;
			return _003CRangeBetween_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CSplit_003Ed__25<T> : IEnumerable<T[]>, IEnumerable, IEnumerator<T[]>, IEnumerator, IDisposable where T : notnull
	{
		private int _003C_003E1__state;

		private T[] _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> source;

		public IEnumerable<T> _003C_003E3__source;

		private Predicate<T> delimiter;

		public Predicate<T> _003C_003E3__delimiter;

		private bool includeEmpty;

		public bool _003C_003E3__includeEmpty;

		private List<T> _003CactiveSection_003E5__2;

		private IEnumerator<T> _003C_003E7__wrap2;

		T[] IEnumerator<T[]>.Current
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
		public _003CSplit_003Ed__25(int _003C_003E1__state)
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
			_003CactiveSection_003E5__2 = null;
			_003C_003E7__wrap2 = null;
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
					_003C_003E1__state = -1;
					_003CactiveSection_003E5__2 = new List<T>();
					_003C_003E7__wrap2 = source.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00b9;
				case 1:
					_003C_003E1__state = -3;
					goto IL_00a0;
				case 2:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_00b9:
					while (_003C_003E7__wrap2.MoveNext())
					{
						T current = _003C_003E7__wrap2.Current;
						if (!delimiter(current))
						{
							_003CactiveSection_003E5__2.Add(current);
							continue;
						}
						goto IL_0067;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap2 = null;
					if (includeEmpty || _003CactiveSection_003E5__2.Any())
					{
						_003C_003E2__current = _003CactiveSection_003E5__2.ToArray();
						_003C_003E1__state = 2;
						return true;
					}
					break;
					IL_0067:
					if (includeEmpty || _003CactiveSection_003E5__2.Any())
					{
						_003C_003E2__current = _003CactiveSection_003E5__2.ToArray();
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_00a0;
					IL_00a0:
					_003CactiveSection_003E5__2.Clear();
					goto IL_00b9;
				}
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
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T[]> IEnumerable<T[]>.GetEnumerator()
		{
			_003CSplit_003Ed__25<T> _003CSplit_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSplit_003Ed__ = this;
			}
			else
			{
				_003CSplit_003Ed__ = new _003CSplit_003Ed__25<T>(0);
			}
			_003CSplit_003Ed__.source = _003C_003E3__source;
			_003CSplit_003Ed__.delimiter = _003C_003E3__delimiter;
			_003CSplit_003Ed__.includeEmpty = _003C_003E3__includeEmpty;
			return _003CSplit_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T[]>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CToEnumerable_003Ed__2<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : notnull
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private T item;

		public T _003C_003E3__item;

		T IEnumerator<T>.Current
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
		public _003CToEnumerable_003Ed__2(int _003C_003E1__state)
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
				if (item != null)
				{
					_003C_003E2__current = item;
					_003C_003E1__state = 1;
					return true;
				}
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
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
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			_003CToEnumerable_003Ed__2<T> _003CToEnumerable_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CToEnumerable_003Ed__ = this;
			}
			else
			{
				_003CToEnumerable_003Ed__ = new _003CToEnumerable_003Ed__2<T>(0);
			}
			_003CToEnumerable_003Ed__.item = _003C_003E3__item;
			return _003CToEnumerable_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CToEnumerable_003Ed__2<>))]
	public static IEnumerable<T> ToEnumerable<T>(this T? item)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CToEnumerable_003Ed__2<T>(-2)
		{
			_003C_003E3__item = item
		};
	}

	public static bool Empty<T>(this IEnumerable<T> source)
	{
		return !source.Any();
	}

	public static bool None<T>(this IEnumerable<T> source, Predicate<T> predicate)
	{
		return source.All((T v) => !predicate(v));
	}

	public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
	{
		return source.Except(new global::_003C_003Ez__ReadOnlySingleElementList<T>(item));
	}

	public static IEnumerable<TFirst> Except<TFirst, TSecond, TCompared>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TCompared> firstSelect, Func<TSecond, TCompared> secondSelect)
	{
		return first.Except(second, firstSelect, secondSelect, EqualityComparer<TCompared>.Default);
	}

	public static IEnumerable<TFirst> Except<TFirst, TSecond, TCompared>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TCompared> firstSelect, Func<TSecond, TCompared> secondSelect, IEqualityComparer<TCompared> comparer)
	{
		HashSet<TCompared> set = new HashSet<TCompared>(second.Select(secondSelect), comparer);
		return first.Where((TFirst item) => set.Add(firstSelect(item)));
	}

	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		if (source == null || action == null)
		{
			return;
		}
		using IEnumerator<T> enumerator = source.GetEnumerator();
		if (enumerator != null)
		{
			while (enumerator.MoveNext())
			{
				action(enumerator.Current);
			}
		}
	}

	public static IEnumerable<R> Collect<T, R>(this IEnumerable<T> source, Func<T, R> collector)
	{
		if (source == null || collector == null)
		{
			return Enumerable.Empty<R>();
		}
		List<R> results = new List<R>();
		source.ForEach(delegate(T item)
		{
			results.Add(collector(item));
		});
		return results;
	}

	public static IEnumerable<R> CollectMany<T, R>(this IEnumerable<T> source, Func<T, IEnumerable<R>> collector)
	{
		if (source == null || collector == null)
		{
			return Enumerable.Empty<R>();
		}
		List<R> results = new List<R>();
		source.ForEach(delegate(T item)
		{
			results.AddRange(collector(item));
		});
		return results;
	}

	public static bool ContainsAny<T>(this IEnumerable<T> source, IEnumerable<T> target)
	{
		if (source == null || target == null)
		{
			return false;
		}
		return source.Any((T x) => target.Contains(x));
	}

	public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> target)
	{
		if (source == null || target == null)
		{
			return false;
		}
		return !target.Except(source).Any();
	}

	public static bool ContentsMatch<T>(this IEnumerable<T> source, IEnumerable<T> target)
	{
		if (source.ContainsAll(target))
		{
			return target.ContainsAll(source);
		}
		return false;
	}

	public static bool ContentsMatchExactly<T>(this IEnumerable<T> source, IEnumerable<T> target)
	{
		return source.ContentsMatchExactly(target, (T l, T r) => object.Equals(l, r));
	}

	public static bool ContentsMatchExactly<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equals)
	{
		IEnumerator<T> enumerator = source.GetEnumerator();
		IEnumerator<T> enumerator2 = target.GetEnumerator();
		while (true)
		{
			bool flag = enumerator.MoveNext();
			bool flag2 = enumerator2.MoveNext();
			if (flag != flag2)
			{
				return false;
			}
			if (!flag)
			{
				break;
			}
			T current = enumerator.Current;
			T current2 = enumerator2.Current;
			if (!equals(current, current2))
			{
				return false;
			}
		}
		return true;
	}

	public static int CountMany<T>(this IEnumerable<T> source, Func<T, int> counter)
	{
		if (source == null || counter == null)
		{
			return 0;
		}
		int count = 0;
		source.ForEach(delegate(T x)
		{
			count += counter(x);
		});
		return count;
	}

	public static IEnumerable<IGrouping<T, T>> GroupBy<T>(this IEnumerable<T> source, Func<T?, T?, bool> comparer, Func<T, int>? hashCodeGenerator = null)
	{
		return source.GroupBy((T t) => t, new CustomEqualityComparer<T>(comparer, hashCodeGenerator));
	}

	public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
	{
		return source.Distinct(new DistinctEqualityComparer<T, TKey>(keySelector));
	}

	public static IEnumerable<T> NonDistinct<T>(this IEnumerable<T> source)
	{
		return source.NonDistinct((T g) => g);
	}

	public static IEnumerable<T> NonDistinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
	{
		return (from g in source.GroupBy(keySelector)
			where g.Count() > 1
			select g).SelectMany((IGrouping<TKey, T> r) => r);
	}

	public static IEnumerable<T> CloneItems<T>(this IEnumerable<T> source) where T : ICloneable<T>
	{
		return source.Collect((T i) => i.Clone());
	}

	public static IEnumerable<T[]> ContiguousGroups<T>(this IEnumerable<T> source, Func<T, T, bool> comparer)
	{
		return source.ContiguousGroups(comparer, (int index, T item) => item);
	}

	[IteratorStateMachine(typeof(_003CContiguousGroups_003Ed__23<, >))]
	public static IEnumerable<K[]> ContiguousGroups<T, K>(this IEnumerable<T> source, Func<T, T, bool> comparer, Func<int, T, K> selector)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CContiguousGroups_003Ed__23<T, K>(-2)
		{
			_003C_003E3__source = source,
			_003C_003E3__comparer = comparer,
			_003C_003E3__selector = selector
		};
	}

	[IteratorStateMachine(typeof(_003CContiguousGroups_003Ed__24<>))]
	public static IEnumerable<T[]> ContiguousGroups<T>(this IEnumerable<T> source, Predicate<T> predicate)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CContiguousGroups_003Ed__24<T>(-2)
		{
			_003C_003E3__source = source,
			_003C_003E3__predicate = predicate
		};
	}

	[IteratorStateMachine(typeof(_003CSplit_003Ed__25<>))]
	public static IEnumerable<T[]> Split<T>(this IEnumerable<T> source, Predicate<T> delimiter, bool includeEmpty = true)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSplit_003Ed__25<T>(-2)
		{
			_003C_003E3__source = source,
			_003C_003E3__delimiter = delimiter,
			_003C_003E3__includeEmpty = includeEmpty
		};
	}

	public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
	{
		return source.Take(Math.Max(0, source.Count() - count));
	}

	public static int FindIndex<T>(this IEnumerable<T> source, Predicate<T> predicate, int startingIndex = 0)
	{
		int num = startingIndex;
		foreach (T item in source.Skip(startingIndex))
		{
			if (predicate(item))
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	public static int FindLastIndex<T>(this IEnumerable<T> source, Predicate<T> predicate, int startingIndex)
	{
		int num = startingIndex;
		foreach (T item in source.Reverse().Skip(source.Count() - startingIndex - 1))
		{
			if (predicate(item))
			{
				return num;
			}
			num--;
		}
		return -1;
	}

	public static int IndexOf<T>(this IEnumerable<T> source, T targetItem)
	{
		if (!(source is IList<T> list))
		{
			return source.FindIndex((T i) => i.Equal(targetItem));
		}
		return list.IndexOf(targetItem);
	}

	public static int IndexOf(this IEnumerable source, object item)
	{
		return source.Cast<object>().IndexOf(item);
	}

	public static int LastIndexOf<T>(this IEnumerable<T> source, T targetItem)
	{
		if (!(source is List<T> list))
		{
			return source.FindLastIndex((T i) => i.Equal(targetItem), source.Count() - 1);
		}
		return list.LastIndexOf(targetItem);
	}

	[IteratorStateMachine(typeof(_003CRangeBetween_003Ed__32<>))]
	public static IEnumerable<T> RangeBetween<T>(this IEnumerable<T> source, T start, T end)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRangeBetween_003Ed__32<T>(-2)
		{
			_003C_003E3__source = source,
			_003C_003E3__start = start,
			_003C_003E3__end = end
		};
	}

	[IteratorStateMachine(typeof(_003CNonNull_003Ed__33<>))]
	public static IEnumerable<T> NonNull<T>(this IEnumerable<T?> source) where T : class
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CNonNull_003Ed__33<T>(-2)
		{
			_003C_003E3__source = source
		};
	}

	public static IEnumerable<T> CastNotNull<T>(this IEnumerable<T?> source) where T : class
	{
		return source;
	}

	public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> source) where T : class
	{
		return source.Where((T item) => item != null).CastNotNull();
	}

	public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> source) where T : struct
	{
		return from item in source
			where item.HasValue
			select item.Value;
	}

	public static bool AllAreEqual<T, V>(this IEnumerable<T> source, Func<T, V> selector)
	{
		return source.AllAre(selector, (V lhs, V rhs) => lhs.Equal(rhs));
	}

	public static bool AllAre<T, V>(this IEnumerable<T> source, Func<T, V> selector, Func<V, V, bool> comparer)
	{
		if (source.Any())
		{
			V arg = selector(source.First());
			foreach (T item in source.Skip(1))
			{
				if (!comparer(arg, selector(item)))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool All(this IEnumerable source, Predicate<object> predicate)
	{
		bool result = true;
		foreach (object item in source)
		{
			if (!predicate(item))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public static bool IsAnyOf<T>(this T value, params T[] values)
	{
		return values.Contains(value);
	}

	public static bool AnyOf<T>(this IEnumerable source)
	{
		return source.OfType<T>().Any();
	}

	public static bool AnyOf<T>(this IEnumerable source, Func<T, bool> predicate)
	{
		return source.OfType<T>().Any(predicate);
	}

	public static bool AllOf<T>(this IEnumerable source)
	{
		return source.All((object i) => i is T);
	}

	public static bool AllOf<T>(this IEnumerable source, Func<T, bool> predicate)
	{
		IEnumerable<T> source2 = source.OfType<T>();
		if (source2.Empty())
		{
			return false;
		}
		return source2.All(predicate);
	}

	public static IEnumerable<T> AllOfWhere<T>(this IEnumerable source, Func<T, bool> predicate)
	{
		return source.OfType<T>().Where(predicate);
	}

	public static T FirstOf<T>(this IEnumerable source, Func<T, bool>? predicate = null)
	{
		return source.OfType<T>().First((T i) => predicate?.Invoke(i) ?? true);
	}

	public static T? FirstOrDefaultOf<T>(this IEnumerable source, Func<T, bool>? predicate = null) where T : class
	{
		return source.OfType<T>().FirstOrDefault((T i) => predicate?.Invoke(i) ?? true);
	}

	public static T? FirstOrDefaultBy<T>(this IEnumerable<T> collection, params Predicate<T>[] predicates)
	{
		int val = int.MaxValue;
		T result = default(T);
		foreach (T item in collection)
		{
			for (int i = 0; i < Math.Min(predicates.Length, val); i++)
			{
				if (predicates[i](item))
				{
					if (i == 0)
					{
						return item;
					}
					val = i;
					result = item;
				}
			}
		}
		return result;
	}

	public static T? GetPrevious<T>(this IEnumerable<T> source, T target, Predicate<T>? predicate = null)
	{
		T result = default(T);
		foreach (T item in source)
		{
			if (object.Equals(item, target))
			{
				return result;
			}
			if (predicate == null || predicate(item))
			{
				result = item;
			}
		}
		return default(T);
	}

	public static T? GetNext<T>(this IEnumerable<T> source, T target, Predicate<T>? predicate = null)
	{
		bool flag = false;
		foreach (T item in source)
		{
			if (target == null || (flag && (predicate == null || predicate(item))))
			{
				return item;
			}
			if (object.Equals(item, target))
			{
				flag = true;
			}
		}
		return default(T);
	}

	[IteratorStateMachine(typeof(_003CEnumerate_003Ed__51<>))]
	public static IEnumerable<(T, int)> Enumerate<T>(this IEnumerable<T> source)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CEnumerate_003Ed__51<T>(-2)
		{
			_003C_003E3__source = source
		};
	}

	public static bool AnyAndAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		return source.Select(predicate).DefaultIfEmpty(defaultValue: false).All((bool valid) => valid);
	}

	public static T? FirstMatchOrLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		T result = default(T);
		foreach (T item in source)
		{
			if (predicate(item))
			{
				return item;
			}
			result = item;
		}
		return result;
	}
}
