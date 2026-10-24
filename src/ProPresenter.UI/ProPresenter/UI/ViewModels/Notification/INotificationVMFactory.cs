using Pro.Common.HTTP;
using ProPresenter.DO.Notifications;

namespace ProPresenter.UI.ViewModels.Notification;

public interface INotificationVMFactory
{
	INotificationVM Create(INotification model, IHyperlinkService hyperlinkService);
}
