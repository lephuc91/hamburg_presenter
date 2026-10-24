using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;

namespace ProPresenter.UI.ViewModels.Notification;

public interface INotificationCollectionVM : INotifyPropertyChanged
{
	bool IsPopUpOpen { get; set; }

	bool UnreadNotifications { get; }

	bool AnyNotifications { get; }

	ObservableCollection<INotificationVM> VisibleNotifications { get; }

	INotifyEnumerableChanged<INotificationVM> Notifications { get; }

	IRelayCommand MarkAllAsReadCommand { get; }
}
