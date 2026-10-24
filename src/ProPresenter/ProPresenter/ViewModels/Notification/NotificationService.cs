using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Notifications;
using ProPresenter.Registration.CallbackHandlers.Notifications;
using ProPresenter.UI.ViewModels.Notification;

namespace ProPresenter.ViewModels.Notification;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_subscription" })]
public class NotificationService : INotificationService, IDisposable
{
	private sealed class ObservableCollectionProxy<T> : ObservableCollection<T>, INotifyEnumerableChanged<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged
	{
	}

	private readonly ObservableCollectionProxy<ProPresenter.DO.Notifications.Notification> _notifications = new ObservableCollectionProxy<ProPresenter.DO.Notifications.Notification>();

	private readonly IRegistrationRequestSender _requestSender;

	private readonly IDisposable _subscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public INotifyEnumerableChanged<INotification> Notifications => _notifications;

	public NotificationService(IRegistrationRequestSender requestSender, INotificationCallbackHandler handler, IUiScheduler scheduler)
	{
		_requestSender = requestSender;
		_subscription = handler.WhenNotificationsChanged.ObserveOn(scheduler.Scheduler).Subscribe(_notifications.Reset);
	}

	public void MarkAsRead(Guid id)
	{
		SendMarkAsReadRequest(new global::_003C_003Ez__ReadOnlySingleElementList<string>(id.ToString()));
		int num = _notifications.FindIndex((ProPresenter.DO.Notifications.Notification n) => n.Id == id);
		if (num >= 0)
		{
			_notifications.Replace(_notifications[num]with
			{
				IsRead = true
			}, num);
		}
	}

	public void MarkAllAsRead()
	{
		SendMarkAsReadRequest((IReadOnlyCollection<string>)(object)(from n in _notifications
			where !n.IsRead
			select n.Id.ToString()).ToArray());
		_notifications.Reset((IReadOnlyCollection<ProPresenter.DO.Notifications.Notification>)(object)_notifications.Select((ProPresenter.DO.Notifications.Notification n) => n with
		{
			IsRead = true
		}).ToArray());
	}

	private void SendMarkAsReadRequest(IReadOnlyCollection<string> notifications)
	{
		if (notifications.Count > 0)
		{
			_requestSender.Send(new Request
			{
				MarkNotificationsRead = new MarkNotificationsRead
				{
					Id = { (IEnumerable<string>)notifications }
				}
			});
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
			_subscription.Dispose();
		}
	}
}
