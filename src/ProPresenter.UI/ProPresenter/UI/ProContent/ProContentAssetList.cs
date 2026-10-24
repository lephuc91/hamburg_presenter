using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Mathematics;
using Pro.UI.Utility;
using ProPresenter.UI.Utility;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ProContent;

public class ProContentAssetList : ItemsControl
{
	[CompilerGenerated]
	private sealed class _003CGetAllViews_003Ed__55 : IEnumerable<ProContentAssetView>, IEnumerable, IEnumerator<ProContentAssetView>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ProContentAssetView _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ProContentAssetList _003C_003E4__this;

		private IEnumerator _003C_003E7__wrap1;

		ProContentAssetView IEnumerator<ProContentAssetView>.Current
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
		public _003CGetAllViews_003Ed__55(int _003C_003E1__state)
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
				int num = _003C_003E1__state;
				ProContentAssetList proContentAssetList = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = ((IEnumerable)proContentAssetList.Items).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					object current = _003C_003E7__wrap1.Current;
					if (proContentAssetList.ItemContainerGenerator.ContainerFromItem(current) is ProContentAssetView proContentAssetView)
					{
						_003C_003E2__current = proContentAssetView;
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
			if (_003C_003E7__wrap1 is IDisposable disposable)
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
		IEnumerator<ProContentAssetView> IEnumerable<ProContentAssetView>.GetEnumerator()
		{
			_003CGetAllViews_003Ed__55 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetAllViews_003Ed__55(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ProContentAssetView>)this).GetEnumerator();
		}
	}

	private const string SCROLLVIEWER = "PART_ScrollViewer";

	public static readonly Thickness THUMBNAIL_MARGIN = new Thickness(10.0, 10.0, 10.0, 5.0);

	public static readonly DependencyProperty CanScrollBackProperty = DependencyProperty.Register("CanScrollBack", typeof(bool), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty CanScrollForwardProperty = DependencyProperty.Register("CanScrollForward", typeof(bool), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty EnableAnimateScrollProperty = DependencyProperty.Register("EnableAnimateScroll", typeof(bool), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	private static readonly DependencyProperty ScrollViewerProperty = DependencyProperty.Register("ScrollViewer", typeof(ScrollViewer), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(ScrollViewerPropertyChanged)));

	private static readonly DependencyProperty HorizontalScrollOffsetProperty = DependencyProperty.Register("HorizontalScrollOffset", typeof(double), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, new PropertyChangedCallback(HorizontalScrollOffsetPropertyChanged)));

	public static readonly DependencyProperty SelectAssetCommandProperty = DependencyProperty.Register("SelectAssetCommand", typeof(IAsyncRelayCommand<IProContentAssetVM>), typeof(ProContentAssetList));

	public static readonly DependencyProperty ContentLayoutTypeProperty = DependencyProperty.Register("ContentLayoutType", typeof(LayoutType), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)LayoutType.CarouselSmall));

	public static readonly DependencyProperty AssetViewDataProperty = DependencyProperty.Register("AssetViewData", typeof(ProContentAssetViewData), typeof(ProContentAssetList), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(AssetViewDataPropertyChanged)));

	public bool CanScrollBack
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanScrollBackProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanScrollBackProperty, (object)value);
		}
	}

	public bool CanScrollForward
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanScrollForwardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanScrollForwardProperty, (object)value);
		}
	}

	public bool EnableAnimateScroll
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnableAnimateScrollProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnableAnimateScrollProperty, (object)value);
		}
	}

	private ScrollViewer? ScrollViewer
	{
		get
		{
			return (ScrollViewer)((DependencyObject)this).GetValue(ScrollViewerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollViewerProperty, (object)value);
		}
	}

	private double HorizontalScrollOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HorizontalScrollOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HorizontalScrollOffsetProperty, (object)value);
		}
	}

	public IAsyncRelayCommand<IProContentAssetVM>? SelectAssetCommand
	{
		get
		{
			return (IAsyncRelayCommand<IProContentAssetVM>)((DependencyObject)this).GetValue(SelectAssetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAssetCommandProperty, (object)value);
		}
	}

	public LayoutType ContentLayoutType
	{
		get
		{
			return (LayoutType)((DependencyObject)this).GetValue(ContentLayoutTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentLayoutTypeProperty, (object)value);
		}
	}

	public ProContentAssetViewData? AssetViewData
	{
		get
		{
			return (ProContentAssetViewData)((DependencyObject)this).GetValue(AssetViewDataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssetViewDataProperty, (object)value);
		}
	}

	private static void ScrollViewerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentAssetList @object)
		{
			if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is ScrollViewer scrollViewer)
			{
				scrollViewer.ScrollChanged -= @object.ScrollViewer_ScrollChanged;
			}
			if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is ScrollViewer scrollViewer2)
			{
				scrollViewer2.ScrollChanged += @object.ScrollViewer_ScrollChanged;
			}
		}
	}

	private static void HorizontalScrollOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentAssetList proContentAssetList)
		{
			proContentAssetList.ScrollViewer?.ScrollToHorizontalOffset((double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void AssetViewDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentAssetList proContentAssetList)
		{
			proContentAssetList.OnAssetViewDataChanged((ProContentAssetViewData)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	public ProContentAssetList()
	{
		base.Loaded += ProContentAssetList_Loaded;
		new DragItemWrapper<ProContentAssetView, IProContentAssetVM>(this).EnableDragging();
	}

	private void ProContentAssetList_Loaded(object? sender, RoutedEventArgs e)
	{
		base.Loaded -= ProContentAssetList_Loaded;
		ScrollViewer?.UpdateLayout();
		ScrollViewer?.ScrollToHorizontalOffset(0.0);
	}

	public override void OnApplyTemplate()
	{
		if (GetTemplateChild("PART_ScrollViewer") is ScrollViewer scrollViewer)
		{
			((DependencyObject)this).SetCurrentValue(ScrollViewerProperty, (object)scrollViewer);
		}
		base.OnApplyTemplate();
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		ProContentAssetView proContentAssetView = new ProContentAssetView();
		proContentAssetView.SetBinding(ProContentAssetView.ContentViewTypeProperty, new Binding("ContentLayoutType")
		{
			Source = this
		});
		proContentAssetView.SetPreviewSize(AssetViewData?.PreviewSize ?? Vector2<double>.Zero);
		return (DependencyObject)(object)proContentAssetView;
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		if (element is ProContentAssetView proContentAssetView)
		{
			proContentAssetView.DataContext = item;
		}
		base.PrepareContainerForItemOverride(element, item);
	}

	private void ScrollViewer_ScrollChanged(object? sender, ScrollChangedEventArgs e)
	{
		if (!base.IsLoaded && e.HorizontalOffset > 0.0 && sender is ScrollViewer scrollViewer)
		{
			scrollViewer.ScrollToHorizontalOffset(0.0);
		}
		InvalidateArrange();
	}

	protected override Size ArrangeOverride(Size arrangeBounds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		Rect<double> viewPort = new Rect<double>(Vector2<double>.Zero, (Vector2<double>)arrangeBounds);
		UpdateCanScrollBack(viewPort);
		UpdateCanScrollForward(viewPort);
		return base.ArrangeOverride(arrangeBounds);
	}

	private void UpdateCanScrollBack(Rect<double> viewPort)
	{
		bool flag = base.Items.Count > 0 && GetCanScroll(base.Items[0], viewPort);
		((DependencyObject)this).SetCurrentValue(CanScrollBackProperty, (object)flag);
	}

	private void UpdateCanScrollForward(Rect<double> viewPort)
	{
		bool flag = base.Items.Count > 0 && GetCanScroll(base.Items[base.Items.Count - 1], viewPort);
		((DependencyObject)this).SetCurrentValue(CanScrollForwardProperty, (object)flag);
	}

	private bool GetCanScroll(object item, Rect<double> viewPort)
	{
		if (base.Items.Count == 0)
		{
			return false;
		}
		if (base.ItemContainerGenerator.ContainerFromItem(item) is ProContentAssetView view)
		{
			Rect<double> viewBounds = GetViewBounds(view);
			return !GetViewIsVisible(view, viewPort) || !viewPort.Contains(viewBounds);
		}
		return true;
	}

	private bool GetViewIsVisible(ProContentAssetView view, Rect<double> viewPort)
	{
		if (view != null)
		{
			Rect<double> viewBounds = GetViewBounds(view);
			return viewPort.Intersects(viewBounds);
		}
		return false;
	}

	private Rect<double> GetViewBounds(ProContentAssetView view)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Grid previewGrid = view.PreviewGrid;
		return new Rect<double>((Vector2<double>)previewGrid.TranslatePoint(Vector2<double>.Zero, this), (Vector2<double>)previewGrid.DesiredSize);
	}

	private void OnAssetViewDataChanged(ProContentAssetViewData assetViewData)
	{
		foreach (ProContentAssetView allView in GetAllViews())
		{
			allView.SetPreviewSize(assetViewData?.PreviewSize ?? Vector2<double>.Zero);
		}
	}

	internal void ScrollBackward()
	{
		Rect<double> viewPort = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(base.ActualWidth, base.ActualHeight));
		ProContentAssetView lastInView = GetAllViews().ToArray().FirstOrDefault((ProContentAssetView v) => GetViewIsVisible(v, viewPort));
		int num = AssetViewData?.ColumnCount ?? 0;
		Scroll(lastInView, THUMBNAIL_MARGIN.Left, num - 1);
	}

	internal void ScrollForward()
	{
		Rect<double> viewPort = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(base.ActualWidth, base.ActualHeight));
		ProContentAssetView lastInView = GetAllViews().ToArray().LastOrDefault((ProContentAssetView v) => GetViewIsVisible(v, viewPort));
		Scroll(lastInView, THUMBNAIL_MARGIN.Right);
	}

	private void Scroll(ProContentAssetView? lastInView, double offset, int scrollCount = 0)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		if (lastInView != null)
		{
			int num = base.Items.IndexOf(lastInView.DataContext);
			object itemAt = base.Items.GetItemAt(Math.Max(0, num - scrollCount));
			double horizontalOffset;
			if (!(base.ItemContainerGenerator.ContainerFromItem(itemAt) is ProContentAssetView proContentAssetView))
			{
				Rect<double> viewBounds = GetViewBounds(lastInView);
				double actualWidth = lastInView.ActualWidth;
				horizontalOffset = viewBounds.Position.X - (actualWidth * (double)scrollCount + offset);
			}
			else
			{
				horizontalOffset = ((Vector2<double>)proContentAssetView.TranslatePoint(Vector2<double>.Zero, this)).X;
			}
			BringIntoView(horizontalOffset);
		}
	}

	private void BringIntoView(double horizontalOffset)
	{
		if (EnableAnimateScroll)
		{
			AnimateScrolling(horizontalOffset);
		}
		else
		{
			ScrollViewer?.ScrollToHorizontalOffset(horizontalOffset);
		}
	}

	private void AnimateScrolling(double horizontalOffset)
	{
		if (ScrollViewer != null)
		{
			horizontalOffset = ScrollViewer.HorizontalOffset + horizontalOffset;
			horizontalOffset = horizontalOffset.Clamp(0.0, ScrollViewer.ScrollableWidth);
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				EasingFunction = new CircleEase
				{
					EasingMode = EasingMode.EaseOut
				},
				From = ScrollViewer.HorizontalOffset,
				To = horizontalOffset,
				Duration = new Duration(TimeSpan.FromSeconds(1.0))
			};
			Storyboard obj = new Storyboard
			{
				Children = { (Timeline)doubleAnimation }
			};
			Storyboard.SetTargetProperty((DependencyObject)(object)doubleAnimation, new PropertyPath(HorizontalScrollOffsetProperty));
			Storyboard.SetTarget((DependencyObject)(object)doubleAnimation, (DependencyObject)(object)this);
			obj.Begin();
		}
	}

	[IteratorStateMachine(typeof(_003CGetAllViews_003Ed__55))]
	private IEnumerable<ProContentAssetView> GetAllViews()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetAllViews_003Ed__55(-2)
		{
			_003C_003E4__this = this
		};
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (e.FindHitElement<Button>(this) == null)
		{
			ProContentAssetView? proContentAssetView = e.FindHitElement<ProContentAssetView>(this);
			IProContentAssetVM proContentAssetVM = proContentAssetView?.DataContext as IProContentAssetVM;
			if (proContentAssetView != null && proContentAssetVM != null)
			{
				SelectAssetCommand?.Invoke(proContentAssetVM);
			}
		}
		base.OnPreviewMouseLeftButtonUp(e);
	}
}
