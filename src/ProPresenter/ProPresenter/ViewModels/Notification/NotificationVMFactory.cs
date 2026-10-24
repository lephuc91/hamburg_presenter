using Pro.Common.HTTP;
using ProPresenter.DO.Notifications;
using ProPresenter.UI.ViewModels.Notification;

namespace ProPresenter.ViewModels.Notification;

public class NotificationVMFactory : INotificationVMFactory
{
	public INotificationVM Create(INotification model, IHyperlinkService hyperlinkService)
	{
		return new NotificationVM(model, hyperlinkService);
	}
}
