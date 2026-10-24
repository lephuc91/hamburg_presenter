using System;
using Pro.Common.Collections;
using ProPresenter.DO.Notifications;

namespace ProPresenter.UI.ViewModels.Notification;

public interface INotificationService
{
	INotifyEnumerableChanged<INotification> Notifications { get; }

	void MarkAsRead(Guid id);

	void MarkAllAsRead();
}
