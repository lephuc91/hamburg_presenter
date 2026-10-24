using System;
using System.Collections.Generic;
using ProPresenter.DO.Notifications;

namespace ProPresenter.Registration.CallbackHandlers.Notifications;

public interface INotificationCallbackHandler
{
	IObservable<IReadOnlyList<Notification>> WhenNotificationsChanged { get; }
}
