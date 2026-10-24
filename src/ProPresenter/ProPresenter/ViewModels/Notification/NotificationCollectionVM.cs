using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.HTTP;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using ProPresenter.DO.Notifications;
using ProPresenter.UI.ViewModels.Notification;

namespace ProPresenter.ViewModels.Notification;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class NotificationCollectionVM : ObservableObject, INotificationCollectionVM, INotifyPropertyChanged, IDisposable
{
	private readonly INotificationService _notificationService;

	private readonly IPeriodicTimer _visibleTimer;

	private readonly Lock _timerLock = new Lock();

	[ObservableProperty]
	private bool _isPopUpOpen;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? markAllAsReadCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool AnyNotifications => Notifications.Any();

	public bool UnreadNotifications => Notifications.Any((INotificationVM n) => !n.IsRead);

	public ObservableCollection<INotificationVM> VisibleNotifications { get; }

	public INotifyEnumerableChanged<INotificationVM> Notifications { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPopUpOpen
	{
		get
		{
			return _isPopUpOpen;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPopUpOpen, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsPopUpOpen);
				_isPopUpOpen = value;
				OnIsPopUpOpenChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsPopUpOpen);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand MarkAllAsReadCommand => markAllAsReadCommand ?? (markAllAsReadCommand = new RelayCommand(MarkAllAsRead));

	public NotificationCollectionVM(INotificationService notificationService, IHyperlinkService hyperlinkService, INotificationVMFactory factory, ITimerFactory timerFactory)
	{
		_visibleTimer = timerFactory.CreatePeriodicDispatched(TimeSlice.FromSeconds(5.0), SetNotificationsVisibleByTimeAsRead);
		_notificationService = notificationService;
		Notifications = new PairedCollection<INotification, INotificationVM>(_notificationService.Notifications, (INotification n) => factory.Create(n, hyperlinkService));
		VisibleNotifications = new ObservableCollection<INotificationVM>();
		Notifications.CollectionChanged += OnCollectionChanged;
		VisibleNotifications.CollectionChanged += OnVisibleNotificationsChanged;
	}

	[RelayCommand]
	private void MarkAllAsRead()
	{
		_notificationService.MarkAllAsRead();
	}

	private void SetNotificationsVisibleByTimeAsRead()
	{
		using (_timerLock.EnterScope())
		{
			_visibleTimer.Stop();
			foreach (INotificationVM visibleNotification in VisibleNotifications)
			{
				if (!visibleNotification.IsRead)
				{
					_notificationService.MarkAsRead(visibleNotification.Id);
				}
			}
		}
	}

	private void OnVisibleNotificationsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!IsPopUpOpen)
		{
			return;
		}
		using (_timerLock.EnterScope())
		{
			_visibleTimer.Start();
		}
	}

	private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("UnreadNotifications");
		OnPropertyChanged("AnyNotifications");
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsPopUpOpenChanged(bool value)
	{
		using (_timerLock.EnterScope())
		{
			if (value)
			{
				_visibleTimer.Start();
			}
			else
			{
				_visibleTimer.Stop();
			}
		}
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
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		using (_timerLock.EnterScope())
		{
			_visibleTimer.Dispose();
		}
		Notifications.CollectionChanged -= OnCollectionChanged;
		VisibleNotifications.CollectionChanged -= OnVisibleNotificationsChanged;
	}
}
