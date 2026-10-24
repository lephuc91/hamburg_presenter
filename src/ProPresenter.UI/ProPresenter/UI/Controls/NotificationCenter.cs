using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.UI.ViewModels.Notification;
using Reactive.Bindings.Extensions;

namespace ProPresenter.UI.Controls;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_scrollSubscription" })]
public partial class NotificationCenter : UserControl, IComponentConnector, IDisposable
{
	private IDisposable? _scrollSubscription;

	public static readonly DependencyProperty VisibleNotificationsProperty = DependencyProperty.Register("VisibleNotifications", typeof(ObservableCollection<INotificationVM>), typeof(NotificationCenter), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new ObservableCollection<INotificationVM>()));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ObservableCollection<INotificationVM> VisibleNotifications
	{
		get
		{
			return (ObservableCollection<INotificationVM>)((DependencyObject)this).GetValue(VisibleNotificationsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisibleNotificationsProperty, (object)value);
		}
	}

	public NotificationCenter()
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(VisibleNotificationsProperty, (object)new ObservableCollection<INotificationVM>());
		NotificationsPopup.Opened += delegate
		{
			VisibleNotifications.Clear();
			SetVisibleItems();
			SubscribeToScroll();
		};
		NotificationsPopup.Closed += delegate
		{
			UnsubscribeFromScroll();
		};
		base.Unloaded += delegate
		{
			UnsubscribeFromScroll();
		};
	}

	private Rect GetRect(FrameworkElement element)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if (element.Parent is Visual visual)
		{
			GeneralTransform generalTransform = visual.TransformToAncestor(NotificationsScrollViewer);
			Rect layoutSlot = LayoutInformation.GetLayoutSlot(element);
			return new Rect(generalTransform.Transform(((Rect)(ref layoutSlot)).TopLeft), ((Rect)(ref layoutSlot)).Size);
		}
		Rect layoutSlot2 = LayoutInformation.GetLayoutSlot(element);
		return new Rect(((Rect)(ref layoutSlot2)).TopLeft, ((Rect)(ref layoutSlot2)).Size);
	}

	private void SetVisibleItems()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		ItemsControl notificationsList = NotificationsList;
		if (notificationsList == null || notificationsList.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
		{
			return;
		}
		Rect val = default(Rect);
		((Rect)(ref val))._002Ector(NotificationsScrollViewer.HorizontalOffset, NotificationsScrollViewer.VerticalOffset, NotificationsScrollViewer.ViewportWidth, NotificationsScrollViewer.ViewportHeight);
		for (int i = 0; i < NotificationsList.Items.Count; i++)
		{
			if (!(NotificationsList.ItemContainerGenerator.ContainerFromIndex(i) is FrameworkElement element))
			{
				continue;
			}
			Rect rect = GetRect(element);
			if (((Rect)(ref val)).Contains(rect))
			{
				if (NotificationsList.Items[i] is INotificationVM item && !VisibleNotifications.Contains(item))
				{
					VisibleNotifications.Add(item);
				}
			}
			else if (NotificationsList.Items[i] is INotificationVM item2)
			{
				VisibleNotifications.Remove(item2);
			}
		}
	}

	private void SubscribeToScroll()
	{
		UnsubscribeFromScroll();
		_scrollSubscription = Observable.FromEventPattern<ScrollChangedEventHandler, ScrollChangedEventArgs>(delegate(ScrollChangedEventHandler h)
		{
			NotificationsScrollViewer.ScrollChanged += h;
		}, delegate(ScrollChangedEventHandler h)
		{
			NotificationsScrollViewer.ScrollChanged -= h;
		}).Throttle(TimeSpan.FromMilliseconds(500L, 0L)).ObserveOnUIDispatcher()
			.Subscribe(delegate
			{
				SetVisibleItems();
			});
	}

	private void UnsubscribeFromScroll()
	{
		_scrollSubscription?.Dispose();
		_scrollSubscription = null;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_scrollSubscription?.Dispose();
		}
	}
}
