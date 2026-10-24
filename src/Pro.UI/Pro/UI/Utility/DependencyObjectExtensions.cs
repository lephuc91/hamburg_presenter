using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Mathematics;

namespace Pro.UI.Utility;

public static class DependencyObjectExtensions
{
	[CompilerGenerated]
	private sealed class _003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed : IEnumerable<DependencyObject>, IEnumerable, IEnumerator<DependencyObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private DependencyObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private DependencyObject o;

		public DependencyObject _003C_003E3__o;

		private int _003CchildrenCount_003E5__2;

		private int _003Ci_003E5__3;

		DependencyObject IEnumerator<DependencyObject>.Current
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
		public _003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed(int _003C_003E1__state)
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
				_003CchildrenCount_003E5__2 = VisualTreeHelper.GetChildrenCount(o);
				_003Ci_003E5__3 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__3++;
				break;
			}
			if (_003Ci_003E5__3 < _003CchildrenCount_003E5__2)
			{
				_003C_003E2__current = VisualTreeHelper.GetChild(o, _003Ci_003E5__3);
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
		IEnumerator<DependencyObject> IEnumerable<DependencyObject>.GetEnumerator()
		{
			_003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed _003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed = this;
			}
			else
			{
				_003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed = new _003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed(0);
			}
			_003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed.o = _003C_003E3__o;
			return _003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<DependencyObject>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public DependencyObject depObj;

		internal bool _003CFindAllParents_003Eb__0(Type t)
		{
			return ((object)depObj).GetType().IsSubclassOf(t);
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindAllParents_003Ed__17 : IEnumerable<DependencyObject>, IEnumerable, IEnumerator<DependencyObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private DependencyObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private DependencyObject depObj;

		public DependencyObject _003C_003E3__depObj;

		private Type[] types;

		public Type[] _003C_003E3__types;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

		private Predicate<DependencyObject> predicate;

		public Predicate<DependencyObject> _003C_003E3__predicate;

		private Func<DependencyObject, DependencyObject> getParent;

		public Func<DependencyObject, DependencyObject> _003C_003E3__getParent;

		DependencyObject IEnumerator<DependencyObject>.Current
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
		public _003CFindAllParents_003Ed__17(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E8__1 = null;
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
				goto IL_00a0;
			}
			_003C_003E1__state = -1;
			_003C_003E8__1 = new _003C_003Ec__DisplayClass17_0();
			_003C_003E8__1.depObj = depObj;
			goto IL_00dc;
			IL_00a0:
			_003C_003E8__1.depObj = (predicate(_003C_003E8__1.depObj) ? getParent(_003C_003E8__1.depObj) : null);
			goto IL_00dc;
			IL_00dc:
			if (_003C_003E8__1.depObj != null)
			{
				if (types.Length == 0 || types.Contains(((object)_003C_003E8__1.depObj).GetType()) || types.Any((Type t) => ((object)_003C_003E8__1.depObj).GetType().IsSubclassOf(t)))
				{
					_003C_003E2__current = _003C_003E8__1.depObj;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00a0;
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
		IEnumerator<DependencyObject> IEnumerable<DependencyObject>.GetEnumerator()
		{
			_003CFindAllParents_003Ed__17 _003CFindAllParents_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindAllParents_003Ed__ = this;
			}
			else
			{
				_003CFindAllParents_003Ed__ = new _003CFindAllParents_003Ed__17(0);
			}
			_003CFindAllParents_003Ed__.depObj = _003C_003E3__depObj;
			_003CFindAllParents_003Ed__.predicate = _003C_003E3__predicate;
			_003CFindAllParents_003Ed__.getParent = _003C_003E3__getParent;
			_003CFindAllParents_003Ed__.types = _003C_003E3__types;
			return _003CFindAllParents_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<DependencyObject>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindChildren_003Ed__6<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : notnull, DependencyObject
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Predicate<DependencyObject> predicate;

		public Predicate<DependencyObject> _003C_003E3__predicate;

		private DependencyObject depObj;

		public DependencyObject _003C_003E3__depObj;

		private Func<DependencyObject, IEnumerable<DependencyObject>> getChildren;

		public Func<DependencyObject, IEnumerable<DependencyObject>> _003C_003E3__getChildren;

		private IEnumerator<DependencyObject> _003C_003E7__wrap1;

		private DependencyObject _003Cchild_003E5__3;

		private IEnumerator<T> _003C_003E7__wrap3;

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
		public _003CFindChildren_003Ed__6(int _003C_003E1__state)
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
					if (num == -4 || num == 2)
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
			_003Cchild_003E5__3 = null;
			_003C_003E7__wrap3 = null;
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
					if (!predicate(depObj))
					{
						break;
					}
					_003C_003E7__wrap1 = getChildren(depObj).GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_011e;
				case 1:
					_003C_003E1__state = -3;
					goto IL_00ab;
				case 2:
					{
						_003C_003E1__state = -4;
						goto IL_00fd;
					}
					IL_011e:
					if (_003C_003E7__wrap1.MoveNext())
					{
						_003Cchild_003E5__3 = _003C_003E7__wrap1.Current;
						if (_003Cchild_003E5__3 is T)
						{
							_003C_003E2__current = (T)(object)_003Cchild_003E5__3;
							_003C_003E1__state = 1;
							return true;
						}
						goto IL_00ab;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					break;
					IL_00ab:
					_003C_003E7__wrap3 = _003Cchild_003E5__3.FindChildren<T>(predicate, getChildren).GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_00fd;
					IL_00fd:
					if (_003C_003E7__wrap3.MoveNext())
					{
						T current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					_003Cchild_003E5__3 = null;
					goto IL_011e;
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
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
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
			_003CFindChildren_003Ed__6<T> _003CFindChildren_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindChildren_003Ed__ = this;
			}
			else
			{
				_003CFindChildren_003Ed__ = new _003CFindChildren_003Ed__6<T>(0);
			}
			_003CFindChildren_003Ed__.depObj = _003C_003E3__depObj;
			_003CFindChildren_003Ed__.predicate = _003C_003E3__predicate;
			_003CFindChildren_003Ed__.getChildren = _003C_003E3__getChildren;
			return _003CFindChildren_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	private static bool IsVisual(DependencyObject depObj)
	{
		if (!(depObj is Visual))
		{
			return depObj is Visual3D;
		}
		return true;
	}

	private static bool IsLogical(DependencyObject depObj)
	{
		return depObj is FrameworkElement;
	}

	private static IEnumerable<DependencyObject> GetVisualChildren(DependencyObject depObj)
	{
		return from i in Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(depObj))
			select VisualTreeHelper.GetChild(depObj, i);
	}

	private static IEnumerable<DependencyObject> GetLogicalChildren(DependencyObject depObj)
	{
		return LogicalTreeHelper.GetChildren(depObj).Cast<DependencyObject>();
	}

	public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
	{
		return depObj.FindChildren<T>(IsVisual, GetVisualChildren);
	}

	public static IEnumerable<T> FindLogicalChildren<T>(this DependencyObject depObj) where T : DependencyObject
	{
		return depObj.FindChildren<T>(IsLogical, GetLogicalChildren);
	}

	[IteratorStateMachine(typeof(_003CFindChildren_003Ed__6<>))]
	public static IEnumerable<T> FindChildren<T>(this DependencyObject depObj, Predicate<DependencyObject> predicate, Func<DependencyObject, IEnumerable<DependencyObject>> getChildren) where T : DependencyObject
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindChildren_003Ed__6<T>(-2)
		{
			_003C_003E3__depObj = depObj,
			_003C_003E3__predicate = predicate,
			_003C_003E3__getChildren = getChildren
		};
	}

	public static T? FindVisualChild<T>(this DependencyObject depObj, Predicate<T>? filter = null) where T : DependencyObject
	{
		return depObj.FindChild(IsVisual, GetVisualChildren, filter);
	}

	public static T? FindLogicalChild<T>(this DependencyObject depObj, Predicate<T>? filter = null) where T : DependencyObject
	{
		return depObj.FindChild(IsLogical, GetLogicalChildren, filter);
	}

	public static T? FindChild<T>(this DependencyObject depObj, Predicate<DependencyObject> predicate, Func<DependencyObject, IEnumerable<DependencyObject>> getChildren, Predicate<T>? filter = null) where T : DependencyObject
	{
		return depObj.FindChildren<T>(predicate, getChildren).FirstOrDefault((T i) => filter?.Invoke(i) ?? true);
	}

	public static IEnumerable<FrameworkElement> FindChildrenByNames(this DependencyObject depObj, params string[] names)
	{
		return from frameworkElement in depObj.FindChildren<FrameworkElement>((DependencyObject _) => true, getChildren)
			where names.Contains(frameworkElement.Name)
			select frameworkElement;
		[IteratorStateMachine(typeof(_003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed))]
		static IEnumerable<DependencyObject> getChildren(DependencyObject o)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003CFindChildrenByNames_003Eg__getChildren_007C10_2_003Ed(-2)
			{
				_003C_003E3__o = o
			};
		}
	}

	public static FrameworkElement? FindChildByName(this DependencyObject depObj, string name)
	{
		return depObj.FindChildrenByNames(name).FirstOrDefault();
	}

	public static T? FindVisualParent<T>(this DependencyObject depObj, bool includeSelf = true) where T : DependencyObject
	{
		return depObj.FindParent<T>(IsVisual, VisualTreeHelper.GetParent, includeSelf);
	}

	public static T? FindLogicalParent<T>(this DependencyObject depObj, bool includeSelf = true) where T : DependencyObject
	{
		return depObj.FindParent<T>(IsLogical, LogicalTreeHelper.GetParent, includeSelf);
	}

	public static T? FindParent<T>(this DependencyObject depObj, Predicate<DependencyObject> predicate, Func<DependencyObject, DependencyObject> getParent, bool includeSelf = true) where T : DependencyObject
	{
		if (!predicate(depObj))
		{
			return default(T);
		}
		if ((!(depObj is T) && !((object)depObj).GetType().IsSubclassOf(typeof(T))) || !includeSelf)
		{
			depObj = getParent(depObj);
		}
		if (!(depObj is T))
		{
			if (depObj == null)
			{
				return default(T);
			}
			return depObj.FindParent<T>(predicate, getParent);
		}
		return (T)(object)depObj;
	}

	public static IEnumerable<DependencyObject> FindAllVisualParents(this DependencyObject depObj, params Type[] types)
	{
		return depObj.FindAllParents(IsVisual, VisualTreeHelper.GetParent, types);
	}

	public static IEnumerable<DependencyObject> FindAllLogicalParents(this DependencyObject depObj, params Type[] types)
	{
		return depObj.FindAllParents(IsLogical, LogicalTreeHelper.GetParent, types);
	}

	[IteratorStateMachine(typeof(_003CFindAllParents_003Ed__17))]
	public static IEnumerable<DependencyObject> FindAllParents(this DependencyObject? depObj, Predicate<DependencyObject> predicate, Func<DependencyObject, DependencyObject> getParent, params Type[] types)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindAllParents_003Ed__17(-2)
		{
			_003C_003E3__depObj = depObj,
			_003C_003E3__predicate = predicate,
			_003C_003E3__getParent = getParent,
			_003C_003E3__types = types
		};
	}

	public static T? FindHitElement<T>(this MouseEventArgs e, UIElement visual) where T : DependencyObject
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		HitTestResult hitTestResult = VisualTreeHelper.HitTest(visual, e.GetPosition(visual));
		if (hitTestResult == null)
		{
			return default(T);
		}
		DependencyObject visualHit = hitTestResult.VisualHit;
		if (visualHit == null)
		{
			return default(T);
		}
		return visualHit.FindVisualParent<T>();
	}

	public static T? FindHitElement<T>(this DragEventArgs e, UIElement visual) where T : DependencyObject
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		HitTestResult hitTestResult = VisualTreeHelper.HitTest(visual, e.GetPosition(visual));
		if (hitTestResult == null)
		{
			return default(T);
		}
		DependencyObject visualHit = hitTestResult.VisualHit;
		if (visualHit == null)
		{
			return default(T);
		}
		return visualHit.FindVisualParent<T>();
	}

	public static void ResetDropIndicator(this DependencyObject depObj)
	{
		depObj.FindVisualChildren<UIElement>().ForEach(remove);
		remove(depObj as UIElement);
		static void remove(UIElement? t)
		{
			if (t != null)
			{
				AdornerLayer adornerLayer = t.GetAdornerLayer();
				adornerLayer?.GetAdorners(t)?.ForEach(delegate(Adorner a)
				{
					adornerLayer.Remove(a);
				});
			}
		}
	}

	public static void ShowDropIndicator(this FrameworkElement depObj, AdornerPosition position, double offset = 0.0)
	{
		depObj.AddAdorner(new DropIndicator(depObj, position, offset));
	}

	public static void ShowDropIndicator(this FrameworkElement depObj, AdornerPosition position, Color color, double thickness, double offset = 0.0)
	{
		depObj.AddAdorner(new DropIndicator(depObj, position, color, thickness, offset));
	}

	public static void ShowCaretIndicator(this UIElement depObj, double caretWidth, double caretHeight, Vector2<double> caretPosition, Color caretColor)
	{
		depObj.AddAdorner(new CaretIndicator(depObj, caretWidth, caretHeight, caretPosition, caretColor));
	}

	public static CaretIndicator? GetCaretIndicator(this UIElement depObj)
	{
		return depObj.GetAdornerLayer()?.GetAdorners(depObj)?.OfType<CaretIndicator>().FirstOrDefault();
	}

	public static void ResetIndicator(this UIElement depObj, Predicate<Adorner>? filter = null)
	{
		AdornerLayer adornerLayer = depObj.GetAdornerLayer();
		adornerLayer?.GetAdorners(depObj)?.Where((Adorner a) => filter?.Invoke(a) ?? true).ForEach(delegate(Adorner a)
		{
			adornerLayer?.Remove(a);
		});
	}

	public static void ResetSelectionIndicator(this UIElement depObj)
	{
		depObj.ResetIndicator((Adorner a) => !(a is SpellErrorIndicator));
	}

	public static void ResetSpellErrorIndicator(this UIElement depObj)
	{
		depObj.ResetIndicator((Adorner a) => a is SpellErrorIndicator);
	}

	public static void ShowTextSelectionIndicator(this UIElement depObj, IEnumerable<Rect<double>> rects)
	{
		if (depObj == null)
		{
			Log.Warning("This should not be called with a null depObj");
			return;
		}
		try
		{
			depObj.AddAdorner(new TextSelectionIndicator(depObj, rects));
		}
		catch (Exception exception)
		{
			Log.Warning(exception);
		}
	}

	public static void ShowSpellError(this UIElement depObj, IEnumerable<Rect<double>> wordRects)
	{
		depObj.AddAdorner(new SpellErrorIndicator(depObj, wordRects.Select((Rect<double> r) => r.BottomEdge)));
	}

	public static Binding? Bind(this DependencyObject? source, DependencyProperty targetProperty, object bindingSource, string sourceProperty, BindingMode mode = BindingMode.Default, string? stringFormat = null, bool validatesOnNotifyDataError = true, int delay = 0)
	{
		if (source == null)
		{
			return null;
		}
		Binding binding = new Binding(sourceProperty)
		{
			Source = bindingSource,
			Mode = mode,
			StringFormat = stringFormat,
			ValidatesOnNotifyDataErrors = validatesOnNotifyDataError,
			Delay = delay
		};
		BindingOperations.SetBinding(source, targetProperty, binding);
		return binding;
	}

	public static Binding? Bind(this DependencyObject? source, DependencyProperty targetProperty, object bindingSource, string sourceProperty, IValueConverter converter, object? converterParameter = null, BindingMode mode = BindingMode.Default, string? stringFormat = null, bool validatesOnNotifyDataError = true, int delay = 0)
	{
		if (source == null)
		{
			return null;
		}
		Binding binding = new Binding(sourceProperty)
		{
			Source = bindingSource,
			Mode = mode,
			StringFormat = stringFormat,
			Converter = converter,
			ConverterParameter = converterParameter,
			ValidatesOnNotifyDataErrors = validatesOnNotifyDataError,
			Delay = delay
		};
		BindingOperations.SetBinding(source, targetProperty, binding);
		return binding;
	}
}
