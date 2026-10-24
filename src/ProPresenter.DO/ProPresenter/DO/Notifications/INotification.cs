using System;

namespace ProPresenter.DO.Notifications;

public interface INotification
{
	Guid Id { get; }

	string Header { get; }

	string Body { get; }

	string Url { get; }

	string UrlDisplayText { get; }

	DateTimeOffset CreatedAt { get; }

	DateTimeOffset ExpiresAt { get; }

	bool IsRead { get; }
}
