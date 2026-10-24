using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Notification;

public interface INotificationVM : INotifyPropertyChanged
{
	Guid Id { get; }

	string Header { get; }

	string Body { get; }

	string UrlDisplayText { get; }

	DateTimeOffset CreatedAt { get; }

	bool IsRead { get; }

	IRelayCommand ShowLinkCommand { get; }
}
