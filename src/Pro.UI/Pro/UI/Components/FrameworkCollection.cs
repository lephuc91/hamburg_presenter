using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;

namespace Pro.UI.Components;

[ContentProperty("Collection")]
public class FrameworkCollection : FrameworkElement, IEnumerable, INotifyCollectionChanged
{
	[CompilerGenerated]
	private sealed class _003CDrill_003Ed__13 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private FrameworkCollection collection;

		public FrameworkCollection _003C_003E3__collection;

		public FrameworkCollection _003C_003E4__this;

		private IEnumerator<object> _003C_003E7__wrap1;

		private IEnumerator _003C_003E7__wrap2;

		object IEnumerator<object>.Current
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
		public _003CDrill_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
			{
				try
				{
					if (num == -4 || num == 1)
					{
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				FrameworkCollection frameworkCollection = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (collection.Collection == null)
					{
						break;
					}
					_003C_003E7__wrap1 = collection.Collection.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00f4;
				case 1:
					_003C_003E1__state = -4;
					goto IL_00be;
				case 2:
					{
						_003C_003E1__state = -3;
						goto IL_00f4;
					}
					IL_00be:
					if (_003C_003E7__wrap2.MoveNext())
					{
						object current = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap2 = null;
					goto IL_00f4;
					IL_00f4:
					if (_003C_003E7__wrap1.MoveNext())
					{
						object current2 = _003C_003E7__wrap1.Current;
						if (current2 is FrameworkCollection frameworkCollection2)
						{
							_003C_003E7__wrap2 = frameworkCollection.Drill(frameworkCollection2).GetEnumerator();
							_003C_003E1__state = -4;
							goto IL_00be;
						}
						_003C_003E2__current = current2;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap2 is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			_003CDrill_003Ed__13 _003CDrill_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CDrill_003Ed__ = this;
			}
			else
			{
				_003CDrill_003Ed__ = new _003CDrill_003Ed__13(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CDrill_003Ed__.collection = _003C_003E3__collection;
			return _003CDrill_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FrameworkCollection _003C_003E4__this;

		private IEnumerator<object> _003C_003E7__wrap1;

		private IEnumerator _003C_003E7__wrap2;

		object IEnumerator<object>.Current
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
		public _003CGetEnumerator_003Ed__9(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
			{
				try
				{
					if (num == -4 || num == 1)
					{
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				FrameworkCollection frameworkCollection = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (frameworkCollection.Collection == null)
					{
						break;
					}
					_003C_003E7__wrap1 = frameworkCollection.Collection.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00ea;
				case 1:
					_003C_003E1__state = -4;
					goto IL_00b4;
				case 2:
					{
						_003C_003E1__state = -3;
						goto IL_00ea;
					}
					IL_00b4:
					if (_003C_003E7__wrap2.MoveNext())
					{
						object current = _003C_003E7__wrap2.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap2 = null;
					goto IL_00ea;
					IL_00ea:
					if (_003C_003E7__wrap1.MoveNext())
					{
						object current2 = _003C_003E7__wrap1.Current;
						if (current2 is FrameworkCollection collection)
						{
							_003C_003E7__wrap2 = frameworkCollection.Drill(collection).GetEnumerator();
							_003C_003E1__state = -4;
							goto IL_00b4;
						}
						_003C_003E2__current = current2;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
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
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap2 is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static readonly DependencyProperty CollectionProperty = DependencyProperty.Register("Collection", typeof(Collection<object>), typeof(FrameworkCollection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCollectionPropertyChanged)));

	public Collection<object>? Collection
	{
		get
		{
			return (Collection<object>)((DependencyObject)this).GetValue(CollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollectionProperty, (object)value);
		}
	}

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	private static void OnCollectionPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		(callerObject as FrameworkCollection)?.NotifyCollectionChanged();
	}

	public FrameworkCollection()
	{
		ObservableCollection<object> observableCollection = new ObservableCollection<object>();
		observableCollection.CollectionChanged += OnCollectionChanged;
		Collection = observableCollection;
	}

	[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__9))]
	public IEnumerator GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__9(0)
		{
			_003C_003E4__this = this
		};
	}

	protected void NotifyCollectionChanged()
	{
		this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	private void SubitemCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		NotifyCollectionChanged();
	}

	private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null)
		{
			foreach (object oldItem in e.OldItems)
			{
				if (oldItem is FrameworkCollection frameworkCollection)
				{
					frameworkCollection.CollectionChanged -= SubitemCollectionChanged;
				}
			}
		}
		if (e.NewItems != null)
		{
			foreach (object newItem in e.NewItems)
			{
				if (newItem is FrameworkCollection frameworkCollection2)
				{
					frameworkCollection2.CollectionChanged += SubitemCollectionChanged;
					AddVisualChild(frameworkCollection2);
				}
			}
		}
		NotifyCollectionChanged();
	}

	[IteratorStateMachine(typeof(_003CDrill_003Ed__13))]
	private IEnumerable Drill(FrameworkCollection collection)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDrill_003Ed__13(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__collection = collection
		};
	}
}
