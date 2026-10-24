using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using Pro.Common.Collections;
using Pro.ssAPI;

namespace ProPresenter.UI;

public class ScaleBehaviorItemsSource : DependencyObject, INotifyEnumerableChanged<ScaleBehavior>, IEnumerable<ScaleBehavior>, IEnumerable, INotifyCollectionChanged
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__14 : IEnumerator<ScaleBehavior>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ScaleBehavior _003C_003E2__current;

		public ScaleBehaviorItemsSource _003C_003E4__this;

		ScaleBehavior IEnumerator<ScaleBehavior>.Current
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
		public _003CGetEnumerator_003Ed__14(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			ScaleBehaviorItemsSource scaleBehaviorItemsSource = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = ScaleBehavior.ScaleToFit;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = ScaleBehavior.ScaleToFill;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = ScaleBehavior.StretchToFill;
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				if (scaleBehaviorItemsSource.SupportsScaleAndBlur)
				{
					_003C_003E2__current = ScaleBehavior.ScaleAndBlur;
					_003C_003E1__state = 4;
					return true;
				}
				goto IL_0099;
			case 4:
				_003C_003E1__state = -1;
				goto IL_0099;
			case 5:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_0099:
				if (scaleBehaviorItemsSource.SupportsCustomScale)
				{
					_003C_003E2__current = ScaleBehavior.CustomFit;
					_003C_003E1__state = 5;
					return true;
				}
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
	}

	public static readonly DependencyProperty SupportsScaleAndBlurProperty = DependencyProperty.Register("SupportsScaleAndBlur", typeof(bool), typeof(ScaleBehaviorItemsSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnSupportsScaleAndBlurPropertyChanged)));

	public static readonly DependencyProperty SupportsCustomScaleProperty = DependencyProperty.Register("SupportsCustomScale", typeof(bool), typeof(ScaleBehaviorItemsSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnSupportsCustomScalePropertyChanged)));

	public bool SupportsScaleAndBlur
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SupportsScaleAndBlurProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SupportsScaleAndBlurProperty, (object)value);
		}
	}

	public bool SupportsCustomScale
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SupportsCustomScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SupportsCustomScaleProperty, (object)value);
		}
	}

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	private static void OnSupportsScaleAndBlurPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ScaleBehaviorItemsSource)?.NotifyCollectionChanged();
	}

	private static void OnSupportsCustomScalePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ScaleBehaviorItemsSource)?.NotifyCollectionChanged();
	}

	private void NotifyCollectionChanged()
	{
		this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__14))]
	public IEnumerator<ScaleBehavior> GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetEnumerator_003Ed__14(0)
		{
			_003C_003E4__this = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
